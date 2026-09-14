# Tasks: RSS Reader MVP

**Input**: Design documents from `/specs/001-rss-reader/`

**Prerequisites**: plan.md, spec.md, research.md, data-model.md, contracts/

**Organization**: Tasks are grouped by user story to enable independent implementation and testing of each story.

## Format: `[ID] [P?] [Story] Description`

- **[P]**: Can run in parallel (different files, no dependencies)
- **[Story]**: Which user story this task belongs to (e.g., US1, US2)
- Include exact file paths in descriptions

## Phase 1: Setup (Shared Infrastructure)

**Purpose**: Initialize the project structure and build the minimal web-application skeleton.

- [ ] T001 Create the backend and frontend project structure under `backend/RSSFeedReader.Api/` and `frontend/RSSFeedReader.UI/`
- [ ] T002 [P] Initialize the ASP.NET Core Web API and Blazor WebAssembly projects with the .NET SDK and solution wiring
- [ ] T003 [P] Configure shared launch settings, solution metadata, and local port alignment for backend and frontend in `backend/RSSFeedReader.Api/Properties/launchSettings.json`, `frontend/RSSFeedReader.UI/Properties/launchSettings.json`, and `frontend/RSSFeedReader.UI/wwwroot/appsettings.json`

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Prepare the API, UI, and runtime boundaries required before user story work begins.

**⚠️ CRITICAL**: No user story work can begin until this phase is complete.

- [ ] T004 Configure backend application startup and middleware in `backend/RSSFeedReader.Api/Program.cs`
- [ ] T005 [P] Configure frontend startup, API base URL, and dependency registration in `frontend/RSSFeedReader.UI/Program.cs`
- [ ] T006 [P] Remove template demo pages and update navigation so only the MVP route remains in `frontend/RSSFeedReader.UI/Pages/` and `frontend/RSSFeedReader.UI/Layout/NavMenu.razor`
- [ ] T007 Configure CORS and backend/frontend origin alignment in `backend/RSSFeedReader.Api/Program.cs` and `frontend/RSSFeedReader.UI/wwwroot/appsettings.json`
- [ ] T008 Create the in-memory subscription model and validation rules in `backend/RSSFeedReader.Api/Models/SubscriptionItem.cs`

**Checkpoint**: Foundation ready - user story implementation can now begin.

---

## Phase 3: User Story 1 - Add a feed subscription (Priority: P1) 🎯 MVP

**Goal**: Allow a user to enter a feed URL and add it to the visible subscription list.

**Independent Test**: A user can open the app, submit a valid feed URL, and see the new item appear in the list without additional setup.

### Implementation for User Story 1

- [ ] T009 [P] [US1] Implement the GET subscription list endpoint contract in `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs`
- [ ] T010 [US1] Implement the in-memory subscription service in `backend/RSSFeedReader.Api/Services/SubscriptionService.cs` with support for storing and returning the list
- [ ] T011 [US1] Implement the POST subscription endpoint in `backend/RSSFeedReader.Api/Controllers/SubscriptionsController.cs` to accept a URL and reject empty values
- [ ] T012 [P] [US1] Create the subscriptions page and form in `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor` for user input and submit actions
- [ ] T013 [US1] Implement the frontend API client and list rendering in `frontend/RSSFeedReader.UI/Services/SubscriptionApiClient.cs` and `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor` so new entries appear immediately
- [ ] T014 [US1] Add validation for blank, whitespace-only, and duplicate URLs based on the rules in `specs/001-rss-reader/data-model.md` and `specs/001-rss-reader/contracts/subscriptions-api.md`

**Checkpoint**: At this point, User Story 1 should be fully functional and independently testable.

---

## Phase 4: User Story 2 - View the current subscription list (Priority: P1)

**Goal**: Let the user confirm the app records and displays all subscriptions in a simple, understandable list.

**Independent Test**: A user can view the list after adding one or more subscriptions and confirm the entries remain visible and stable.

### Implementation for User Story 2

- [ ] T015 [P] [US2] Add list refresh behavior and display state handling in `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`
- [ ] T016 [US2] Ensure the backend list remains stable across consecutive adds and does not reset on each new submission in `backend/RSSFeedReader.Api/Services/SubscriptionService.cs`
- [ ] T017 [US2] Validate the multi-add workflow against the quickstart in `specs/001-rss-reader/quickstart.md` and confirm the list retains prior values while updating with each new entry

**Checkpoint**: At this point, both user story flows are working independently and support the user’s core MVP objective.

---

## Phase 5: Polish & Cross-Cutting Concerns

**Purpose**: Final pass for config hygiene, UX clarity, and MVP verification.

- [ ] T018 [P] Run the smoke validation workflow from `specs/001-rss-reader/quickstart.md` and confirm backend/frontend ports, routing, and CORS are all aligned
- [ ] T019 [P] Review the MVP scope against `specs/001-rss-reader/spec.md` and confirm no feed-fetching, parsing, or persistence work leaked into the implementation
- [ ] T020 Remove any leftover demo-state assumptions and finalize the subscription page copy in `frontend/RSSFeedReader.UI/Pages/Subscriptions.razor`

---

## Dependencies & Execution Order

### Phase Dependencies

- **Setup (Phase 1)**: No dependencies - can start immediately.
- **Foundational (Phase 2)**: Depends on Setup completion and blocks all user-story work.
- **User Stories (Phase 3+)**: Depend on Foundational completion.
- **Polish (Final Phase)**: Depends on user-story completion and validation.

### User Story Dependencies

- **User Story 1 (P1)**: Can start after Foundational completion and is the primary MVP deliverable.
- **User Story 2 (P1)**: Depends on the same foundation and reinforces the core list-management workflow.

### Parallel Opportunities

- T002 and T003 can run in parallel.
- T005 and T006 can run in parallel once setup is complete.
- T009 and T012 can be implemented in parallel after the foundation is ready.
- T018 and T019 can run together during the final validation phase.

---

## Implementation Strategy

### MVP First

1. Complete Phase 1: Setup
2. Complete Phase 2: Foundational
3. Complete Phase 3: User Story 1
4. Validate and confirm the MVP is demonstrably working
5. Complete Phase 4 if additional list-stability validation is needed before sign-off

### Incremental Delivery

1. Build the backend + UI skeleton
2. Add the API and subscription model
3. Implement the add-subscription form
4. Confirm the list updates correctly
5. Finalize binding, route cleanup, and validation checks

### Notes

- The MVP intentionally excludes feed fetching, item display, persistence, and background operations.
- All tasks remain scoped to the approved startup architecture and the minimal user value described in the spec.
