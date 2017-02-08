using FatturaElettronica.FatturaElettronicaHeader.DatiTrasmissione;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiTrasmissioneValidator : AbstractValidator<DatiTrasmissione>
    {
        public DatiTrasmissioneValidator()
        {
            RuleFor(dt => dt.IdTrasmittente).SetValidator(new IdTrasmittenteValidator());
            RuleFor(dt => dt.ProgressivoInvio).Length(1, 10);
            RuleFor(dt => dt.FormatoTrasmissione).IsValidFormatoTrasmissioneValue();

            RuleFor(dt => dt.CodiceDestinatario).Length(6)
                .When(dt => dt.FormatoTrasmissione == Impostazioni.FormatoTrasmissione.PubblicaAmministrazione);
            RuleFor(dt => dt.CodiceDestinatario).Length(7)
                .When(dt => dt.FormatoTrasmissione == Impostazioni.FormatoTrasmissione.Privati);

            RuleFor(dt => dt.ContattiTrasmittente).SetValidator(new ContattiTrasmittenteValidator());

            RuleFor(dt => dt.PECDestinatario).Length(7, 256)
                .When(dt => dt.CodiceDestinatario == "0000000")
                .WithMessage("{PropertyName} non valorizzato a fronte di Codice Destinatario con valore 0000000");
            RuleFor(dt => dt.PECDestinatario).Empty()
                .When(dt => dt.CodiceDestinatario != "0000000")
                .WithMessage("{PropertyName} valorizzato a fronte di Codice Destinatario con valore diverso da 0000000");
        }
    }
}
