# Research: RSS Reader MVP

## Decision: Use ASP.NET Core Web API + Blazor WebAssembly

**Decision**: The app will use an ASP.NET Core Web API backend and a Blazor WebAssembly frontend.

**Rationale**: This matches the project’s technical stack guidance and supports a minimal MVP without forcing a large production architecture. It keeps the backend responsible for API operations and the frontend responsible for user interaction while retaining a clear path to future enhancements.

**Alternatives considered**:
- Single-page app with a static front end only: rejected because the project explicitly targets backend/frontend separation and future extensibility.
- Full production stack with persistence and background processing from day one: rejected because it exceeds the MVP scope and conflicts with the project constitution.

## Decision: Use in-memory storage for subscriptions in the MVP

**Decision**: Store feed subscriptions in memory during the active session only.

**Rationale**: This matches the project goals and the MVP limitation of keeping the implementation simple and focused. It also reduces infrastructure and setup complexity while preserving a clear upgrade path to persistence later.

**Alternatives considered**:
- SQLite persistence from day one: rejected because it adds setup and migration complexity not needed for the MVP.
- External service or database dependency: rejected because the goal is to demonstrate the most basic capability and keep the app lightweight.

## Decision: Keep the user flow limited to add and list subscriptions

**Decision**: The MVP supports entering a feed URL and displaying the resulting subscription list.

**Rationale**: This is the feature definition and the clearest path to a demonstrable proof-of-concept. It keeps the app easy to understand and test while honoring the constitution’s MVP discipline principle.

**Alternatives considered**:
- Feed fetching and item display immediately: rejected because those are explicitly deferred to Extended-MVP and beyond.
- Add/remove/persistence flows now: rejected because the current scope is intentionally narrower.

## Decision: Treat duplicate and empty URLs as edge-case validations in the UI and API boundary

**Decision**: Empty or whitespace-only submissions are rejected, and duplicate URLs are normalized and prevented within the active session.

**Rationale**: This preserves a clean list and avoids user confusion while remaining compatible with the MVP’s assumption that URLs are supplied by the user and do not require deep validation.

**Alternatives considered**:
- Allow duplicates silently: rejected because it complicates user confirmation and list management.
- Full feed validation and parsing for every URL: rejected because it exceeds the current MVP scope.

## Decision: Design for future extension without coupling the MVP to it

**Decision**: The application architecture will isolate backend responsibilities and leave room for future feed-fetching and data persistence features.

**Rationale**: The project explicitly states that future enhancements will be layered on top of the existing architecture without a rewrite. This supports maintainability and a clean separation of concerns.

**Alternatives considered**:
- Designing the app as a single tightly-coupled UI component from the beginning: rejected because it reduces long-term maintainability and violates the constitution.
