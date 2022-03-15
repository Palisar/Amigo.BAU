using EmployeeWheelOfFortune.Console;
namespace AmigoBAU.Tests.ConsoleTests
{
    public class WheelOfFortuneTests
    {
        private static IEmployeeRepository _employeeRepository = new InMemoryEmployeeDatabase();
        private static WheelOfFortune sut = new WheelOfFortune(_employeeRepository);

        [Fact]
        public void WheelOfFortune_Returns_2Employees()
        {
            var data = _employeeRepository.GetAllEmployees();
            var actual = sut.WhoGoesToday(2);
            foreach (var employee in actual)
            {
                actual.Should().BeOfType<Employee[]>();
            }
            actual.Should().NotBeNull();
        }

        [Fact]
        public void IfEmployeeWorkedPreviousDay_Then_EmployeeWontBeAdded()
        {

        }
    }
}
