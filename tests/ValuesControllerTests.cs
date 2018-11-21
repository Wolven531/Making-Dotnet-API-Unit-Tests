using FluentAssertions;
using making_unit_tests.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace tests
{
	public class ValuesControllerTests
	{
		[Fact]
		public void Get_WhenInvoked_ShouldReturnArrayOfStrings()
		{
			var fixture = new ValuesController();

			var actual = fixture.Get();

			actual.Value.Should().BeEquivalentTo(new[] { "value1", "value2" });
		}
	}
}
