using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.CategoryDTOs;
using ETradeService.Base.Concrete.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        Customer GetByName(string name);
        void DeleteById(int id);
        public Task AddCustomerAsync(AddCustomerDto addCustomerDto);
        //void Add(Customer customer);
    }
}
