using System.Net;

namespace InterfaceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = new IEmployee[3];

            employees[0] = new SalaryGuy { Name = "John", MonthlyWage = 4000 };
            employees[1] = new HourlyConsultant { Name = "Wesley", HourlyWage = 110M, NrOfHoursPerWeek = 30 };
            employees[2] = new HourlyConsultant { Name = "Jane", HourlyWage = 130M, NrOfHoursPerWeek = 20 };

            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Name} makes EUR {employee.CalculateMonthlyPay()}/month");
            }
        }
    }
}
