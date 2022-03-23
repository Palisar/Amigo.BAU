using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Amigo.BAU.Application.Models;
using FluentAssertions;

namespace Amigo.BAU.Repository.Tests
{
    public class EmployeeRepoTests
    {
        [Fact]
        public void GetByAll_Returns_IEnumOfEmployee()
        {
            // Arrange
            var moq = new Mock<IEmployeeRepository>();
            moq.Setup(m => m.GetAll()).Returns(new List<EmployeeModel>
            {
                new EmployeeModel {Id = 1, Name = "John"},
                new EmployeeModel {Id = 2, Name = "Mary"}
            });

            var repo = moq.Object;
            //Act
            var result = repo.GetAll();
            //Assert
            result.Should().NotBeEmpty();
            result.Should(). BeEquivalentTo(new List<EmployeeModel>
            {
               new EmployeeModel() {
                   Id = 1,
                   Name = "John",
                   ShiftCount = 0,
                   WorkedShiftYesterday = false
                },
               new EmployeeModel()
               {
                   Id = 2,
                   Name = "Mary",
                   ShiftCount = 0,
                   WorkedShiftYesterday = false
               }

            });
        }

        [Fact]
        public void GetById_Retuns_EmplyeeModel()
        {
            var moq = new Mock<IEmployeeRepository>();
            moq.Setup(m => m.GetById(1)).Returns(new EmployeeModel()
                {
                    Id = 1,
                    Name = "John",
                    ShiftCount = 0,
                    WorkedShiftYesterday = false
                });
            var repo = moq.Object;

            var result = repo.GetById(1);

            result.Name.Should().Be("John");
        }

        [Fact]
        public void 
    }
}
