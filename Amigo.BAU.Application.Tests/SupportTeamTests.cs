using Amigo.BAU.Application.Services;
using Amigo.BAU.Persistance.QueryModels;
using System;
using System.Collections.Generic;

namespace Amigo.BAU.Application.Tests
{
    public class SupportTeamTests
    {
        private static DateTimeProvider date = new();
        private List<ShiftWorker> testData = new List<ShiftWorker>()
        {
            new ShiftWorker
            {
                Name = "Paul",
                Email = "Paul@mail.com",
                EngineerId = 1,
                FirstShift = DateTimeOffset.UtcNow.AddDays(-3).Date,
                LastShift = DateTimeOffset.UtcNow.AddDays(-3).Date,
                ShiftCount = 1
            },
            new ShiftWorker
            {
                Name = "Rae",
                Email = "Rae@mail.com",
                EngineerId = 2,
                FirstShift = null,
                LastShift = null,
                ShiftCount = 0
            },
        };

        [Fact]
        public void ConfirmTodaysStaff_Then_IsConfirmedTodayIsTrue()
        {
            var moq = new Mock<SupportTeam>(date);
            moq.Object.Staff = testData;
            var sut = moq.Object;

            sut.ConfirmTodaysStaff();

            sut.IsConfirmedToday.Should().BeTrue();
        }

        [Fact]
        public void WhenResetStaffIsCalled_Then_IsConfirmedTodayIsFalsse()
        {
            var moq = new Mock<SupportTeam>(date);
            moq.Object.Staff = testData;
            var sut = moq.Object;

            sut.ConfirmTodaysStaff();
            sut.ResetStaff();

            sut.IsConfirmedToday.Should().BeFalse();
        }

        [Fact]
        public void WhenConfirmTodaysStaffIsCalled_Then_StaffAreUpdated()
        {
            var moq = new Mock<SupportTeam>(date);
            moq.Object.Staff = testData;
            var sutMock = moq.Object;

            sutMock.ConfirmTodaysStaff();

            foreach (var shiftWorker in sutMock.Staff)
            {
                shiftWorker.LastShift.Should().Be(DateTimeOffset.UtcNow.Date);
            }

        }
    }
}
