﻿using Candidatos.Application.DTO;
using Candidatos.Application.Interfaces;
using Candidatos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candidatos.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CandidateExperienceController: ControllerBase
    {
        private readonly ICandidateExperienceService _candidateAppService;

        public CandidateExperienceController(ICandidateExperienceService candidateAppService)
        {
            _candidateAppService = candidateAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ce = await _candidateAppService.GetAllAsync();
            if (ce == null) return NoContent();
            return Ok(ce);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ce = await _candidateAppService.GetByIdAsync(id);
            if (ce == null) return NoContent();
            return Ok(ce);
        }

        [HttpPost]
        public async void Post([FromBody] CandidateExperienceCommandDTO value)
        {
            await _candidateAppService.CreateAsync(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CandidateExperienceCommandDTO value)
        {
            value.IdCandidateExperience = id;
            
            var ce = await _candidateAppService.GetByIdAsync(id);
            if (ce == null) return NoContent();
            
            await _candidateAppService.UpdateAsync(value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var ce = await _candidateAppService.GetByIdAsync(id.Value);
            if (ce == null) return NoContent();

            await _candidateAppService.RemoveAsync(id.Value);
            return Ok();
        }
    }
}