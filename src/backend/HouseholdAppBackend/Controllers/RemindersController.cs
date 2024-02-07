using Microsoft.AspNetCore.Mvc;

namespace HouseholdAppBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class RemindersController : ControllerBase
{
    private readonly InMemoryCache _inMemoryCache;

    public RemindersController(InMemoryCache inMemoryCache)
    {
        _inMemoryCache = inMemoryCache;
    }

    [HttpGet("GetReminders")]
    public IActionResult GetReminders()
    {
        return Ok(_inMemoryCache.Entries);
    }

    [HttpPost("SetReminder")]
    public IActionResult SetReminder([FromBody] SetReminderRequest request)
    {
        _inMemoryCache.Add(request.reminder);
        return Ok();
    }
}
