using System;
using System.Collections.Generic;
using System.Text;
using HandsOnTest.Business.Dto;

namespace HandsOnTest.Business.Services
{
    public interface IEmployeeService
    {
        EmployeeDto Find(int id);
        List<EmployeeDto> FindAll();
    }
}
