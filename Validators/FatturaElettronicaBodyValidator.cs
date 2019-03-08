using System;
using System.Collections.Generic;
using FatturaElettronica.Ordinaria.FatturaElettronicaBody;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class FatturaElettronicaBodyValidator : AbstractValidator<FatturaElettronicaBody>
    {
        public FatturaElettronicaBodyValidator()
        {
            RuleFor(x => x.DatiGenerali)
                .SetValidator(new DatiGeneraliValidator());
            RuleFor(x => x.DatiBeniServizi)
                .SetValidator(new DatiBeniServiziValidator());
            RuleFor(x => x.DatiBeniServizi)
                .Must(x => !x.IsEmpty()).WithMessage("DatiBeniServizi è obbligatorio");
            RuleFor(x => x.DatiGenerali.DatiGeneraliDocumento.DatiRitenuta)
                .Must((body, _) => DatiRitenutaAgainstDettaglioLinee(body))
                .When(x => x.DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.IsEmpty())
                .WithMessage("DatiRitenuta non presente a fronte di almeno un blocco DettaglioLinee con Ritenuta uguale a SI")
                .WithErrorCode("00411");
            RuleFor(x => x.DatiBeniServizi.DatiRiepilogo)
                .Must((body, _) => DatiRiepilogoValidateAgainstError00422(body))
                .WithMessage("ImponibileImporto non calcolato secondo le specifiche tecniche")
                .WithErrorCode("00422");
            RuleFor(x => x.DatiBeniServizi.DatiRiepilogo)
                .Must((body, _) => DatiRiepilogoValidateAgainstError00419(body))
                .WithMessage("DatiRiepilogo non presente in corrispondenza di almeno un valore DettaglioLinee.AliquiotaIVA o DatiCassaPrevidenziale.AliquotaIVA")
                .WithErrorCode("00419");
            RuleFor(x => x.DatiVeicoli)
                .SetValidator(new DatiVeicoliValidator())
                .When(x => x.DatiVeicoli != null && !x.DatiVeicoli.IsEmpty());
            RuleForEach(x => x.DatiPagamento)
                .SetValidator(new DatiPagamentoValidator());
            RuleForEach(x => x.Allegati)
                .SetValidator(new AllegatiValidator());
        }

        private bool DatiRitenutaAgainstDettaglioLinee(FatturaElettronicaBody body)
        {
            foreach (var linea in body.DatiBeniServizi.DettaglioLinee)
            {
                if (linea.Ritenuta == "SI") return false;
            }
            return true;
        }
        private bool DatiRiepilogoValidateAgainstError00422(FatturaElettronicaBody body)
        {
            var totals = new Dictionary<decimal, Totals>();

            foreach (var r in body.DatiBeniServizi.DatiRiepilogo)
            {
                if (!totals.ContainsKey(r.AliquotaIVA))
                    totals.Add(r.AliquotaIVA, new Totals());

                totals[r.AliquotaIVA].ImponibileImporto += r.ImponibileImporto;
                totals[r.AliquotaIVA].Arrotondamento += r.Arrotondamento ?? 0;
            }
            foreach (var l in body.DatiBeniServizi.DettaglioLinee)
            {
                if (!totals.ContainsKey(l.AliquotaIVA))
                    totals.Add(l.AliquotaIVA, new Totals());

                totals[l.AliquotaIVA].PrezzoTotale += l.PrezzoTotale;
            }
            foreach (var c in body.DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale)
            {
                if (!totals.ContainsKey(c.AliquotaIVA))
                    totals.Add(c.AliquotaIVA, new Totals());

                totals[c.AliquotaIVA].ImportoContrCassa += c.ImportoContributoCassa;
            }

            foreach (var t in totals.Values)
            {
                if (Math.Abs(t.ImponibileImporto - (t.PrezzoTotale + t.ImportoContrCassa + t.Arrotondamento)) >= 1) return false;
            }
            return true;
        }
        private bool DatiRiepilogoValidateAgainstError00419(FatturaElettronicaBody body)
        {
            var hash = new HashSet<decimal>();
            foreach (var cp in body.DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale)
            {
                if (!hash.Contains(cp.AliquotaIVA)) hash.Add(cp.AliquotaIVA);
            }
            foreach (var l in body.DatiBeniServizi.DettaglioLinee)
            {
                if (!hash.Contains(l.AliquotaIVA)) hash.Add(l.AliquotaIVA);
            }
            return body.DatiBeniServizi.DatiRiepilogo.Count >= hash.Count;
        }

        internal class Totals
        {
            public decimal ImponibileImporto;
            public decimal PrezzoTotale;
            public decimal Arrotondamento;
            public decimal ImportoContrCassa;
        }
    }
}
