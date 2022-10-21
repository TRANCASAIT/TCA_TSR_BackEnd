using Microsoft.AspNetCore.Mvc;
using TCA_TSR_BackEnd.Models;
using TCA_TSR_BackEnd.Models.DAO;

namespace TCA_TSR_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerTypesController : ControllerBase
    {

        // GET: api/<CustomerTypesController>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    Result result = new Result();
        //    List<CustomerType> customerTypes = TCATSR_DAO.GetCustomerTypes();
        //    if(customerTypes != null)
        //    {
        //        return Ok(customerTypes);
        //    }
        //    else
        //    {
        //        result.State = 1;
        //        result.NumberRecords = 0;
        //        return Ok(result);
        //    }
        //}

        //// POST api/<CustomerTypesController>
        //[HttpPost]
        //public IActionResult Post([FromBody] CustomerTypePost customer)
        //{
        //    Result result = new Result();
        //    if(customer.CustomerType_Name.Length > 0 && customer.User_Logged.Length > 0)
        //    {
        //        result = TCATSR_DAO.StoreCustomerType(customer);
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        result.State = 1;
        //        result.Message = "Verifique los datos";
        //        return Ok(result);
        //    }
        //}

        //// PUT api/<CustomerTypesController>/5
        //[HttpPut]
        //public IActionResult Put([FromBody] CustomerTypePut customerTypePut)
        //{
        //    Result result = new Result();
        //    if(customerTypePut.CustomerType_Name.Length > 0 && customerTypePut.CustomerType_Id > 0 && customerTypePut.User_Logged.Length > 0)
        //    {
        //        result = TCATSR_DAO.UpdateCustomerType(customerTypePut);
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        result.Message = "Verifique los datos";
        //        result.State = 1;
        //        return Ok(result);
        //    }
        //}
    }
}
