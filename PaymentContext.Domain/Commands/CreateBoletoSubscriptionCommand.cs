using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Numero { get; set; }
        public string Address { get; set; }

        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }

        public string PaymentNumber { get; set; }
        public DateTime PaiDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PaymentEmail { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }

        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<CreateBoletoSubscriptionCommand>()
           .Requires()
           .IsNotEmpty(FirstName, "FirstName", "Campo em branco")
           .IsNotEmpty(LastName, "LastName", "Campo em branco"));
        }
    }
}
