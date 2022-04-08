
using System;
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
        private static IEngineerRepository _engineerRepository = new InMemoryEngineerRepository();
        private static ISupportTeam _team = new SupportTeamService(); 
        private SupportWheelOfFateService sut = new(_dateTimeProvider, _engineerRepository, _team);
        
        [Fact]
        public void WheelOfFortune_Returns_2ShiftWorkers()
        {
            var workers = sut.WhoGoesToday();
            workers.Result.Should().HaveCount(2);
            workers.Result.Should().AllBeOfType(typeof(ShiftWorker));   
        }

        [Fact]
        public void ShiftWorkersLastShift_ShouldBe_Today()
        {
            var workers = sut.WhoGoesToday();
            foreach (var shiftWorker in workers.Result)
            {
                shiftWorker.LastShift.Should().BeExactly(DateTimeOffset.UtcNow.Date);
            }
        }
    }
}
