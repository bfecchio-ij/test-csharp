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
        public async Task<ActionResult<List<Candidate>>> GetCandidates()
        {
            return _service.GetCandidates();

        }
    }
}
