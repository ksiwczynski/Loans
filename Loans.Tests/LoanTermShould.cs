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

			Assert.That(sut.ToMonths(), Is.EqualTo(12));
		}

		[Test]
		public void LoanTermYearTest()
		{
			var sut = new LoanTerm(1);

			Assert.That(sut.Years, Is.EqualTo(1));
		}
	}
}
