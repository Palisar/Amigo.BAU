using Amigo.BAU.Application.Services;
using System;

namespace Amigo.BAU.Application.Tests
{
    public class DateTimeProviderTests
    {
        private static DateTimeOffset _date = DateTimeOffset.UtcNow;
        [Fact]
        public void WhenCalenderIsCreated_DateShouldBeToday()
        {
            DateTimeProvider sut = new DateTimeProvider();
            var result = sut.TodaysDate.Date;
            result.Should().Be(DateTimeOffset.UtcNow.Date);
        }

        [Fact]
        public void WhenDayChanges_Then_DayUpdatesReturnsNow()
        {
            // Arrange
            _date = DateTimeOffset.MinValue;
            DateTimeProvider sut = new DateTimeProvider();

            //Act
            var result = sut.GetDay();

            //Assert
            result.Should().Be(DateTimeOffset.UtcNow.Date);
        }

        [Fact]
        public void IfDayDoesNotChange_Then_ReturnNow()
        {
            // Arrange
            DateTimeProvider sut = new DateTimeProvider();

            //Act
            var result = sut.GetDay();

            //Assert
            result.Should().Be(DateTimeOffset.UtcNow.Date);
        }
    }
}
