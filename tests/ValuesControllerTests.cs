using FluentAssertions;
using making_unit_tests.Controllers;
using making_unit_tests.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace tests
{
	public class ValuesControllerTests
	{
		[Fact]
		public void Get_WhenInvoked_ShouldReturnArrayOfStrings()
		{
			// Arrange
			var mockEntityRepository = new Mock<IEntityRepository>();
			var fixture = new ValuesController(mockEntityRepository.Object);

			// Act
			var actual = fixture.Get();

			// Assert
			actual.Value.Should().BeEquivalentTo(new[] { "value1", "value2" });
			mockEntityRepository.VerifyNoOtherCalls();
		}
	}
}
