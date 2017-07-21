# .Net SDK for Alternative Payments RESTful API

## Installation

In the Package Manager Console run the following command:
```powershell
PM> Install-Package AlternativePayments
```

## Developer Documentation
[Official Alternative Payments RESTful API Reference](http://www.alternativepayments.com/developers/API/)

## Usage

```csharp
var alternativePaymentsClient = new AlternativePaymentsClient("sk_test_mF2qf4lBXZodrwVrEIBxTpXi0mxZvE2xJ0pOwct2");

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

var result = alternativePaymentsClient.TransactionService.Create(transaction);
```

## License

Read [License](https://github.com/AlternativePayments/ap-net-sdk/blob/master/LICENSE) for more licensing information.