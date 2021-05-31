using System;
using System.Collections.Generic;
using SolidPractice.Business.Abstract;
using SolidPractice.DataAccess.Abstract;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.Business.Concrete
{
    public class CustomerManager : PersonManager, ICustomerService
    {

        private readonly ICustomerDal _customerDal;
        private readonly IAddressDal _addressDal;


        //DEPENDENCY INJECTION
        public CustomerManager(ICustomerDal customerDal, IAddressDal addressDal)
        {
            _customerDal = customerDal;
            _addressDal = addressDal;
        }



        public IList<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }



        public Customer Get(Func<Customer, bool> predicate)
        {
            return _customerDal.Get(predicate);
        }



        public int Add(AddCustomerDto addCustomerDto)
        {
            var findAddress = _addressDal.Get(x => x.Id == addCustomerDto.AddressId);

            if (findAddress == null)
                return 0;


            var newCustomer = new Customer()
            {
                Name = addCustomerDto.Name,
                LastName = addCustomerDto.LastName,
                Gender = addCustomerDto.Gender,
                AddressId = findAddress.Id,
                CustomerType = addCustomerDto.CustomerType,
            };

            return _customerDal.Add(newCustomer);
        }



        public int Remove(int customerId)
        {
            var findCustomer = _customerDal.Get(x => x.Id == customerId);

            if (findCustomer == null)
            {
                //SİLİNMEK İSTENEN MÜŞTERİ MEVCUT DEĞİL
                return 0;
            }

            return _customerDal.Remove(findCustomer);
        }
    }
}