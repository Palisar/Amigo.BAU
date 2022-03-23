using System.Diagnostics;
using Amigo.BAU.Application.Models;

namespace Amigo.BAU.Application
{
    public class WorkCalender
    {
        private static DateTimeOffset TodaysDate;
        private static int Day;

        public WorkCalender()
        {
            Day = 1;
            TodaysDate = DateTimeOffset.UtcNow.Date;
        }

        public int WhatDayAreWeOn()
        {
            if (DateTime.UtcNow.Date > TodaysDate)
                NextDay();

            return Day;
        }
        private void NextDay()
        {
            Day++;
            TodaysDate = DateTimeOffset.UtcNow.Date;
        }
        
    }
}
