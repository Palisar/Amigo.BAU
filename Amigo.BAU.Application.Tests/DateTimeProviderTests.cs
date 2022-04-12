using Amigo.BAU.Application.Services;
using System;

namespace Amigo.BAU.Application.Tests
{
    public class DateTimeProviderTests
    {
        DateTimeProvider sut = new();

        [Fact]
        public void WhenServiceIsCreated_DateShouldBeYesterday()
        {

            var result = sut.TodaysDate.Date;
            result.Should().Be(DateTimeOffset.UtcNow.AddDays(-1).Date);
        }

        [Fact]
        public void WhenDayChanges_Then_DayUpdatesReturnsNow()
        {
            sut.GetDay();
            sut.DayChanged.Should().BeTrue();
        }

        [Fact]
        public void IfDayDoesNotChange_Then_DayChangeIsFalse()
        {

            sut.GetDay();
            sut.DayChanged.Should().BeTrue();
            var result = sut.GetDay();

            result.Should().Be(DateTimeOffset.UtcNow.Date);
            sut.DayChanged.Should().BeFalse();
        }
    }
}
