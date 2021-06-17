using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Test.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            _students = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                var student = new Student(new Name("Marcos", "LIma"), new Document("1111111111" + i.ToString(), EDocumentType.CPF), new Email(i.ToString() + "lima@gmail.com"));
                _students.Add(student);
            
            }
        }
        [TestMethod]
        public void ShouldRetunNullWhenDocumentNotExiste()
        {
            var exp = StudentQueries.GetStudent("12345678911");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldRetunNullWhenDocumentExiste()
        {

            var exp = StudentQueries.GetStudent("11111111111");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }
    }
}
