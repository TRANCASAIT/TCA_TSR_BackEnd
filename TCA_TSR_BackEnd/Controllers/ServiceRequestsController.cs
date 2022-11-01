using Microsoft.AspNetCore.Mvc;
using TCA_TSR_BackEnd.Models.DAO;
using TCA_TSR_BackEnd.Models;
using static TCA_TSR_BackEnd.Models.ServiceRequest;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TCA_TSR_BackEnd.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly ILogger<ServiceRequestsController> _logger;


        public ServiceRequestsController(ILogger<ServiceRequestsController> logger)
        {
            _logger = logger;
        }

        [HttpPost("UploadFile")]
        public async Task<IActionResult> PostFiles([FromForm] UploadFiles uf)
        {
            Result result = new Result();
            if (uf.Document_Id > 0 && uf.ServiceRequest_Id > 0 && uf.Document_Type > 0)
            {
                if (uf.DocumentFile == null || uf.DocumentFile.Length < 1)
                {
                    result.Message = "El archivo se encuentra vacio";
                    result.State = 1;
                    return Ok(result);
                }
                else
                {
                    if (uf.Document_Type == 1 || uf.Document_Type == 2 || uf.Document_Type == 3 || uf.Document_Type == 4 || uf.Document_Type == 5 || uf.Document_Type == 6 || uf.Document_Type == 8 || uf.Document_Type ==9)
                    {

                        //var filepath = @"App_Data/ServiceRequest-" + Convert.ToString(uf.ServiceRequest_Id) + "/Document-" + Convert.ToString(uf.Document_Id) + "/FileType-" + Convert.ToString(uf.Document_Type) + "/" + Convert.ToString(uf.ServiceRequest_Id) + "_" + Convert.ToString(uf.Document_Id) + "_" + Convert.ToString(uf.Document_Type) + ".pdf";
                        //System.IO.File.Delete(filepathDel);
                        var filePath = Path.Combine(@"App_Data/ServiceRequest/" + Convert.ToString(uf.ServiceRequest_Id) + "/Document/" + Convert.ToString(uf.Document_Id) + "/FileType/" + Convert.ToString(uf.Document_Type) + "/" + Convert.ToString(uf.ServiceRequest_Id) + "_" + Convert.ToString(uf.Document_Id) + "_" + Convert.ToString(uf.Document_Type) + ".pdf");
                        new FileInfo(filePath).Directory?.Create();
                        await using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            _logger.LogInformation($"Saving file [{uf.DocumentFile.FileName}]");
                            await uf.DocumentFile.CopyToAsync(stream);
                            _logger.LogInformation($"\t The uploaded file is saved as [{filePath}].");
                        }
                    }
                    else if(uf.Document_Type == 7)
                    {
                        if (Path.GetExtension(uf.DocumentFile.FileName) != ".xml")
                        {
                            result.State = 1;
                            result.Message = "Este documento no es formato XML";
                            return Ok(result);
                        }
                        else
                        {
                            var filepathDel = @"App_Data/ServiceRequest-" + Convert.ToString(uf.ServiceRequest_Id) + "/Document-" + Convert.ToString(uf.Document_Id) + "/FileType-" + Convert.ToString(uf.Document_Type) + "/"+ Convert.ToString(uf.ServiceRequest_Id) + "_" + Convert.ToString(uf.Document_Id) + "_" + Convert.ToString(uf.Document_Type) + ".xml";
                            System.IO.File.Delete(filepathDel);
                            var filePath = Path.Combine(@"App_Data/Archivo", $"{uf.DocumentFile.FileName}");
                            new FileInfo(filePath).Directory?.Create();
                            await using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                _logger.LogInformation($"Saving file [{uf.DocumentFile.FileName}]");
                                await uf.DocumentFile.CopyToAsync(stream);
                                _logger.LogInformation($"\t The uploaded file is saved as [{filePath}].");
                            }
                        }
                    }
                }
                //result = TCATSR_DAO.StoreServiceRequest(uf);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }
        }

        // GET: api/<ServiceRequestsController>
        [HttpGet("GetServiceRequests")]
        public IActionResult Get()
        {
            List<ServiceRequest> sr = TCATSR_DAO.GetServiceRequests();
            if (sr != null)
            {
                return Ok(sr);
            }
            else
            {
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
        }

        [HttpGet("GetServiceRequestsFull")]
        public IActionResult GetSRFull()
        {
            List<ServiceRequest> sr = TCATSR_DAO.GetServiceRequestsFull();
            if (sr != null)
            {
                return Ok(sr);
            }
            else
            {
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
        }


        // POST api/<ServiceRequestsController>
        [HttpPost("CreateServiceRequest")]
        public IActionResult Post([FromBody] ServiceRequestPost sr)
        {
            Result result = new Result();
            if (sr.Box_Number.Length > 0 && sr.User_Logged.Length > 0 && sr.OperationType_Id > 0 && sr.Stops_Id > 0)
            {
                result = TCATSR_DAO.StoreServiceRequest(sr);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }
        }


        [HttpPost("setTMWOrder")]
        public IActionResult PostTMW([FromBody] setTMW sr)
        {
            Result result = new Result();
            if (sr.ServiceRequest_Id > 0 && sr.User_Logged.Length > 0 && sr.TMWOrder.Length > 0)
            {
                result = TCATSR_DAO.setTMWOrder(sr);
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
