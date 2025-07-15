# Document Access Approval System

## Overview
 App allows users to request access to documents, and enables approvers to review and approve or reject these requests. 

## Technologies Used
- ASP.NET Core Web API. .NET 9
- Entity Framework Core 
- SQLite db
- xUnit and Moq for unit testing


### Setup 
1. **Clone the repository:**
   ```sh
   git clone <your-repo-url>
   cd InterviewProjectFinished
   ```
2. **Restore dependencies:**
   ```sh
   dotnet restore
   ```
3. **Apply database migrations:**
   ```sh
   cd DocumentAccessApprovalSystem.Infrastructure
   dotnet ef database update
   ```
4. **Run the API:**
   ```sh
   cd ../DocumentAccessApprovalSystem.API
   dotnet run
   ```
5. **Run tests:**
   ```sh
   cd ../DocumentAccessApprovalSystem.Tests
   dotnet test
   ```

## Project Structure
- `DocumentAccessApprovalSystem.API/` - Web API project (controllers, DTOs)
- `DocumentAccessApprovalSystem.Application/` - Business logic and services
- `DocumentAccessApprovalSystem.Domain/` - Domain entities and interfaces
- `DocumentAccessApprovalSystem.Infrastructure/` - Data access and migrations
- `DocumentAccessApprovalSystem.Tests/` - Unit tests

## To Do
- Custom error handling
- Request input validation
- More tests
- Admin role for managing access to documents
- Event simulation (sending notification after approval)


