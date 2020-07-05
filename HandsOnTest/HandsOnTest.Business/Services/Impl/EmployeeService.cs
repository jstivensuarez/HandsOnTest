using AutoMapper;
using HandsOnTest.Business.Dto;
using HandsOnTest.Business.Factories;
using HandsOnTest.Data.Models;
using HandsOnTest.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace HandsOnTest.Business.Services.Impl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeFactory employeeFactory;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(
            IEmployeeFactory employeeFactory,
            IEmployeeRepository employeeRepository)
        {
            this.employeeFactory = employeeFactory;
            this.employeeRepository = employeeRepository;
        }

        public EmployeeDto Find(int id)
        {
            List<EmployeeDto> employees = FindAll();
            return employees.Find(e => e.Id == id);
        }

        public List<EmployeeDto> FindAll()
        {
            List<Employee> employees = employeeRepository.FindAll();
            return employees.Select(e => employeeFactory.Build(e)).ToList();
        }
    }
}
