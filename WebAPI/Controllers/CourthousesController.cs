using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entities.Concrete;
using AutoMapper;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourthousesController : ControllerBase
    {
        ICourthouseService _courthouseService;
        public CourthousesController(ICourthouseService courthouseService)
        {
            _courthouseService = courthouseService;
        }


        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var result = _courthouseService.GetById(id);


            if (result.Success)
            {
                return Ok(result.Data);
            } 
            return BadRequest(result.Message);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _courthouseService.GetAll();


            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(CourthouseDto courthouseDto)
        {
            var result = _courthouseService.Add(courthouseDto);


            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(int courthouseId)
        {
            var result = _courthouseService.Delete(courthouseId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
