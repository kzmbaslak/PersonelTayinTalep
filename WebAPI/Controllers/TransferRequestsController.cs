using Business.Abstract;
using Business.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferRequestsController : ControllerBase
    {
        ITransferRequestService _transferRequestService;
        public TransferRequestsController(ITransferRequestService transferRequestService)
        {
            _transferRequestService = transferRequestService;
        }


        [HttpPost("add")]
        public IActionResult Add(TransferRequestDto transferRequestDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = _transferRequestService.Add(transferRequestDto, Convert.ToInt32(userId));


            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(new { message = result.Message });
        }


        [HttpGet("getAllTransferRequestDetails")]
        public IActionResult getAllTransferRequestDetails()
        {
            var result = _transferRequestService.GetAllTransferRequestDetails();


            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(new { message = result.Message });
        }

        
    }
}
