using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerRepository _customerRepository;

        public CustomerManager(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddCustomerAsync(AddCustomerDto addCustomerDto)
        {
            if (addCustomerDto.CustomerName.Length < 3)
            {
                throw new Exception("Customer name must be at least 3 characters");
            }
            else if (addCustomerDto.CustomerPhone.Length != 10)
            {
                throw new Exception("Invalid Phone Number");
            }
            await _customerRepository.AddCustomerAsync(addCustomerDto);
        }

        public void DeleteById(int id)
        {
            _customerRepository.Delete(GetById(id));
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerRepository.Get(c=>c.Id == id);
        }

        public Customer GetByName(string name)
        {
            return _customerRepository.Get(c => c.CustomerName == name);
        }
    }
}
