using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static TCA_TSR_BackEnd.Models.User;
using TCA_TSR_BackEnd.Models.DAO;
using TCA_TSR_BackEnd.Models;

namespace TCA_TSR_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        // POST api/<UsersController>
        [HttpPost("ResetPassword")]
        public IActionResult ResetPass([FromBody] ResetPassword rp)
        {
            Result result = new Result();
            if (rp.Email.Length > 0 && rp.OldPassword.Length > 0 && rp.NewPassword.Length > 0 )
            {
                result = TCATSR_DAO.ResetPassword(rp);
                return Ok(result);
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
