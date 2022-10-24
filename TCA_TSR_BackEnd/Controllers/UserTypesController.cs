using Microsoft.AspNetCore.Mvc;
using TCA_TSR_BackEnd.Models;
using TCA_TSR_BackEnd.Models.DAO;

namespace TCA_TSR_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypesController : ControllerBase
    {
        // GET: api/<UserTypesController>
        [HttpGet("GetUserTypes")]
        public IActionResult Get()
        {
            Result result = new Result();
            List<UserType> userTypes = TCATSR_DAO.GetUserTypes();
            if(userTypes != null)
            {
                return Ok(userTypes);
            }
            else
            {
                result.NumberRecords = 0;
                result.State = 1;
                return Ok(result);
            }
        }

        // POST api/<UserTypesController>
        [HttpPost("CreateUserType")]
        public IActionResult Post([FromBody] UserTypePost userTypePost)
        {
            Result result = new Result();
            if(userTypePost.UserType_Name.Length > 0 && userTypePost.User_Logged.Length > 0)
            {
                result = TCATSR_DAO.StoreUserType(userTypePost);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }

        }

        // PUT api/<UserTypesController>/5
        [HttpPut("UpdateUserType")]
        public IActionResult Put([FromBody] UserTypePut userTypePut)
        {
            Result result = new Result();
            if(userTypePut.UserType_Name.Length > 0 && userTypePut.User_Logged.Length > 0 && userTypePut.UserType_Id > 0)
            {
                result = TCATSR_DAO.UpdateUserType(userTypePut);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }
        }
    }
}
