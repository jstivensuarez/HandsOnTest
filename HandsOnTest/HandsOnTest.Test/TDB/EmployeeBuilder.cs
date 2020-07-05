using HandsOnTest.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnTest.Test.TDB
{
    public class EmployeeBuilder
    {
        private Employee employee = new Employee();

        public EmployeeBuilder Id(int id)
        {
            employee.Id = id;
            return this;
        }

        public EmployeeBuilder HourlySalary(long hourlySalary)
        {
            employee.HourlySalary = hourlySalary;
            return this;
        }

        public EmployeeBuilder MonthlySalary(long monthlySalary)
        {
            employee.MonthlySalary = monthlySalary;
            return this;
        }

        public EmployeeBuilder ContractTypeName(string typeName)
        {
            employee.ContractTypeName = typeName;
            return this;
        }

        public Employee Build()
        {
            return employee;
        }
    }
}
