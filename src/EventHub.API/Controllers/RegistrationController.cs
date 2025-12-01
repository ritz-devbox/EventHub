using EventHub.Application.Interfaces;
using EventHub.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EventHub.API.Controllers;

[ApiController]
[Route("api/registrations")]
public class RegistrationController : ControllerBase
{
    private readonly IRegistrationService _registrationService;

    public RegistrationController(IRegistrationService registrationService)
    {
        _registrationService = registrationService;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] CreateRegistrationRequest request)
    {
        var result = await _registrationService.RegisterAsync(request);
        return Created($"/api/registrations/{result.Id}", result);
    }

    [HttpGet("event/{eventId:guid}")]
    public async Task<IActionResult> GetForEvent(Guid eventId)
    {
        var results = await _registrationService.GetRegistrationsForEventAsync(eventId);
        return Ok(results);
    }
}
