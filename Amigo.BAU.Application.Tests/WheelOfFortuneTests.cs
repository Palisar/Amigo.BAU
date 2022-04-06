
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Application.Services;
using Amigo.BAU.Persistance.QueryModels;
using Amigo.BAU.Repository.EngineerRepository;

namespace AmigoBAU.Tests.ConsoleTests
{
    public class WheelOfFortuneTests
    {
        
        private static IDateTimeProvider _dateTimeProvider = new DateTimeProvider();
        private static IDbConnection dbConnection = new SqlConnection("Data Source=DESKTOP-PALISAR\\SQLEXPRESS;Initial Catalog=AmigoDb;Trusted_Connection=True;");
        private static IEngineerRepository _engineerRepository = new EngineerRepository(dbConnection);
        private SupportWheelOfFateService sut = new SupportWheelOfFateService(_dateTimeProvider, _engineerRepository);
        
        [Fact]
        public void WheelOfFortune_Returns_IEnumerableOfShiftWorkers()
        {
            var data = _engineerRepository.GetNamedEngineers();
            data.Should().BeOfType<IEnumerable<ShiftWorker>>();

        }

        [Fact]
        public void IfEmployeeWorkedPreviousDay_Then_EmployeeWontBeAdded()
        {

        }
    }
}
