
using System;
using System.Data.SqlClient;
using Amigo.BAU.Persistance.Models;
using Amigo.BAU.Repository.EngineerRepository;

namespace Amigo.BAU.Repository.Tests
{
    public class EngineerRepoTests
    {
        IEngineerRepository sut;

        public EngineerRepoTests()
        {
            this.sut = new EngineerRepository.EngineerRepository(new SqlConnection("Data Source=DESKTOP-PALISAR\\SQLEXPRESS;Initial Catalog=AmigoDb;Trusted_Connection=True;"));
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
        }

        [Fact]
        public void GetById_Retuns_EmplyeeModel()
        {
           

            var expected = sut.GetById(0);

            expected.EmployeeId.Should().Be(1);
            expected.ShiftCount.Should().Be(2);
        }
    }
}
