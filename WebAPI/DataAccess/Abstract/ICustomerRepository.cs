using Core.DataAccess;
using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.CategoryDTOs;
using ETradeService.Base.Concrete.DTOs.CustomerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICustomerRepository: IEntityRepository<Customer>
    {
        public Task AddCustomerAsync(AddCustomerDto addCustomerDto);
    }
}
