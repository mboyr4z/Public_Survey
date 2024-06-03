using System.Text.Json;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Survey.Benimkiler;


namespace Presentation.Controllers;


[ApiController]
[Route("api/search")]
public class SearchController : ControllerBase    // api için class tanımı
{
    private readonly IServiceManager _manager;

    public SearchController(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public IActionResult Search([FromQuery] string query)
    {
        List<UserCard> userCards = _manager.SearchUserWithKeyword(query);
       // p.f(userCards.Count.ToString());
        return Ok(userCards);
    }
}
