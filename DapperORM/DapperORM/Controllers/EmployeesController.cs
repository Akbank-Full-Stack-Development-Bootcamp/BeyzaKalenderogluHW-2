using DapperORM.Models;
using DapperORM.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperORM.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeService service;

        
        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = service.GetEmployees();
            return Ok(employees);
        }

        [HttpPut("{id}")]
        public void Update(int id,[FromBody]Employee employee)
        {
            employee.Id = id;
            service.Update(employee);
        }

        [HttpPost]
        public void Create([FromBody] Employee employee)
        {
            service.Create(employee);
        }

        [HttpDelete]
        public void Delete(int id, [FromBody] Employee employee)
        {
            employee.Id = id;
            service.Delete(employee);
        }
    }
}
