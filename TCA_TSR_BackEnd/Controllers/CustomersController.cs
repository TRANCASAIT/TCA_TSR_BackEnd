using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using TCA_TSR_BackEnd.Models;
using TCA_TSR_BackEnd.Models.DAO;
using static TCA_TSR_BackEnd.Models.Customer;
using static TCA_TSR_BackEnd.Models.User;

namespace TCA_TSR_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController>
        [HttpGet("GetCustomers")]
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
        [HttpPost("CreateCustomer")]
        public IActionResult Post([FromBody] CustomerPost customerPost)
        {
            Result result = new Result();
            if (customerPost.Name.Length > 0 && customerPost.RFC.Length > 0
                && customerPost.Street.Length > 0 && customerPost.StreetExt.Length > 0 && customerPost.ZipCode.Length > 0 && customerPost.Suburb.Length > 0
                && customerPost.City_Id > 0 && customerPost.State_Id > 0 && customerPost.Email.Length > 0
                && customerPost.PhoneNumber.Length > 0)
            {
                result = TCATSR_DAO.StoreCustomer(customerPost);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok();
            }
        }

        // PUT api/<CustomersController>/5
        [HttpPut("UpdateCustomer")]
        public IActionResult Put([FromBody] CustomerPut customerPut)
        {
            Result result = new Result();
            if (customerPut.Customer_Id > 0 && customerPut.Name.Length > 0 && customerPut.RFC.Length > 0
                && customerPut.Street.Length > 0 && customerPut.StreetExt.Length > 0 && customerPut.ZipCode.Length > 0 && customerPut.Suburb.Length > 0
                && customerPut.City_Id > 0 && customerPut.State_Id > 0 && customerPut.Email.Length > 0
                && customerPut.PhoneNumber.Length > 0 && customerPut.Email.Length > 0)
            {
                result = TCATSR_DAO.UpdateCustomer(customerPut);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok();
            }
        }

        [HttpPut("CustomerPutState")]
        public IActionResult PutStatus([FromBody] CustomerPutStatus customerPutStatus)
        {
            Result result = new Result();
            if (customerPutStatus.Customer_Id > 0)
            {
                result = TCATSR_DAO.UpdateCustomerStatus(customerPutStatus);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok();
            }
        }


        //[HttpPost("PostCustomerLogin")]
        //public IActionResult Login(CustomerLogin us)
        //{
        //    var _password = GetSHA256(us.Password);
        //    var user = TCATSR_DAO.GetCustomerLogin(us.Customer, _password);
        //    Result result = new Result();
        //    if (user == null || user.Customer_Id == 0)
        //    {

        //        result.State = 404;
        //        result.Message = "Credeciales de acceso invalidas, verifique.";
        //        result.Identificador = 1;
        //        return NotFound(result);
        //    }
        //    else if (user.Status == false)
        //    {
        //        result.State = 404;
        //        result.Message = "Usuario deshabilitado, favor de contactar al departamento de sistemas";
        //        result.Identificador = 2;
        //        return NotFound(result);
        //    }
        //    else
        //    {
        //        return Ok(user);
        //    }
        //}

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}
