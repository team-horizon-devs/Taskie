using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Taskie.Domain.Interfaces.Service;

namespace Taskie.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITrophyService _trophyService;


        public TestController(ITrophyService trophyService)
        {
            _trophyService = trophyService;
        }

        [HttpGet("teste/{id}")]
        public async Task<IActionResult> GetTrophiesNotObtainedByUserId(string id)
        {
            try
            {
                var notObtained = await _trophyService.GetAllNotObtainedByUser(id);

                return Ok(notObtained);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
