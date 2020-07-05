using HandsOnTest.Business.Dto;
using HandsOnTest.Data.Models;

namespace HandsOnTest.Business.Factories
{
    public interface IEmployeeFactory
    {
        EmployeeDto Build(Employee employee);
    }
}
