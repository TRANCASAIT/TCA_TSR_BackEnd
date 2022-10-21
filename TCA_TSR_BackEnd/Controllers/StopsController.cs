using Microsoft.AspNetCore.Mvc;
using TCA_TSR_BackEnd.Models;
using TCA_TSR_BackEnd.Models.DAO;

namespace TCA_TSR_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopsController : ControllerBase
    {
        // GET: api/<StopsController>
        [HttpGet("GetStops")]
        public IActionResult Get()
        {
            Result result = new Result();
            List<Stops> stops = TCATSR_DAO.GetStops();
            if(stops != null)
            {
                return Ok(stops);
            }
            else
            {
                result.State = 1;
                result.NumberRecords = 0;
                return Ok();
            }
        }

        // POST api/<StopsController>
        [HttpPost]
        public IActionResult Post([FromBody] StopsPost stopsPost)
        {
            Result result = new Result();
            if(stopsPost.Stop_Number.Length > 0 && stopsPost.User_Logged.Length > 0)
            {
                result = TCATSR_DAO.StoreStop(stopsPost);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }

        }

        // PUT api/<StopsController>/5
        [HttpPut]
        public IActionResult Put([FromBody] StopsPut stopsPut)
        {

            Result result = new Result();
            if (stopsPut.Stop_Number.Length > 0 && stopsPut.User_Logged.Length > 0 && stopsPut.Stop_Id > 0)
            {
                result = TCATSR_DAO.UpdateStop(stopsPut);
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
