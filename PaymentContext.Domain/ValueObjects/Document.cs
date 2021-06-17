using Flunt.Validations;
using PaymentContext.Domain.Enuns;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string numero, EDocumentType type)
        {
            Numero = numero;
            Type = type;

            AddNotifications(new Contract<Document>()
                   .Requires()
                  .IsTrue(Validate(), "Document.Number", "Documento Inválido"));
        }

        public string Numero { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool Validate()
        {
            if (Type == EDocumentType.CNPJ && Numero.Length == 14)
                return true;
            if (Type == EDocumentType.CPF && Numero.Length == 11)
                return true;

            return false;
        }
    }
}
