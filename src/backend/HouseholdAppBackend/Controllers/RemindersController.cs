using HouseholdAppBackend.Contracts;
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
        var reminder = _inMemoryCache.Add(request.Reminder);
        return Ok(reminder);
    }

    [HttpDelete("DeleteReminder")]
    public IActionResult DeleteReminder([FromBody] DeleteReminderRequest request)
    {
        _inMemoryCache.Remove(new Guid(request.Id));
        return Ok();
    }
}
