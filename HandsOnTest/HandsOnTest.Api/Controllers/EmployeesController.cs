using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HandsOnTest.Business.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HandsOnTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(employeeService.FindAll());
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(employeeService.Find(id));
        }    
    }
}
