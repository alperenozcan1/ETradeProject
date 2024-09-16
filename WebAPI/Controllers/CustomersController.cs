using Business.Abstract;
using Entities.Concrete;
using ETradeService.Base.Concrete.DTOs.CategoryDTOs;
using ETradeService.Base.Concrete.DTOs.CustomerDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETradeService.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        [Route("getall")]
        public List<Customer> GetAll()
        {
            return _customerService.GetAll();
        }
        [HttpPost]
        [Route("add")]
        public async Task AddCustomerAsync(AddCustomerDto addCustomerDto)
        {
            await _customerService.AddCustomerAsync(addCustomerDto);
        }
        //[HttpPost]
        //public void Add(Customer customer)
        //{
        //    _customerService.Add(customer);
        //}
        [HttpDelete]
        [Route("delete")]
        public void DeleteById(int id)
        { 
            _customerService.DeleteById(id);
        }
    }
}
