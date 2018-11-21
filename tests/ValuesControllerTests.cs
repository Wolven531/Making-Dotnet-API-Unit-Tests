using FluentAssertions;
using making_unit_tests.Controllers;
using making_unit_tests.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace tests
{
	/// <summary>
	/// Inspired by:
	///		https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/testing?view=aspnetcore-2.1
	///		https://jakeydocs.readthedocs.io/en/latest/mvc/controllers/testing.html
	///		https://stackoverflow.com/questions/43229338/unit-test-controller-model-validation-on-aspnetcore
	/// </summary>
	public class ValuesControllerTests
	{
		private readonly Mock<IEntityRepository> _MockEntityRepository;

		private readonly ValuesController _Fixture;

		public ValuesControllerTests()
		{
			_MockEntityRepository = new Mock<IEntityRepository>();
			_Fixture = new ValuesController(_MockEntityRepository.Object);
		}

		[Fact]
		public void Get_WhenInvoked_ShouldReturnArrayOfStrings()
		{
			// Arrange

			// Act
			var actual = _Fixture.Get();

			// Assert
			actual.Value.Should().BeEquivalentTo(new[] { "value1", "value2" });
			_MockEntityRepository.VerifyNoOtherCalls();
		}

		[Fact]
		public void Post_WhenInvokedWithValue_ShouldUseRepositoryWithValue()
		{
			// Arrange
			string paramPassedToRepository = null;
			_MockEntityRepository
				.Setup(repo => repo.DoSomethingWithAValue(It.IsAny<string>()))
				.Callback<string>(valueUsed => paramPassedToRepository = valueUsed)
				.Returns(Task.CompletedTask);

			// Act
			_Fixture.Post("testValue");

			// Assert
			_MockEntityRepository.VerifyAll();
			paramPassedToRepository.Should().BeEquivalentTo("testValue");
		}
	}
}
