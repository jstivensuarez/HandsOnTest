using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnTest.Business.Dto
{
    public class EmployeeMonthlyDto : EmployeeDto
    {
        public override long AnnualSalary
        {
            get
            {
                return MonthlySalary * 12;
            }
        }
    }
}
