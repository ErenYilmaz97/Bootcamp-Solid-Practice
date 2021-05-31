using System;
using System.Collections.Generic;
using SolidPractice.Business.Abstract;
using SolidPractice.DataAccess.Abstract;
using SolidPractice.Entities.DTOs;
using SolidPractices.Entities.Entities;

namespace SolidPractice.Business.Concrete
{
    public class EmployeeManager : PersonManager, IEmployeeService
    {

        private readonly IEmployeeDal _employeeDal;
        private readonly IAddressDal _addressDal;



        //DEPENDENCY INJECTION
        public EmployeeManager(IEmployeeDal employeeDal, IAddressDal addressDal)
        {
            _employeeDal = employeeDal;
            _addressDal = addressDal;
        }



        public IList<Employee> GetAll()
        {
            return _employeeDal.GetAll();
        }

        public Employee Get(Func<Employee, bool> predicate)
        {
            return _employeeDal.Get(predicate);
        }

        public int Add(AddEmployeeDto addEmployeeDto)
        {
            var findAddress = _addressDal.Get(x => x.Id == addEmployeeDto.AddressId);

            if (findAddress == null)
                return 0;


            var newEmployee = new Employee()
            {
                Name = addEmployeeDto.Name,
                LastName = addEmployeeDto.LastName,
                Gender = addEmployeeDto.Gender,
                AddressId = findAddress.Id,
                DepartmentCode = addEmployeeDto.DepartmentCode,
                DepartmentName = addEmployeeDto.DepartmentName,
                ReportsTo = addEmployeeDto.ReportsTo

            };

            return _employeeDal.Add(newEmployee);
        }
    }
}