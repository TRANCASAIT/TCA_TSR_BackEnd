using Microsoft.AspNetCore.Mvc;
using TCA_TSR_BackEnd.Models;
using TCA_TSR_BackEnd.Models.DAO;

namespace TCA_TSR_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        // GET: api/<StatusController>
        [HttpGet("GetStatuses")]
        public IActionResult Get()
        {
            Result result = new Result();
            List<Status> status = TCATSR_DAO.GetStatus();
            if(status != null)
            {
                return Ok(status);
            }
            else
            {
                result.State = 1;
                result.NumberRecords = 0;
                return Ok(result);
            }

        }

        // POST api/<StatusController>
        [HttpPost("CreateStatus")]
        public IActionResult Post([FromBody] StatusPost statusPost)
        {
            Result result = new Result();
            if(statusPost.Status_Description.Length > 0 && statusPost.User_Logged.Length > 0)
            {
                result = TCATSR_DAO.StoreStatus(statusPost);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }
        }

        // PUT api/<StatusController>/5
        [HttpPut("UpdateStatus")]
        public IActionResult Put([FromBody] StatusPut statusPut)
        {
            Result result = new Result();
            if(statusPut.Status_Id > 0 && statusPut.Status_Description.Length > 0 && statusPut.User_Logged.Length > 0)
            {
                result = TCATSR_DAO.UpdateStatus(statusPut);
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
