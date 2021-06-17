using PaymentContext.Domain.ValueObjects;
using System;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(string transactionCode, DateTime paiDate, DateTime expireDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email)
        : base(paiDate, expireDate, payer, document, total, totalPaid, address, email)
        {
            TransactionCode = transactionCode;
        }
        public string TransactionCode { get; private set; }
    }
}
