using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAngularNETCORE.Models;
using DemoAngularNETCORE.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoAngularNETCORE.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataRepository<Employee> _dataRepository;

        public DataController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Employee> employees = _dataRepository.GetAll();
            return Ok(employees);
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Employee employee = _dataRepository.Get(id);

            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost("create")]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }

            _dataRepository.Add(employee);
            return CreatedAtRoute(
                  "Get",
                  new { Id = employee.EmployeeId },
                  employee);
        }

        // PUT: api/Employee/5
        [HttpPut("update/{id}")]
        public IActionResult Put(long id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }

            Employee employeeToUpdate = _dataRepository.Get(id);
            if (employeeToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Update(employeeToUpdate, employee);
            return Ok(employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(long id)
        {
            Employee employee = _dataRepository.Get(id);
            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }

            _dataRepository.Delete(employee);
            return Ok(employee);
        }
    }
}
