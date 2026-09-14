using Microsoft.AspNetCore.Mvc;
using RSSFeedReader.Api.Services;

namespace RSSFeedReader.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly InMemorySubscriptionService _subscriptionService;

    public SubscriptionsController(InMemorySubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SubscriptionItem>> Get()
    {
        return Ok(_subscriptionService.GetAll());
    }

    [HttpPost]
    public ActionResult<SubscriptionItem> Post([FromBody] SubscriptionRequest request)
    {
        try
        {
            var item = _subscriptionService.Add(request.Url);
            return Ok(item);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}

public class SubscriptionRequest
{
    public string Url { get; set; } = string.Empty;
}
