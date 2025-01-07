using System;
using FatturaElettronica.Extensions;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody.DatiBeniServizi;
using FatturaElettronica.Resources;
using FluentValidation;
using Natura = FatturaElettronica.Tabelle.Natura;
using TipoCessionePrestazione = FatturaElettronica.Tabelle.TipoCessionePrestazione;

namespace FatturaElettronica.Validators
{
    public class DettaglioLineeValidator : AbstractValidator<DettaglioLinee>
    {
        public DettaglioLineeValidator()
        {
            RuleFor(x => x.NumeroLinea)
                .InclusiveBetween(1, 9999)
                .WithMessage(string.Format(ValidatorMessages.ValidNumberRange_X_Y, 1, 9999));
            RuleFor(x => x.TipoCessionePrestazione)
                .SetValidator(new IsValidValidator<DettaglioLinee, string, TipoCessionePrestazione>())
                .When(x => !string.IsNullOrEmpty(x.TipoCessionePrestazione));
            RuleForEach(x => x.CodiceArticolo)
                .SetValidator(new CodiceArticoloValidator());
            RuleFor(x => x.Descrizione)
                .NotEmpty()
                .Length(1, 1000)
                .Latin1SupplementValidator();
            RuleFor(x => x.UnitaMisura)
                .Length(1, 10)
                .BasicLatinValidator();
            RuleForEach(x => x.ScontoMaggiorazione)
                .SetValidator(new ScontoMaggiorazioneValidator());
            RuleFor(x => x.PrezzoTotale)
                .Must((dettaglioLinee, _) => PrezzoTotaleValidateAgainstError00423(dettaglioLinee))
                .WithMessage(ValidatorMessages.E00423)
                .WithErrorCode("00423");
            RuleFor(x => x.Ritenuta)
                .Equal("SI")
                .When(x => !string.IsNullOrEmpty(x.Ritenuta));
            RuleFor(x => x.Natura)
                .SetValidator(new IsValidValidator<DettaglioLinee, string, Natura>())
                .When(x => !string.IsNullOrEmpty(x.Natura));
            RuleFor(x => x.Natura)
                .Must(natura => !string.IsNullOrEmpty(natura))
                .When(x => x.AliquotaIVA == 0)
                .WithMessage(ValidatorMessages.E00400)
                .WithErrorCode("00400");
            RuleFor(x => x.RiferimentoAmministrazione)
                .Length(1, 20)
                .BasicLatinValidator()
                .When(x => !string.IsNullOrEmpty(x.RiferimentoAmministrazione));
            RuleForEach(x => x.AltriDatiGestionali)
                .SetValidator(new AltriDatiGestionaliValidator());
            RuleFor(x => x.Quantita)
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.PrezzoUnitario)
                .ScalePrecision8DecimalType();
            RuleFor(x => x.PrezzoTotale)
                .ScalePrecision8DecimalType();
            RuleFor(x => x.AliquotaIVA)
                .LessThanOrEqualTo(100);
        }

        private static bool PrezzoTotaleValidateAgainstError00423(DettaglioLinee challenge)
        {
            var prezzo = Math.Round(challenge.PrezzoUnitario, 8, MidpointRounding.AwayFromZero);
            foreach (var sconto in challenge.ScontoMaggiorazione)
            {
                if (sconto.Importo == null && sconto.Percentuale == null) continue;

                var importo =
                    (decimal)(sconto.Importo != null
                        ? Math.Abs((decimal)sconto.Importo)
                        : sconto.Percentuale != null
                            ? prezzo * sconto.Percentuale / 100
                            : prezzo);

                if (sconto.Tipo == "SC")
                    prezzo -= importo;
                else
                    prezzo += importo;
            }

            return Math.Abs(Math.Round(challenge.PrezzoTotale, 2, MidpointRounding.AwayFromZero)
            - prezzo * (challenge.Quantita ?? 1)) <= 0.019m;
        }
    }
}
