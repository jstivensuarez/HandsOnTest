using HandsOnTest.Data.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace HandsOnTest.Data.Repositories.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IHttpRequestTemplate httpRequestTemplate;
        private readonly Configuration.Configuration configuration;

        public EmployeeRepository(IHttpRequestTemplate httpRequestTemplate, IOptions<Configuration.Configuration> options)
        {
            this.httpRequestTemplate = httpRequestTemplate;
            this.configuration = options.Value;
        }

        public List<Employee> FindAll()
        {
            string path = $"{configuration.Host.Masglobal}{configuration.Path.Employees}";
            return httpRequestTemplate.Get<List<Employee>>(path);
        }
    }
}
