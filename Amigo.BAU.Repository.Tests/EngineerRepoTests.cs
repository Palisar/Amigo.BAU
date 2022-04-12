
using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Repository.EngineerRepository;
using System;

namespace Amigo.BAU.Repository.Tests
{
    public class EngineerRepoTests
    {
        IEngineerRepository sut;

        public EngineerRepoTests()
        {
            sut = new InMemoryEngineerRepository();
        }

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
            //Act
            var expected = sut.Add(engineer);
            //Assert
            expected.Should().Be(engineer);
            expected.Result.EmployeeId.Should().Be(10);
        }

        [Fact]
        public async void GetById_Retuns_EmplyeeModel()
        {
            var expected = await sut.GetById(0);

            expected.EmployeeId.Should().Be(1);
            expected.ShiftCount.Should().Be(2);
        }
    }
}
