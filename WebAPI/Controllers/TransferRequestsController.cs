using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferRequestsController : ControllerBase
    {
        ITransferRequestService _transferRequestManager;
        public TransferRequestsController(ITransferRequestService transferRequestService)
        {
            _transferRequestManager = transferRequestService;
        }

        [HttpGet("getAllTransferRequestDetails")]
        public IActionResult getAllTransferRequestDetails()
        {
            var result = _transferRequestManager.GetAllTransferRequestDetails();


            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
