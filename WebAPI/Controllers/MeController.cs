using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeController : Controller
    {
        private ITransferRequestService _transferRequestService;

        public MeController(ITransferRequestService transferRequestService)
        {
            _transferRequestService = transferRequestService;
        }



        [HttpGet("transferRequests")]
        public IActionResult GetAllTransferRequest()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = _transferRequestService.GetAllTransferRequestDetailsByUserId(Convert.ToInt32(userId));


            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(new { message = result.Message });
        }

        //[HttpPost("transferRequests")]
        //public IActionResult AddTransferRequest(TransferRequestDetailDto transferRequestDetailDto)
        //{

        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        //    var result = _transferRequestService.Add(transferRequestDetailDto);
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result.Message);
        //}
    }
}
