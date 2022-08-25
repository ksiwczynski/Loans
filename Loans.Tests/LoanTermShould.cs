using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Loans.Tests
{
	public class LoanTermShould
	{
		[Test]
		public void LoanTermMonthsInTermTest()
		{
			var sut = new LoanTerm(1);

			Assert.That(sut.ToMonths(), Is.EqualTo(12), "Year doesn't equal 12 months");
		}

		[Test]
		public void LoanTermYearTest()
		{
			var sut = new LoanTerm(1);

			Assert.That(sut.Years, Is.EqualTo(1));
		}

		[Test]
		public void LongTermEqualTest()
		{
			var sut1 = new LoanTerm(1);
			var sut2 = new LoanTerm(1);

			Assert.That(sut2, Is.EqualTo(sut1));
		}

		[Test]
		public void LongTermRefTest()
		{
			var sut1 = new LoanTerm(1);
			var sut2 = new LoanTerm(1);
			var sut3 = sut2;

			Assert.That(sut2, Is.Not.SameAs(sut1));
			Assert.That(sut3, Is.SameAs(sut2));
		}

		[Test]
		public void StringListEqualRefTest()
		{
			var l1 = new List<string>();
			var l2 = new List<string>();
			var l3 = l2;

			Assert.That(l2, Is.EqualTo(l1));
			Assert.That(l2, Is.Not.SameAs(l1));
			Assert.That(l3, Is.SameAs(l2));
		}

		[TestCase(0.1, 0.2, 0.3)]
		public void DoublePrecisionTest(double a, double b, double result)
		{
			Assert.That(a + b, Is.EqualTo(result).Within(0.1));
		}

		[TestCase(1.0, 3.0, 0.3333)]
		public void DivPrecisionTest(double a, double b, double result)
		{
			Assert.That(a / b, Is.EqualTo(result).Within(0.0001));
		}

		[Test]
		public void CatchExceptionTest()
		{
			Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>());
		}
	}
}
