 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Amigo.BAU.Data.Models;
using FluentAssertions;

namespace Amigo.BAU.Repository.Tests
{
    public class EmployeeRepoTests
    {
        [Fact]
        public void Add_Returns_Employee()
        {
            // Arrange
            var employee = new Employee
            {
                EmployeeId = 0,
                Name = "Paul Keating",
                Email = "palisar@hotmail.co.uk"
            };

            var repo = new EmployeeRepository.EmployeeRepository();
            //Act
            var expected = repo.Add(employee);

            //Assert
            expected.Should().Be(employee);
        }

        [Fact]
        public void GetById_Retuns_EmplyeeModel()
        {
            
        }
    }
}
