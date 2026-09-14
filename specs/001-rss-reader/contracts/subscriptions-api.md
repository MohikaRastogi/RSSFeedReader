# Subscription API Contract

## Overview

This API supports the minimal MVP requirement of letting a user add a feed URL and retrieve the current list of subscriptions.

## Endpoints

### GET /api/subscriptions

Returns the current subscription list for the active session.

**Response 200 OK**
```json
[
  {
    "id": "feed-001",
    "url": "https://example.com/feed.xml",
    "createdAt": "2026-09-14T12:00:00Z"
  }
]
```

### POST /api/subscriptions

Adds a subscription to the in-memory list.

**Request**
```json
{
  "url": "https://example.com/feed.xml"
}
```

**Success response 200 OK**
```json
{
  "id": "feed-001",
  "url": "https://example.com/feed.xml",
  "createdAt": "2026-09-14T12:00:00Z"
}
```

**Validation error response 400 Bad Request**
```json
{
  "error": "Subscription URL is required."
}
```

## Notes

- This contract is intentionally limited to the MVP.
- No feed-fetch or item endpoint is included in this phase.
- The list is in memory only and resets when the app process restarts.
