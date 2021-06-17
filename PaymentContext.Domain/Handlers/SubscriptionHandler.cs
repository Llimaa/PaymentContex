using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable<Notification>, IHandler<CreateBoletoSubscriptionCommand>, IHandler<CreatePaypalSubscriptionCommand>, IHandler<CreateCreditCardSubscriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public SubscriptionHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {

            // Fail fast Validations
            command.Validate();
            if (!command.IsValid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura!");
            }

            // Verificar se Documento já esta cadastrado.
            if (_studentRepository.DocumentExists(command.PayerDocument))
                AddNotification("Document", "Cpf  já está em uso");

            // verificar se email ja esta cadastrado
            if (_studentRepository.EmailExists(command.PaymentEmail))
                AddNotification("Email", "Email já está em uso");

            // Gerar vos
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.PayerDocument, command.PayerDocumentType);
            var email = new Email(command.PaymentEmail);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar entities

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                command.BarCode,
                command.BoletoNumber,
                command.PaiDate,
                command.ExpireDate,
                command.Payer,
                document,
                command.Total,
                command.TotalPaid,
                address,
                email
                );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar as validações
            AddNotifications(name, document, address, student, subscription, payment);

            if(!IsValid)
                return new CommandResult(false, "nao foi possivel realizar sua assinatura!");

            // Salvar info.
            _studentRepository.CreateSubscription(student);

            // Retornar informação
            return new CommandResult(true, "Assinatura realizada com sucesso!", command);
        }

        public ICommandResult Handle(CreatePaypalSubscriptionCommand command)
        {
            // Fail fast Validations

            // Verificar se Documento já esta cadastrado.
            if (_studentRepository.DocumentExists(command.PayerDocument))
                AddNotification("Document", "Cpf  já está em uso");

            // verificar se email ja esta cadastrado
            if (_studentRepository.EmailExists(command.PaymentEmail))
                AddNotification("Email", "Email já está em uso");

            // Gerar vos
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.PayerDocument, command.PayerDocumentType);
            var email = new Email(command.PaymentEmail);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar entities

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new PayPalPayment(
                command.TransactionCode,
                command.PaiDate,
                command.ExpireDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                document,
                address,
                email
                );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar as validações
            AddNotifications(name, document, address, student, subscription, payment);

            // Salvar info.

            _studentRepository.CreateSubscription(student);

            // Retornar informação
            return new CommandResult(true, "Assinatura realizada com sucesso!", command);
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            // Fail fast Validations

            // Verificar se Documento já esta cadastrado.
            if (_studentRepository.DocumentExists(command.PayerDocument))
                AddNotification("Document", "Cpf  já está em uso");

            // verificar se email ja esta cadastrado
            if (_studentRepository.EmailExists(command.PaymentEmail))
                AddNotification("Email", "Email já está em uso");

            // Gerar vos
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.PayerDocument, command.PayerDocumentType);
            var email = new Email(command.PaymentEmail);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            // Gerar entities

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditPayment(
                command.CardHolderName,
                command.CardNumber,
                command.LastTransactionNumber,
                command.PaiDate,
                command.ExpireDate,
                command.Payer,
                document,
                command.Total,
                command.TotalPaid,
                address,
                email
                );

            //Relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            // Agrupar as validações
            AddNotifications(name, document, address, student, subscription, payment);

            // Salvar info.

            _studentRepository.CreateSubscription(student);

            // Retornar informação
            return new CommandResult(true, "Assinatura realizada com sucesso!", command);
        }
    }
}
