using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class TransferTypesController : Controller
    {
        ITransferTypeService _transferTypeService;
        public TransferTypesController(ITransferTypeService transferTypeService)
        {
            _transferTypeService = transferTypeService;
        }
        [HttpGet("getAll")]
        public IActionResult GaetAll()
        {
            var result = _transferTypeService.GetAll();


            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
