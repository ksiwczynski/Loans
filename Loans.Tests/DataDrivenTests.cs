using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Loans.Tests
{
	public class DataDrivenTests
	{
		[TestCaseSource(typeof(MonthlyRepaymentCsvData), "GetTestCaseData", new object[] { "data.csv" })]
		public void CheckCsvDataTest(decimal principal, decimal interestRate, int termInYears, decimal expectedMonthlyPayment)
		{
			var sut = new LoanRepaymentCalculator();

			var monthlyPayment = sut.CalculateMonthlyRepayment(
										new LoanAmount("USD", principal),
										interestRate,
										new LoanTerm(termInYears));

			Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
		}
	}

	public class MonthlyRepaymentCsvData
	{
		public static IEnumerable GetTestCaseData(string csvFileName)
		{
			var testData = new List<TestCaseData>();

			string[] data = File.ReadAllLines(csvFileName);

			foreach (string s in data)
			{
				// decimal decimal int decimal
				string[] parts = s.Split(",", StringSplitOptions.RemoveEmptyEntries);
				testData.Add(new TestCaseData(
					Decimal.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
					Decimal.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
					Int32.Parse(parts[2].Trim()),
					Decimal.Parse(parts[3].Trim(), CultureInfo.InvariantCulture)
					));
			}

			return testData;
		}
	}
}
