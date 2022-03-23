using System.Runtime.InteropServices.ComTypes;

namespace Amigo.BAU.Application.Tests
{
    public class ScheduleTests
    {
        private WorkCalender sut = new WorkCalender();

        [Theory]
        [InlineData(2,3)]
        [InlineData(6, 7)]
        [InlineData(15, 16)]
        public void NextDayIsCalled_Then_DayShouldIncrease(int numberOfDays, int result)
        {
            for (int i = 0; i < numberOfDays; i++)
            {
                sut.NextDay();
            }

            sut.WhatDayAreWeOn().Should().Be(result);
        }

        [Theory]
        [InlineData(10, "2")]
        public void Thoery_Method_Check_Multiple_Cases_Then_Expected_result(int someVar, string expectedResult)
        {
            // Arrange

            //Act

            //Assert
        }
    }
}
