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
    public class AddressesController : ControllerBase
    {

        private readonly IAddressService _addressService;

        public AddressesController(IAddressService addressService)
        {
            _addressService = addressService;
        }



        [HttpPost]
        public IActionResult AddAddress(AddAddressDto addressDto)
        {
            var affectedRows = _addressService.Add(addressDto);

            if (affectedRows == 0)
            {
                return BadRequest("Adres Eklenemedi.");
            }

            return Ok($"{affectedRows} Adet Adres Eklendi.");
        }


    }
}
