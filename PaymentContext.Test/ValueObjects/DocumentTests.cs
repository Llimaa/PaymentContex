using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Test.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShoulReturnErrorWhenCNPJIsInvalid()
        {
            var document = new Document("1234", EDocumentType.CNPJ);
            Assert.IsTrue(!document.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var document = new Document("78046748000112", EDocumentType.CNPJ);
            Assert.IsTrue(document.IsValid);
        }

        [TestMethod]
        public void ShoulReturnErrorWhenCPFIsInvalid()
        {
            var document = new Document("213", EDocumentType.CPF);
            Assert.IsFalse(document.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("53388108080")]
        [DataRow("86856723091")]
        [DataRow("02230249029")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var document = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(document.IsValid);
        }
    }
}
