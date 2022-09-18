using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPay.Modules.Wallets.Application.Owners.Commands;
using NPay.Shared.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;

namespace NPay.Modules.Wallets.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OwnersController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public OwnersController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpPost]
    [SwaggerOperation("Add owner")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(AddOwner command)
    {
        await _dispatcher.SendAsync(command);
        return NoContent();
    }
}