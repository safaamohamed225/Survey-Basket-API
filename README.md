# SurveyBasket.Api

A RESTful API built with ASP.NET Core for managing surveys and user interactions. The system supports full CRUD operations, secure user authentication, and robust role-based access control.

## 🚀 Features

- 📝 CRUD operations for:
  - Surveys
  - Survey Responses
- 🔐 User Authentication & Authorization
- 👥 Role-Based Access Control (RBAC) with:
  - Roles
  - Permissions
- 📊 Scalable structure for future survey analytics and reporting

## 🛠️ Technologies Used

- ASP.NET Core Web API
- Entity Framework Core (EF Core)
- ASP.NET Core Identity
- SQL Server (via EF Core)
- JWT Authentication
- AutoMapper
- Swagger (OpenAPI)

## 📁 Project Structure

The project follows a clean architecture and is organized into:

- **Controllers** – Handle API endpoints and routing.
- **Models** – Contains Entity Framework models and DTOs.
- **Data** –  EF Core DbContext, Configures the database context and migrations.
- **Services** – Business logic and core operations.
- **Repositories** – Encapsulates data access logic.
- **Middleware** – Custom middleware for handling exceptions, logging, etc.
- ** Program.cs** - App entry point and configurations

