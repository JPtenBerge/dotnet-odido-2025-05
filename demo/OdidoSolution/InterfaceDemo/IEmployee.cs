using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo;

interface IEmployee
{
    string Name { get; set; }

    decimal CalculateMonthlyPay();
}

// "class A extends class B"
// "class A implements interface B"
// "interface A extends interface B"

class SalaryGuy : IEmployee
{
    public string Name { get; set; }
    public decimal MonthlyWage { get; set; }

    public decimal CalculateMonthlyPay()
    {
        return MonthlyWage;
    }
}

class HourlyConsultant : IEmployee
{
    public string Name { get; set; }
    public decimal HourlyWage { get; set; }
    public int NrOfHoursPerWeek { get; set; }

    public decimal CalculateMonthlyPay()
    {
        return HourlyWage * NrOfHoursPerWeek * 4.5M;
    }
}
