﻿using NUnit.Framework;
using System;
using System.Linq;

namespace AlternativePayments.Tests.Services
{
    [TestFixture]
    public class TestTransactions
    {
        private const string ApiKey = "-- please provide valid test API key --";
        private const string ApiBaseUrl = "-- please provide valid test API base URL -";

        private AlternativePaymentsClient _alternativePayments = null;

        [OneTimeSetUp]
        public void Init()
        {
            _alternativePayments = new AlternativePaymentsClient(ApiKey, ApiBaseUrl);
        }

        [Test]
        public void GetTransactionById()
        {
            // Arange
            var transactionId = "trn_90d4464b83df";

            // Act
            var transaction = _alternativePayments.TransactionService.Get(transactionId);

            // Assert
            Assert.That(transactionId, Is.EqualTo(transaction.Id));
        }

        [Test]
        public void GetAllTransactions()
        {
            // Arange           

            // Act
            var transactionList = _alternativePayments.TransactionService.GetAll();

            // Assert
            Assert.That(transactionList.Transactions.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void GetTenTransactions()
        {
            // Arrange
            var filter = new CommonFilter().WithLimit(10);

            //Act
            var transactionList = _alternativePayments.TransactionService.GetAll(filter);

            //Assert
            Assert.That(transactionList.Transactions.Count(), Is.LessThanOrEqualTo(10));            
        }

        [Test]
        public void GetTransactionsForPeriod()
        {
            // Arrange
            var filter = new CommonFilter().WithStartDate(DateTime.Now.AddYears(-1)).WithEndDate(DateTime.Now);

            //Act
            var transactionList = _alternativePayments.TransactionService.GetAll(filter);

            //Assert
            Assert.That(transactionList.Transactions.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void GetAllSepaTransactions()
        {
            // Arange           

            // Act
            var transactionList = _alternativePayments.TransactionService.GetAllSepa();

            // Assert
            Assert.That(transactionList.Transactions.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void GetTenSepaTransactions()
        {
            // Arrange
            var filter = new SepaFilter().WithLimit(10);

            //Act
            var transactionList = _alternativePayments.TransactionService.GetAllSepa(filter);

            //Assert
            Assert.That(transactionList.Transactions.Count(), Is.LessThanOrEqualTo(10));
        }

        [Test]
        public void GetFundedSepaTransactions()
        {
            // Arrange
            var filter = new SepaFilter().WithTransactionStatus(TransactionStatus.Funded);

            //Act
            var transactionList = _alternativePayments.TransactionService.GetAllSepa(filter);

            //Assert
            Assert.That(transactionList.Transactions.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void GetSepaTransactionsForCreatedTime()
        {
            // Arrange
            var filter = new SepaFilter().WithCreatedFrom(DateTime.Now.AddYears(-1)).WithCreatedTo(DateTime.Now);

            //Act
            var transactionList = _alternativePayments.TransactionService.GetAllSepa(filter);

            //Assert
            Assert.That(transactionList.Transactions.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void GetSepaTransactionsForUpdatedTime()
        {
            // Arrange
            var filter = new SepaFilter().WithUpdatedFrom(DateTime.Now.AddYears(-1)).WithUpdatedTo(DateTime.Now);

            //Act
            var transactionList = _alternativePayments.TransactionService.GetAllSepa(filter);

            //Assert
            Assert.That(transactionList.Transactions.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void TransactionNotFound()
        {
            // Arange
            var transactionId = "pay_7cd5a213a5f44c0e8-";

            // Act
            var ex = Assert.Throws<AlternativePaymentsException>(() => _alternativePayments.TransactionService.Get(transactionId));

            // Assert
            Assert.That(ex.Error.Code, Is.EqualTo("requested_resource_could_not_be_found"));
        }

        [Test]
        public void CreateTransactionWithPaymentId()
        {
            // payment
            var transaction = new Transaction.Builder("cus_a29fcd978cea4360a", 500, "USD", "89.216.124.9")
                .WithPaymentId("pay_c2f97f0475bc451fb")
                .Build();

            // Act
            var result = _alternativePayments.TransactionService.Create(transaction);

            // Assert
            Assert.That(result.IpAddress, Is.EqualTo("89.216.124.9"));
        }

        [Test]
        public void CreateSepaTransactionWithPaymentObjectAndCustomerObject()
        {
            // Arange
            var payment = new Payment.Builder("SEPA", "John Doe", "89.216.124.9")
                .WithIban("DEST1000200030004000500")
                .Build();

            var customer = new Customer.Builder("John", "Doe", "john@doe.com", "DE", "89.216.124.9")
                .WithAddress("Marko Bode Strasse")
                .WithCity("Dortmund")
                .WithZip("A2123")
                .Build();

            var transaction = new Transaction.Builder(customer, 500, "USD", "89.216.124.9")
                .WithPayment(payment)
                .WithMerchantPassThruData("trn0045")
                .WithDescription("Description")
                .WithRecurring(true)
                .Build();

            // Act
            var result = _alternativePayments.TransactionService.Create(transaction);

            // Assert
            Assert.That(result.IpAddress, Is.EqualTo("89.216.124.9"));
        }

        [Test]
        public void CreateSepaTransactionWithPaymentObjectWithMandateIdAndMandateDateOfSignature()
        {
            // Arange
            var payment = new Payment.Builder("SEPA", "John Doe", "89.216.124.9")
                .WithIban("DEST1000200030004000500")
                .WithMandateID("1281221")
                .WithMandateDateOfSignature("2018-01-20")
                .Build();

            var customer = new Customer.Builder("John", "Doe", "john@doe.com", "DE", "89.216.124.9")
                .WithAddress("Marko Bode Strasse")
                .WithCity("Dortmund")
                .WithZip("A2123")
                .Build();

            var transaction = new Transaction.Builder(customer, 500, "USD", "89.216.124.9")
                .WithPayment(payment)
                .WithMerchantPassThruData("trn0045")
                .WithDescription("Description")
                .WithRecurring(true)
                .Build();

            // Act
            var result = _alternativePayments.TransactionService.Create(transaction);

            // Assert
            Assert.That(result.IpAddress, Is.EqualTo("89.216.124.9"));
        }

        [Test]
        public void CreateSepaTransactionWithCreditorIdAndCreditorName()
        {
            // Arange
            var payment = new Payment.Builder("SEPA", "John Doe", "89.216.124.9")
                .WithIban("DEST1000200030004000500")
                .Build();

            var customer = new Customer.Builder("John", "Doe", "john@doe.com", "DE", "89.216.124.9")
                .WithAddress("Marko Bode Strasse")
                .WithCity("Dortmund")
                .WithZip("A2123")
                .Build();

            var transaction = new Transaction.Builder(customer, 500, "USD", "89.216.124.9")
                .WithPayment(payment)
                .WithMerchantPassThruData("trn0045")
                .WithDescription("Description")
                .WithRecurring(false)
                .WithCreditorID("CH13YYY99887700111")
                .WithCreditorName("Alternative Payments")
                .Build();

            // Act
            var result = _alternativePayments.TransactionService.Create(transaction);

            // Assert
            Assert.That(result.IpAddress, Is.EqualTo("89.216.124.9"));
        }

        [Test]
        public void CreateSepaTransactionWithCustomDescriptor()
        {
            // Arange
            var payment = new Payment.Builder("SEPA", "John Doe", "89.216.124.9")
                .WithIban("DEST1000200030004000500")
                .Build();

            var customer = new Customer.Builder("John", "Doe", "john@doe.com", "DE", "89.216.124.9")
                .WithAddress("Marko Bode Strasse")
                .WithCity("Dortmund")
                .WithZip("A2123")
                .Build();

            var transaction = new Transaction.Builder(customer, 500, "USD", "89.216.124.9")
                .WithPayment(payment)
                .WithMerchantPassThruData("trn0045")
                .WithDescription("Description")
                .WithRecurring(false)
                .WithCustomDescriptor("1111.2234.9874 Alternative Payments 1288888 11111.1684231-2")
                .Build();

            // Act
            var result = _alternativePayments.TransactionService.Create(transaction);

            // Assert
            Assert.That(result.IpAddress, Is.EqualTo("89.216.124.9"));
        }

        [Test]
        public void CreateSepaTransactionWithSequenceType()
        {
            // Arange
            var payment = new Payment.Builder("SEPA", "John Doe", "89.216.124.9")
                .WithIban("DE89370400440532013000")
                .WithMandateID("123123")
                .WithMandateDateOfSignature("12/23/2020")
                .Build();

            var customer = new Customer.Builder("John", "Doe", "john@doe.com", "DE", "89.216.124.9")
                .WithAddress("Marko Bode Strasse")
                .WithCity("Dortmund")
                .WithZip("A2123")
                .Build();

            var transaction = new Transaction.Builder(customer, 500, "EUR", "89.216.124.9")
                .WithPayment(payment)
                .WithMerchantTransactionId("MyTransactionCode2")
                .WithCreditorName("MyCreditorName345")
                .WithCreditorID("LT07ZZZ7824811973")
                .WithCustomDescriptor("This is my test of Transaction using full Payment body")
                .WithSequenceType("FNAL")
                .WithRedirectUrls("http://alternativepayments.com/message/success.html", "http://alternativepayments.com/message/failure.html")
                .Build();

            // Act
            var result = _alternativePayments.TransactionService.Create(transaction);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.Not.Empty);
        }

        [Test]
        public void CreateIdealTransactionWithPaymentObjectAndCustomerObject()
        {
            // Arange
            var payment = new Payment.Builder("ideal", "John Doe", "89.216.124.9")
                .Build();

            var customer = new Customer.Builder("John", "Doe", "john@doe.com", "NL", "89.216.124.9")
                .WithAddress("Marko Bode Strasse")
                .WithCity("Dortmund")
                .WithZip("A2123")
                .Build();

            var transaction = new Transaction.Builder(customer, 500, "USD", "89.216.124.9")
                .WithPayment(payment)
                .WithRedirectUrls("http://plugins.alternativepayments.com/message/success.html", "http://plugins.alternativepayments.com/message/failure.html")
                .Build();

            // Act
            var result = _alternativePayments.TransactionService.Create(transaction);

            // Assert
            Assert.That(result.IpAddress, Is.EqualTo("89.216.124.9"));
        }

        [Test]
        public void CreateBrazilPayBoletoTransactionWithPaymentObjectAndCustomerObject()
        {
            // Arange
            var payment = new Payment.Builder("BrazilPayBoleto", "Roberto Doe", "89.216.124.9")
                .WithDocumentId("924.521.873-24")
                .Build();

            var customer = new Customer.Builder("Roberto", "Doe", "roberto@doe.com", "BR", "89.216.124.9")
                .WithAddress("Av Max Teixeira")
                .WithAddress2("1040")
                .WithCity("Manaus")
                .WithZip("69050-240")
                .WithState("AM")
                .WithBirthDate("02/05/1974")
                .WithPhone("+55123123123")
                .Build();

            var transaction = new Transaction.Builder(customer, 500, "USD", "89.216.124.9")
                .WithPayment(payment)
                .WithRedirectUrls("http://plugins.alternativepayments.com/message/success.html", "http://plugins.alternativepayments.com/message/failure.html")
                .Build();

            // Act
            var result = _alternativePayments.TransactionService.Create(transaction);

            // Assert
            Assert.That(result.IpAddress, Is.EqualTo("89.216.124.9"));
        }

        [Test]
        public void CreateSepaTransactionWithPaymentObjectCustomerObjectAndPin()
        {
            // Arange
            var payment = new Payment.Builder("SEPA", "John Doe", "89.216.124.9")
                .WithIban("DEST1000200030004000500")
                .Build();
            var phoneVerificationToken = "";
            var smsPin = "";

            var customer = new Customer.Builder("John", "Doe", "john@doe.com", "DE", "89.216.124.9")
                .WithAddress("Marko Bode Strasse")
                .WithCity("Dortmund")
                .WithZip("A2123")
                .Build();

            var transaction = new Transaction.Builder(customer, 500, "USD", "89.216.124.9")
                .WithPayment(payment)
                .WithSmsPin(phoneVerificationToken, smsPin)
                .Build();

            // Act
            var result = _alternativePayments.TransactionService.Create(transaction);

            // Assert
            Assert.That(result.IpAddress, Is.EqualTo("89.216.124.9"));
        }

        [Test]
        public void AuthorizeTransaction()
        {
            //Arrange
            var payment = new Payment.Builder("DirectPayMax", "John Doe", "89.216.124.9")
                .WithIban("DE33500105175638584187")
                .Build();

            var customer = new Customer.Builder("John", "Doe", "john@doe.com", "FR", "89.216.124.9")
                .Build();

            var transaction = new Transaction.Builder(customer, 500, "EUR", "89.216.124.9")
                .WithPayment(payment)
                .WithRedirectUrls("https://display-parameters.com/","https://display-parameters.com/")
                .Build();
            
            //Act
            var transactionResult = _alternativePayments.TransactionService.Create(transaction);
            var authorizationResult = _alternativePayments.TransactionService.Authorize(transactionResult.Id, new TransactionAuthorizationCredential());

            //Assert
            Assert.That(authorizationResult.TransactionStatus, Is.EqualTo("Pending"));
        }
    }
}
