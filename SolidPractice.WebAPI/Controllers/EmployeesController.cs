using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolidPractice.Business.Abstract;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;


        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var affectedRows = _employeeService.Add(addEmployeeDto);

            if (affectedRows == 0)
                return BadRequest("Personel Eklenemedi.");

            return Ok($"{affectedRows} Adet Personel Eklendi.");
        }
    }
}
