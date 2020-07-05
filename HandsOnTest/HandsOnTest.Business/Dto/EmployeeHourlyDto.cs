using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnTest.Business.Dto
{
    public class EmployeeHourlyDto : EmployeeDto
    {
        public override long AnnualSalary 
        {
            get 
            {
                return 120 * HourlySalary *  12;
            }
        }
    }
}
