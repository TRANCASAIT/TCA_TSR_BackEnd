using Microsoft.AspNetCore.Mvc;
using TCA_TSR_BackEnd.Models;
using TCA_TSR_BackEnd.Models.DAO;

namespace TCA_TSR_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationTypesController : ControllerBase
    {
        // GET: api/<OperationTypesController>
        [HttpGet]
        public IActionResult Get()
        {
            List<OperationType> operationTypes = TCATSR_DAO.GetOperationTypes();
            if(operationTypes != null)
            {
                return Ok(operationTypes);
            }
            else
            {
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
        }


        // POST api/<OperationTypesController>
        [HttpPost]
        public IActionResult Post([FromBody] OperationTypePost operationTypePost)
        {
            Result result = new Result();
            if(operationTypePost.OperationType_Name.Length > 0 && operationTypePost.User_Logged.Length > 0 )
            {
                result = TCATSR_DAO.StoreOperationType(operationTypePost);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }
        }

        // PUT api/<OperationTypesController>/5
        [HttpPut]
        public IActionResult Put([FromBody] OperationTypePut operationTypePut)
        {
            Result result = new Result();
            if (operationTypePut.OperationType_Id > 0 && operationTypePut.OperationType_Name.Length > 0 && operationTypePut.User_Logged.Length > 0 )
            {
                result = TCATSR_DAO.UpdateOperationType(operationTypePut);
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
