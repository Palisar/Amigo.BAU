﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AmigoBAU.Tests
{
    public class SomeClassTests
    {
        [Fact]
        public void Some_Method_Test_Then_Returns_Expected_Result()
        {
            // Arrange

            //Act

            //Assert
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
