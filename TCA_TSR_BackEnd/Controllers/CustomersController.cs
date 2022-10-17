using Microsoft.AspNetCore.Mvc;
using TCA_TSR_BackEnd.Models;
using TCA_TSR_BackEnd.Models.DAO;
using static TCA_TSR_BackEnd.Models.Customer;

namespace TCA_TSR_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController>
        [HttpGet]
        public IActionResult Get()
        {
            Result result = new Result();
            List<Customer> customers = TCATSR_DAO.GetCustomers();
            if (customers != null)
            {
                return Ok(customers);
            }
            else
            {
                result.NumberRecords = 0;
                result.State = 1;
                return Ok(result);
            }
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post([FromBody] CustomerPost customerPost)
        {
            Result result = new Result();
            if (customerPost.CustomerName.Length > 0 && customerPost.Name.Length > 0 && customerPost.RFC.Length > 0
                && customerPost.Street.Length > 0 && customerPost.StreetExt.Length > 0 && customerPost.ZipCode.Length > 0 && customerPost.Suburb.Length > 0
                && customerPost.City_Id > 0 && customerPost.State_Id > 0 && customerPost.CustomerType_Id > 0
                && customerPost.PhoneNumber.Length > 0 && customerPost.Password.Length > 0)
            {
                result = TCATSR_DAO.StoreCustomer(customerPost);
                return Ok(customerPost);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok();
            }
        }

        // PUT api/<CustomersController>/5
        [HttpPut()]
        public IActionResult Put([FromBody] CustomerPut customerPut)
        {
            Result result = new Result();
            if (customerPut.Customer_Id > 0 && customerPut.CustomerName.Length > 0 && customerPut.Name.Length > 0 && customerPut.RFC.Length > 0
                && customerPut.Street.Length > 0 && customerPut.StreetExt.Length > 0 && customerPut.ZipCode.Length > 0 && customerPut.Suburb.Length > 0
                && customerPut.City_Id > 0 && customerPut.State_Id > 0 && customerPut.CustomerType_Id > 0
                && customerPut.PhoneNumber.Length > 0 && customerPut.Email.Length > 0)
            {
                result = TCATSR_DAO.UpdateCustomer(customerPut);
                return Ok(customerPut);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok();
            }
        }

        [HttpPut()]
        public IActionResult PutStatus([FromBody] CustomerPutStatus customerPutStatus)
        {
            Result result = new Result();
            if (customerPutStatus.Customer_Id > 0)
            {
                result = TCATSR_DAO.UpdateCustomerStatus(customerPutStatus);
                return Ok(customerPutStatus);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok();
            }
        }


    }
}
