using HandsOnTest.Data.Models;
using System.Collections.Generic;

namespace HandsOnTest.Data.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> FindAll();
    }
}
