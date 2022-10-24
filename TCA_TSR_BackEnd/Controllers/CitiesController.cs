using Microsoft.AspNetCore.Mvc;
using TCA_TSR_BackEnd.Models;
using TCA_TSR_BackEnd.Models.DAO;

namespace TCA_TSR_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        // GET: api/<CitiesController>
        [HttpGet("GetCities")]
        public IActionResult Get()
        {
            Result result = new Result();
            List<City> cities = TCATSR_DAO.GetCities();
            if(cities != null)
            {
                return Ok(cities);
            }
            else
            {
                result.NumberRecords = 0;
                result.State = 1;
                return Ok(result);
            }
        }

        // POST api/<CitiesController>
        [HttpPost("CreateCity")]
        public IActionResult Post([FromBody] CityPost cityPost)
        {
            Result result = new Result();
            if(cityPost.City_Name.Length > 0 && cityPost.User_Logged.Length > 0 && cityPost.State_Id > 0)
            {
                result = TCATSR_DAO.StoreCity(cityPost);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok();
            }
        }

        // PUT api/<CitiesController>/5
        [HttpPut("UpdateCity")]
        public IActionResult Put([FromBody] CityPut cityPut)
        {
            Result result = new Result();
            if (cityPut.City_Name.Length > 0 && cityPut.User_Logged.Length > 0 && cityPut.State_Id > 0 && cityPut.City_Id > 0)
            {
                result = TCATSR_DAO.UpdateCity(cityPut);
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
