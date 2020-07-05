using AutoMapper;
using HandsOnTest.Business.Dto;
using HandsOnTest.Data.Models;
namespace HandsOnTest.Business.Factories.Impl
{
    public class EmployeeFactory : IEmployeeFactory
    {
        private readonly IMapper mapper;
        public EmployeeFactory(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public EmployeeDto Build(Employee employee)
        {
            EmployeeDto result = null;
            switch (employee.ContractTypeName)
            {
                case "HourlySalaryEmployee": 
                    result = mapper.Map<EmployeeHourlyDto>(employee);
                    break;
                case "MonthlySalaryEmployee":
                    result = mapper.Map<EmployeeMonthlyDto>(employee);
                    break;

            }
            return result;
        }
    }
}
