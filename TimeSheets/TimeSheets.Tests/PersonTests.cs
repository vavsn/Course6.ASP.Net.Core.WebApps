using Moq;
using TimeSheets.BL.Repositories;
using TimeSheets.Controllers;
using TimeSheets.DAL.Models;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace TimeSheets.Tests
{
    public class PersonTests
    {
        [Fact]
        public void Cant_update_Person()
        {
            // Arrange
            var person = new Mock<IPersonRepository>();
            person.Setup(p => p.Get());
            PersonRepository pr = new PersonRepository(person.Object);
            PersonControllers pc = new PersonControllers(pr);

            var persTest = new Person();
            persTest.Email = "1@ru.ru";
            persTest.Age = 12;
            persTest.FirstName = "rrr";
            persTest.LastName = "ddd";
            persTest.IsDelete = false;
            persTest.Company = "www";
            persTest.Id = -1;

            // Act
            var result = pc.Update(persTest);

            // Assert
            result.Result.Should().BeOfType(typeof(BadRequestResult));
        }
    }
}
