using Microsoft.AspNetCore.Mvc;
using TCA_TSR_BackEnd.Models;
using TCA_TSR_BackEnd.Models.DAO;

namespace TCA_TSR_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        // GET: api/<StatesController>
        [HttpGet("GetStates")]
        public IActionResult GetStates()
        {
            List<State> states = TCATSR_DAO.GetStates();
            if(states != null)
            {
                return Ok(states);
            }
            else
            {
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
        }

        // POST api/<StatesController>
        [HttpPost("CreateState")]
        public IActionResult Post([FromBody] StatePost _state)
        {
            Result result = new Result();
            if(_state.State_Name.Length > 0 && _state.User_Logged.Length > 0)
            {
                result = TCATSR_DAO.StoreState(_state);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }
        }

        // PUT api/<StatesController>/5
        [HttpPut("UpdateState")]
        public IActionResult UpdateState([FromBody] StatePut statePut)
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
