using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {

            var result = _cityService.GetAll();


            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(new { message = result.Message });
        }
    }
}
