using System.Net.Http.Json;
using RSSFeedReader.UI.Models;

namespace RSSFeedReader.UI.Services;

public class SubscriptionApiClient(HttpClient httpClient)
{
    public async Task<List<SubscriptionItem>> GetSubscriptionsAsync()
    {
        var response = await httpClient.GetAsync("subscriptions");
        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException("Failed to load subscriptions.");
        }

        return await response.Content.ReadFromJsonAsync<List<SubscriptionItem>>() ?? new List<SubscriptionItem>();
    }

    public async Task<SubscriptionItem> AddSubscriptionAsync(string url)
    {
        var trimmed = url?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(trimmed))
        {
            throw new InvalidOperationException("Subscription URL is required.");
        }

        var response = await httpClient.PostAsJsonAsync("subscriptions", new SubscriptionRequest { Url = trimmed });
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new InvalidOperationException(string.IsNullOrWhiteSpace(error) ? "Unable to add subscription." : error);
        }

        return await response.Content.ReadFromJsonAsync<SubscriptionItem>() ?? throw new InvalidOperationException("Unable to read subscription response.");
    }
}
