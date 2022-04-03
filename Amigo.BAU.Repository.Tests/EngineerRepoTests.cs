using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Amigo.BAU.Data.Models;
using FluentAssertions;

namespace Amigo.BAU.Repository.Tests
{
    public class EngineerRepoTests
    {
        [Fact]
        public void Add_Returns_Engineer()
        {
            // Arrange
            var engineer = new Engineer
            {
                EngineerId = 0,
                FirstShift = DateTimeOffset.Now.AddDays(-6).Date,
                LastShift = DateTimeOffset.Now.AddDays(-1).Date,
                ShiftCount = 2,
                EmployeeId = 1
            };
            var repo = new EngineerRepository.EngineerRepository();
            //Act

            var expected = repo.Add(engineer);
            //Assert
            expected.Should().Be(engineer);
        }

        [Fact]
        public void GetById_Retuns_EmplyeeModel()
        {
            var repo = new EngineerRepository.EngineerRepository();

            var expected = repo.GetById(0);

            expected.EmployeeId.Should().Be(1);
            expected.ShiftCount.Should().Be(2);
        }
    }
}
