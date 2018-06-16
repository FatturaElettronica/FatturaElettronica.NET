using FatturaElettronica.FatturaElettronicaHeader.DatiTrasmissione;
using FatturaElettronica.Tabelle;
using FluentValidation;

namespace FatturaElettronica.Validators
{
    public class DatiTrasmissioneValidator : AbstractValidator<DatiTrasmissione>
    {
        public DatiTrasmissioneValidator()
        {
            RuleFor(dt => dt.IdTrasmittente)
                .SetValidator(new IdTrasmittenteValidator());
            RuleFor(dt => dt.ProgressivoInvio)
                .NotEmpty()
                .BasicLatinValidator()
                .Length(1, 10);
            RuleFor(dt => dt.FormatoTrasmissione)
                .NotEmpty()
                .SetValidator(new IsValidValidator<FormatoTrasmissione>())
                .WithErrorCode("00428");
            RuleFor(dt => dt.CodiceDestinatario)
                .NotEmpty();
            RuleFor(dt => dt.CodiceDestinatario)
                .Length(6)
                .When(dt => dt.FormatoTrasmissione == Impostazioni.FormatoTrasmissione.PubblicaAmministrazione)
                .WithErrorCode("00427");
            RuleFor(dt => dt.CodiceDestinatario)
                .Length(7)
                .When(dt => dt.FormatoTrasmissione == Impostazioni.FormatoTrasmissione.Privati)
                .WithErrorCode("00427");
            RuleFor(dt => dt.ContattiTrasmittente)
                .SetValidator(new ContattiTrasmittenteValidator())
                .When(x=>!x.ContattiTrasmittente.IsEmpty());
            /*   RuleFor(dt => dt.PECDestinatario)
                   .NotEmpty()
                   .When(dt => dt.CodiceDestinatario == "0000000")
                   .WithMessage("{PropertyName} non valorizzato a fronte di Codice Destinatario con valore 0000000")
                   .WithErrorCode("00426");*/
            RuleFor(dt => dt.PECDestinatario)
                .Length(7, 256)
                .When(dt => !string.IsNullOrEmpty(dt.PECDestinatario));

            RuleFor(dt => dt.PECDestinatario)
                .Empty()
                .When(dt => dt.CodiceDestinatario != "0000000")
                .WithMessage("{PropertyName} valorizzato a fronte di Codice Destinatario con valore diverso da 0000000")
                .WithErrorCode("00426");
        }
    }
}
