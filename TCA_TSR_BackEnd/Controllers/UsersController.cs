using Microsoft.AspNetCore.Mvc;
using TCA_TSR_BackEnd.Models.DAO;
using TCA_TSR_BackEnd.Models;
using static TCA_TSR_BackEnd.Models.User;
using static TCA_TSR_BackEnd.Models.Customer;
using System.Text;
using System.Security.Cryptography;

namespace TCA_TSR_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet("GetUsers")]
        public IActionResult Get()
        {
            Result result = new Result();
            List<User> users = TCATSR_DAO.GetUsers();
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                result.NumberRecords = 0;
                result.State = 1;
                return Ok(result);
            }
        }

        // POST api/<UsersController>
        [HttpPost("CreateUser")]
        public IActionResult Post([FromBody] UserPost user)
        {
            Result result = new Result();
            if(user.UserName.Length > 0 && user.Name.Length > 0 && user.Last_Name.Length > 0 && user.UserType_Id > 0
                && user.Customer_Id > 0 && user.Email.Length > 0 && user.Password.Length > 0 && user.User_Logged.Length > 0)
            {
                result = TCATSR_DAO.StoreUser(user);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok();
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("UpdateUser")]
        public IActionResult Put([FromBody] UserPut user )
        {
            Result result = new Result();
            if (user.User_Id > 0 && user.UserName.Length > 0 && user.Name.Length > 0 && user.Last_Name.Length > 0 && user.UserType_Id > 0
                && user.Customer_Id > 0 && user.Email.Length > 0 && user.User_Logged.Length > 0)
            {
                result = TCATSR_DAO.UpdateUser(user);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok();
            }
        }

        [HttpPut("UserPutState")]
        public IActionResult PutStatus(UserPutStatus userPutStatus)
        {
            Result result = new Result();
            if (userPutStatus.User_Id > 0 && userPutStatus.User_Logged.Length > 0)
            {
                result = TCATSR_DAO.UpdateUserStatus(userPutStatus);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }
        }

       [HttpPost("PostUserLogin")]
        public IActionResult Login(UserLogin us)
        {
            var _password = GetSHA256(us.Password);
            var user = TCATSR_DAO.GetUserLogin(us.UserName, _password);
            Result result = new Result();
            if (user.StatusOut == 1)
            {
                result.Message = user.MessageOut;
                result.State = 1;
                return BadRequest(result);
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPost("LogOut/{User_Id}")]
        public IActionResult LogOut(int User_Id)
        {
            Result result = new Result();
            if(User_Id > 0)
            {
                result = TCATSR_DAO.logOut(User_Id);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }
        }



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
