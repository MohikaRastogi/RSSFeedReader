# Data Model: RSS Reader MVP

## Core Entities

### FeedSubscription

Represents a feed the user wants to follow during the current session.

| Field | Type | Description | Validation |
|-------|------|-------------|------------|
| Id | string | Unique identifier for the subscription | Required |
| Url | string | Feed URL entered by the user | Must be non-empty and normalized |
| CreatedAt | datetime | When the subscription was added | Required |

**Relationships**:
- A `SubscriptionList` contains zero or more `FeedSubscription` items.
- Each `FeedSubscription` belongs to a single active user session.

### SubscriptionList

Represents the working collection of subscriptions displayed to the user.

| Field | Type | Description | Validation |
|-------|------|-------------|------------|
| Items | array of FeedSubscription | The current list of active subscriptions | Non-null |

**Relationships**:
- The list is the user-facing state for the current session.
- The list may be updated by add operations but does not support persistence in the MVP.

## Validation Rules

- Empty or whitespace-only URLs MUST be rejected.
- Duplicate URLs SHOULD be prevented or normalized to avoid repeated entries in the same session.
- The model MUST remain intentionally small and not include fetch results, parsed feed items, or persistence metadata during the MVP.

## State Model

- `Draft` / `Ready`: the subscription is entered but not yet added.
- `Added`: successful submission has created a list item.
- `Rejected`: invalid input or repeated submission does not change the list.

## Out of Scope for MVP

- Feed item records
- User accounts or multi-user persistence
- Automatic refresh scheduling
- Background polling state
- Read/unread tracking
