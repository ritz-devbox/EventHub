

using EventHub.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using EventHub.Application.Interfaces;

namespace EventHub.API.Controllers;

[ApiController]
[Route("api/participants")]
public class ParticipantController : ControllerBase
{
    private readonly IParticipantService _participantService;

    public ParticipantController(IParticipantService participantService)
    {
        _participantService = participantService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateParticipantRequest request)
    {
        var result = await _participantService.CreateParticipantAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _participantService.GetParticipantByIdAsync(id);
        return Ok(result);
    }
}
