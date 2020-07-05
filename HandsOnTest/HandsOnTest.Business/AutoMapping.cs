using AutoMapper;
using HandsOnTest.Business.Dto;
using HandsOnTest.Data.Models;

namespace HandsOnTest.Business
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Employee, EmployeeHourlyDto>();
            CreateMap<Employee, EmployeeMonthlyDto>();
        }
    }
}
