using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Handlers;
using PaymentContext.Test.Mocks;
using System;

namespace PaymentContext.Test.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository());
            var command = new CreateBoletoSubscriptionCommand();

            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Numero = "999999999";
            command.Address = "hello@gmaikl.com";
            command.BarCode = "123456789";
            command.BoletoNumber = "23232323232";
            command.PaymentNumber = "23232323232";
            command.PaiDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Payer = "Waynw corp";
            command.PayerDocument = "99999999999";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PaymentEmail = "hello@gmail.com";
            command.Total = 10;
            command.TotalPaid = 10;
            command.Street = "rua 01";
            command.Number = "10";
            command.Neighborhood = "nova olinda";
            command.City = "belem";
            command.State = "PA";
            command.Country = "Brasil";
            command.ZipCode = "6537000";

            handler.Handle(command);
            Assert.AreEqual(false, handler.IsValid);
        }
    }
}
