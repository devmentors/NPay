using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPay.Modules.Users.Core.Services;
using NPay.Modules.Users.Shared.DTO;
using Swashbuckle.AspNetCore.Annotations;

namespace NPay.Modules.Users.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    [SwaggerOperation("Browse users")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        => Ok(await _usersService.BrowseAsync());

    [HttpGet("{userId:guid}")]
    [SwaggerOperation("Get user by ID")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDetailsDto>> Get(Guid userId)
    {
        var user = await _usersService.GetAsync(userId);
        if (user is not null)
        {
            return Ok(user);
        }

        return NotFound();
    }

    [HttpGet("by-email/{email}")]
    [SwaggerOperation("Get user by email")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDetailsDto>> Get(string email)
    {
        var user = await _usersService.GetAsync(email);
        if (user is not null)
        {
            return Ok(user);
        }

        return NotFound();
    }

    [HttpPost]
    [SwaggerOperation("Create user")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(UserDetailsDto user)
    {
        user.UserId = Guid.NewGuid();
        await _usersService.AddAsync(user);
        return CreatedAtAction(nameof(Get), new { userId = user.UserId }, null);
    }

    [HttpPut("{userId:guid}/verify")]
    [SwaggerOperation("Verify user")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post(Guid userId)
    {
        await _usersService.VerifyAsync(userId);
        return NoContent();
    }
}