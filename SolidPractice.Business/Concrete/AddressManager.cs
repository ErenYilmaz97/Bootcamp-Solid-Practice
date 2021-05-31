using System;
using System.Collections.Generic;
using SolidPractice.Business.Abstract;
using SolidPractice.DataAccess.Abstract;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.Business.Concrete
{
    public class AddressManager :  IAddressService
    {

        private readonly IAddressDal _addressDal;

        //DEPENDENCY INJECTION
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }



        public IList<Address> GetAll()
        {
            return _addressDal.GetAll();
        }



        public Address Get(Func<Address, bool> predicate)
        {
            return _addressDal.Get(predicate);
        }

        public int Add(AddAddressDto addressDto)
        {
            var newAddress = new Address(){Country = addressDto.Country, City = addressDto.City, PostCode = addressDto.PostCode};
            return _addressDal.Add(newAddress);
        }
    }
}