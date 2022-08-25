using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
	public class ProductComparerShould
	{
		List<LoanProduct> productsToCompare;
		LoanAmount loanAmount;
		ProductComparer productComparer;

		[SetUp]
		public void SetUpTest()
		{
			productsToCompare = new List<LoanProduct>
			{
				new LoanProduct(1, "Tanio", 3.0m),
				new LoanProduct(2, "Średnio", 5.0m),
				new LoanProduct(3, "Daj Pan Spokój", 17.0m)
			};
			loanAmount = new LoanAmount("PLN", 500_000);
			productComparer = new ProductComparer(loanAmount, productsToCompare);
		}

		[Test]
		public void NumberOfLoanProductsTest()
		{
			var loanTerm = new LoanTerm(30);

			var result = productComparer.CompareMonthlyRepayments(loanTerm);

			Assert.That(productsToCompare, Has.Exactly(result.Count).Items);
		}

		[Test]
		public void CompareMonthlyRepaymentsUniqueTest()
		{
			var loanTerm = new LoanTerm(30);

			var result = productComparer.CompareMonthlyRepayments(loanTerm);

			Assert.That(result, Is.Unique);
		}

		[Test]
		public void CompereProductWithPaymentTest()
		{
			var loanTerm = new LoanTerm(30);

			var result = productComparer.CompareMonthlyRepayments(loanTerm);

			Assert.That(result, Has.Exactly(1).Matches<MonthlyRepaymentComparison>(x => x.ProductName.Equals("Tanio") && x.MonthlyRepayment > 0 && x.InterestRate.Equals(3.0m)));
		}
	}
}
