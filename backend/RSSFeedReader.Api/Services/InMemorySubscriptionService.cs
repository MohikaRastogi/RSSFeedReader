namespace RSSFeedReader.Api.Services;

public class InMemorySubscriptionService
{
    private readonly List<SubscriptionItem> _subscriptions = [];

    public IReadOnlyList<SubscriptionItem> GetAll() => _subscriptions.AsReadOnly();

    public SubscriptionItem Add(string url)
    {
        var cleanedUrl = url?.Trim();
        if (string.IsNullOrWhiteSpace(cleanedUrl))
        {
            throw new ArgumentException("Subscription URL is required.");
        }

        var normalizedUrl = cleanedUrl.TrimEnd('/');
        if (_subscriptions.Any(item => string.Equals(item.Url, normalizedUrl, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException("This subscription already exists.");
        }

        var item = new SubscriptionItem
        {
            Id = Guid.NewGuid().ToString("N"),
            Url = normalizedUrl,
            CreatedAt = DateTimeOffset.UtcNow
        };

        _subscriptions.Add(item);
        return item;
    }
}

public class SubscriptionItem
{
    public string Id { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
}
