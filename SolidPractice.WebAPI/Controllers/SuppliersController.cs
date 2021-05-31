using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolidPractice.Business.Abstract;
using SolidPractice.Entities.DTOs;

namespace SolidPractice.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {

        private readonly ISupplierService _supplierService;


        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }



        [HttpPost]
        public IActionResult AddSupplier(AddSupplierDto addSupplierDto)
        {
            var affectedRows = _supplierService.Add(addSupplierDto);

            if (affectedRows == 0)
                return BadRequest("Tedarikçi Eklenemedi.");

            return Ok($"{affectedRows} Adet Tedarikçi Eklendi.");
        }
    }
}
