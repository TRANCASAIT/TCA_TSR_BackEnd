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
        [HttpGet]
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
        [HttpPost]
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
        [HttpPut]
        public IActionResult Put([FromBody] StatePut statePut)
        {
            Result result = new Result();
            if(statePut.State_Id > 0 && statePut.State_Name.Length > 0 && statePut.User_Logged.Length > 0)
            {
                result = TCATSR_DAO.UpdateState(statePut);
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
