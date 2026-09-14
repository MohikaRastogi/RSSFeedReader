# Quickstart: RSS Reader MVP

## Prerequisites

- .NET SDK 8 or later
- A terminal capable of running .NET commands
- Local browser access to the frontend

## Validate the MVP flow

1. Restore dependencies:
   ```bash
   dotnet restore
   ```

2. Start the backend API:
   ```bash
   dotnet run --project backend/RSSFeedReader.Api
   ```

3. Start the frontend app:
   ```bash
   dotnet run --project frontend/RSSFeedReader.UI
   ```

4. Open the frontend in a browser.

5. Enter a sample feed URL such as the Microsoft DevBlogs feed and submit it.

6. Verify the URL appears in the subscription list immediately.

7. Add a second subscription and confirm the list remains intact and updates without reloading the page.

## Expected result

The user can add one or more feed URLs and see them appear in the current subscription list, while the application remains intentionally limited to the MVP scope.

## Failure indicators

- App starts but subscription list never updates after submit.
- Empty submission creates a blank entry.
- Frontend and backend ports are not aligned.
- UI routing conflicts appear due to leftover template demo pages.
