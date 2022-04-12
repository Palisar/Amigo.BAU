using Amigo.BAU.Application.Interfaces;
using Amigo.BAU.Application.Services;
using Amigo.BAU.Persistance.QueryModels;
using Amigo.BAU.Repository.EngineerRepository;
using Amigo.BAU.Repository.Interfaces;
using Amigo.BAU.Repository.UnitOfWork;
using System.Data.Common;
using System.Data.SqlClient;

namespace AmigoBAU.Tests.ConsoleTests
{
    public class SupportWheelOfFateTests
    {

        private static IDateTimeProvider _date = new DateTimeProvider();
        private static IEngineerRepository _engineerRepository = new InMemoryEngineerRepository();
        private static ISupportTeam _team = new SupportTeam(_date);

        private static DbConnection sql = new SqlConnection("Data Source=DESKTOP-88PT757\\SQLEXPRESS;Initial Catalog=AmigoDb;Trusted_Connection=True;");
        private static IUnitOfWork _unitOfWork = new UnitOfWork(sql, _engineerRepository);
        private SupportWheelOfFateService sut = new(_date, _team, _unitOfWork);

        [Fact]
        public async void WheelOfFortune_Returns_2ShiftWorkers_And_UpdatesSupportTeamStaff()
        {
            var workers = await sut.WhoGoesToday();
            workers.Should().HaveCount(2);
            workers.Should().AllBeOfType(typeof(ShiftWorker));
        }

        [Fact]
        public async void WhoGoesToday_Updates_SupportTeamStaff()
        {
            var workers = await sut.WhoGoesToday();
            _team.Staff.Should().BeEquivalentTo(workers);
        }
        
    }
}
