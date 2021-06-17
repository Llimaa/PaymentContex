using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;
using System;


namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paiDate, DateTime expireDate, string payer, Document document, decimal total, decimal totalPaid, Address address, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaiDate = paiDate;
            ExpireDate = expireDate;
            Payer = payer;
            Document = document;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Email = email;

            AddNotifications(new Contract<Payment>()
                 .Requires()
                .IsGreaterThan(DateTime.Now, PaiDate, "Payment.PaiData", "A data do pagamento deve ser futura")
                .IsLowerThan(0, Total, "Payment.Total", "O Total nao pode ser zero")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "O Valor pago é menor que o pagamento"));
        }

        public string Number { get; private set; }
        public DateTime PaiDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
    }
}
