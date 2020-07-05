using AutoMapper;
using HandsOnTest.Business;
using HandsOnTest.Business.Factories;
using HandsOnTest.Business.Factories.Impl;
using HandsOnTest.Business.Services;
using HandsOnTest.Business.Services.Impl;
using HandsOnTest.Data.Models;
using HandsOnTest.Data.Repositories;
using HandsOnTest.Test.TDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
namespace HandsOnTest.Test
{
    [TestClass]
    public class EmployeeTest
    {
        EmployeeBuilder employeeBuilder;
        IEmployeeFactory employeeFactory;
        IEmployeeRepository employeeRepository;
        IEmployeeService employeeService;

        [TestInitialize]
        public void Initialize()
        {
            employeeBuilder = new EmployeeBuilder();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapping());
            });

            employeeFactory = new EmployeeFactory(mappingConfig.CreateMapper());

            employeeRepository = Substitute.For<IEmployeeRepository>();

            employeeService = new EmployeeService(employeeFactory, employeeRepository);
        }

        [TestMethod]
        public void validateCalculatedAnnualSalaryForHourlyContracts()
        {
            //Arrange
            List<Employee> employees = new List<Employee>
            {
                employeeBuilder
                .Id(1)
                .ContractTypeName("HourlySalaryEmployee")
                .HourlySalary(60000)
                .Build(),
            };
            employeeRepository.FindAll()
                .Returns(employees);
            long expectedResult = 120 * 60000 * 12;
            int employeeId = 1;

            //Act
            var result = employeeService.Find(employeeId);

            //Assert
            Assert.AreEqual(expectedResult, result.AnnualSalary);
        }

        [TestMethod]
        public void ValidateCalculatedAnnualSalaryForMonthlyContracts()
        {
            //Arrange
            List<Employee> employees = new List<Employee>
            {
                employeeBuilder
                .Id(2)
                .ContractTypeName("MonthlySalaryEmployee")
                .MonthlySalary(80000)
                .Build()
            };
            employeeRepository.FindAll()
                .Returns(employees);
            long expectedResult = 80000 * 12;
            int employeeId = 2;
            
            //Act
            var result = employeeService.Find(employeeId);

            //Assert
            Assert.AreEqual(expectedResult, result.AnnualSalary);
        }
    }
}
