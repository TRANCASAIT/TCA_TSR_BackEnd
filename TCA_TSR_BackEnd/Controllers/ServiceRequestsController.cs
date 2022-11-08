using Microsoft.AspNetCore.Mvc;
using TCA_TSR_BackEnd.Models.DAO;
using TCA_TSR_BackEnd.Models;
using static TCA_TSR_BackEnd.Models.ServiceRequest;
using Microsoft.AspNetCore.StaticFiles;

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
        public async Task<IActionResult> PostFiles([FromForm] UploadFile uf)
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
                    if (uf.Document_Type == 1 || uf.Document_Type == 2 || uf.Document_Type == 3 || uf.Document_Type == 4 || uf.Document_Type == 5 || uf.Document_Type == 6 || uf.Document_Type == 8 || uf.Document_Type == 9)
                    {
                        var filePath = Path.Combine(@"App_Data/Solicitudes/" + "SR-"+ Convert.ToString(uf.ServiceRequest_Id) + "/Documents/" + "DC-" +Convert.ToString(uf.Document_Id) + "/File-" + Convert.ToString(uf.Document_Type) + "/" + uf.DocumentFile.FileName);
                        result = TCATSR_DAO.UploadFile(uf, filePath, uf.DocumentFile.FileName);
                        if(result.State == 0)
                        {
                            new FileInfo(filePath).Directory?.Create();
                            await using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                _logger.LogInformation($"Saving file [{uf.DocumentFile.FileName}]");
                                await uf.DocumentFile.CopyToAsync(stream);
                                _logger.LogInformation($"\t The uploaded file is saved as [{filePath}].");
                            }
                            return Ok(result);
                        }
                        else
                        {
                            return Ok(result);
                        }
                    }
                    else if(uf.Document_Type == 7)
                    {
                        if (Path.GetExtension(uf.DocumentFile.FileName) != ".xml")
                        {
                            result.State = 1;
                            result.Message = "Este documento no es formato XML";
                            return Ok(result); //TODO: Verificar que si entre a este punto
                        }
                        else
                        {

                            var filePath = Path.Combine(@"App_Data/Solicitudes/" + "SR-" + Convert.ToString(uf.ServiceRequest_Id) + "/Documents/" + "DC-" + Convert.ToString(uf.Document_Id) + "/File-" + Convert.ToString(uf.Document_Type) + "/" + uf.DocumentFile.FileName);
                            result = TCATSR_DAO.UploadFile(uf, filePath, uf.DocumentFile.FileName);
                            if(result.State == 0)
                            {
                                new FileInfo(filePath).Directory?.Create();
                                await using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    _logger.LogInformation($"Saving file [{uf.DocumentFile.FileName}]");
                                    await uf.DocumentFile.CopyToAsync(stream);
                                    _logger.LogInformation($"\t The uploaded file is saved as [{filePath}].");
                                }
                                return Ok(result);
                            }
                            else
                            {
                                return Ok(result);
                            }
                            
                        }
                    }
                }
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }
        }

        [HttpPost("DownloadFile")]
        public async Task<ActionResult> DownloadFile(DownloadFile df)
        {
            // validation and get the file
            Result result = new Result();
            //var filePath = $"{id}.txt";
            var filePath = Path.Combine(df.Url);

            if (!System.IO.File.Exists(filePath))
            {
                result.Message = "El archivo no existe";
                result.State = 1;
                return Ok(result);
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var filname = Path.GetFileName(filePath);
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }


        [HttpPost("RemoveFile")]
        public IActionResult RemoveFile(RemoveFile rf)
        {
            Result result = TCATSR_DAO.RemoveFile(rf);
            if(result.State == 0)
            {
                var filePath = Path.Combine(@"App_Data/Solicitudes/" + "SR-" + Convert.ToString(rf.ServiceRequest_Id) + "/Documents/" + "DC-" + Convert.ToString(rf.Document_Id) + "/File-" + Convert.ToString(rf.Document_Type) + "/" + rf.FileName);
                System.IO.File.Delete(filePath);
                return Ok(result);
            }
            else
            {
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

         [HttpGet("GetServiceRequestsFull/{srId}")]
         public IActionResult GetSRFull(int srId)
         {
            List<ServiceRequest> sr = TCATSR_DAO.GetServiceRequestsFull(srId);
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



        [HttpPost("setConsigmentNote")]
        public IActionResult PostInvoiceNumber([FromBody] setConsigmentNote sr)
        {
            Result result = new Result();
            if (sr.ServiceRequest_Id > 0 && sr.User_Logged.Length > 0 && sr.Consigment_Note.Length > 0 && sr.Document_Id > 0)
            {
                result = TCATSR_DAO.setConsigmentNote(sr);
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
