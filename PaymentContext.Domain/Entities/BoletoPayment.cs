using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    class BoletoPayment : Payment
    {
        public BoletoPayment(string barCode, string boletoNumero, DateTime paiDate, DateTime expireDate, string payer, Document document, decimal total, decimal totalPaid, Address address, Email email)
        : base(paiDate, expireDate, payer, document, total, totalPaid, address, email)
        {
            BarCode = barCode;
            BoletoNumero = boletoNumero;
        }

        public string BarCode { get; private set; }
        public string BoletoNumero { get; private set; }
    }
}
