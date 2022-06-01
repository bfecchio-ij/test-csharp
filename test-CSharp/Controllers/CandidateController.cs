using Microsoft.AspNetCore.Mvc;
using test_CSharp.Interfaces;
using test_CSharp.Models;

namespace test_CSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;

        public CandidateController(ICandidateService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Candidate>>> GetCandidatesAsync()
        {
            try
            {
                return Ok(await _service.GetCandidatesAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
