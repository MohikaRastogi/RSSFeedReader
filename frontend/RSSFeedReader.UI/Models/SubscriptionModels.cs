namespace RSSFeedReader.UI.Models;

public class SubscriptionItem
{
    public string Id { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
}

public class SubscriptionRequest
{
    public string Url { get; set; } = string.Empty;
}
