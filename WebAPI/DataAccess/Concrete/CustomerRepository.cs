using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Contexts;
using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.CategoryDTOs;
using ETradeService.Base.Concrete.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class CustomerRepository : EfRepositoryBase<Customer, PostgreContext>, ICustomerRepository
    {
        public async Task AddCustomerAsync(AddCustomerDto addCustomerDto)
        {
            using (PostgreContext context = new PostgreContext())
            {
                var customer = new Customer
                {
                    CustomerName = addCustomerDto.CustomerName,

                };
                context.Customers.Add(customer);
                await context.SaveChangesAsync();
            }
        }
    }
}
