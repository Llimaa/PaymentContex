using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class CreditPayment: Payment
    {
        public CreditPayment(string cardHolderName, string cardNumber, string lastTransactionNumber, DateTime paiDate, DateTime expireDate, string payer, Document document, decimal total, decimal totalPaid, Address address, Email email)
        : base(paiDate, expireDate, payer, document, total, totalPaid, address, email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}
