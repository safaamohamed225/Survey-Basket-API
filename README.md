# SurveyBasket API 📊

[![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)](https://dotnet.microsoft.com/download)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-blue.svg)](https://docs.microsoft.com/en-us/aspnet/core/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-orange.svg)](https://docs.microsoft.com/en-us/ef/core/)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)

A robust and scalable RESTful API built with ASP.NET Core for comprehensive survey management and user interactions. Features enterprise-grade security, role-based access control, and a clean architecture designed for maintainability and extensibility.

## 🌟 Key Features

### 📝 Survey Management
- **Full CRUD Operations** for surveys and responses
- **Dynamic Survey Creation** with flexible question types
- **Response Collection** and validation
- **Survey Analytics** foundation for future reporting

### 🔐 Security & Authentication
- **JWT Authentication** with refresh token support
- **ASP.NET Core Identity** integration
- **Role-Based Access Control (RBAC)** with granular permissions
- **Secure API endpoints** with authorization policies

### 🏗️ Architecture & Design
- **Clean Architecture** principles
- **Repository Pattern** for data access
- **Service Layer** for business logic
- **AutoMapper** for object mapping
- **Comprehensive error handling** and logging

## 🛠️ Tech Stack

| Technology | Purpose |
|------------|---------|
| **ASP.NET Core 8.0** | Web API Framework |
| **Entity Framework Core** | ORM and Database Access |
| **ASP.NET Core Identity** | User Management & Authentication |
| **SQL Server** | Primary Database |
| **JWT Bearer** | Token-based Authentication |
| **AutoMapper** | Object-Object Mapping |
| **Swagger/OpenAPI** | API Documentation |

## 📁 Project Structure

```
SurveyBasket.Api/
├── 📂 Controllers/          # API endpoints and routing
│   ├── AuthController.cs    # Authentication endpoints
│   ├── SurveysController.cs # Survey management
│   └── ResponsesController.cs # Response handling
├── 📂 Models/               # Entity models and DTOs
│   ├── Entities/            # Database entities
│   ├── DTOs/                # Data transfer objects
│   └── ViewModels/          # Response models
├── 📂 Data/                 # Database context and configuration
│   ├── ApplicationDbContext.cs
│   ├── Configurations/      # Entity configurations
│   └── Migrations/          # EF Core migrations
├── 📂 Services/             # Business logic layer
│   ├── Interfaces/          # Service contracts
│   └── Implementations/     # Service implementations
├── 📂 Repositories/         # Data access layer
│   ├── Interfaces/          # Repository contracts
│   └── Implementations/     # Repository implementations
├── 📂 Middleware/           # Custom middleware
│   ├── ExceptionMiddleware.cs
│   └── LoggingMiddleware.cs
├── 📂 Extensions/           # Extension methods
├── 📂 Helpers/              # Utility classes
└── Program.cs               # Application entry point
```

## 🚀 Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB for development)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/SurveyBasket.Api.git
   cd SurveyBasket.Api
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Update connection string**
   
   Edit `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SurveyBasketDb;Trusted_Connection=true;"
     }
   }
   ```

4. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Access the API**
   - API: `https://localhost:7000`
   - Swagger UI: `https://localhost:7000/swagger`

## 📖 API Documentation

### Authentication Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `POST` | `/api/auth/register` | Register new user |
| `POST` | `/api/auth/login` | User login |
| `POST` | `/api/auth/refresh` | Refresh JWT token |
| `POST` | `/api/auth/logout` | User logout |

### Survey Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/surveys` | Get all surveys | ✅ |
| `GET` | `/api/surveys/{id}` | Get survey by ID | ✅ |
| `POST` | `/api/surveys` | Create new survey | ✅ (Admin) |
| `PUT` | `/api/surveys/{id}` | Update survey | ✅ (Admin/Owner) |
| `DELETE` | `/api/surveys/{id}` | Delete survey | ✅ (Admin/Owner) |

### Response Endpoints

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/surveys/{id}/responses` | Get survey responses | ✅ (Admin/Owner) |
| `POST` | `/api/surveys/{id}/responses` | Submit response | ✅ |
| `GET` | `/api/responses/{id}` | Get response by ID | ✅ |

## 🔑 Authentication & Authorization

### JWT Configuration

The API uses JWT tokens for authentication. Include the token in the Authorization header:

```http
Authorization: Bearer <your-jwt-token>
```

### User Roles

| Role | Permissions |
|------|-------------|
| **Admin** | Full access to all surveys and responses |
| **SurveyCreator** | Create, edit, and manage own surveys |
| **Respondent** | Submit responses to published surveys |

## 📊 Sample Requests

### Register User
```http
POST /api/auth/register
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "SecurePassword123!",
  "firstName": "John",
  "lastName": "Doe"
}
```

### Create Survey
```http
POST /api/surveys
Authorization: Bearer <token>
Content-Type: application/json

{
  "title": "Customer Satisfaction Survey",
  "description": "Help us improve our services",
  "isPublic": true,
  "questions": [
    {
      "text": "How satisfied are you with our service?",
      "type": "SingleChoice",
      "options": ["Very Satisfied", "Satisfied", "Neutral", "Dissatisfied"]
    }
  ]
}
```

## 🧪 Testing

Run the test suite:

```bash
# Run all tests
dotnet test

# Run with coverage
dotnet test --collect:"XPlat Code Coverage"
```

## 📈 Future Enhancements

- [ ] **Advanced Analytics** - Survey response analytics and reporting
- [ ] **Email Notifications** - Survey invitations and reminders
- [ ] **File Uploads** - Support for image/document questions
- [ ] **Survey Templates** - Pre-built survey templates
- [ ] **Export Features** - Export responses to CSV/Excel
- [ ] **Real-time Updates** - SignalR integration for live responses
- [ ] **Multi-language Support** - Internationalization

## 🤝 Contributing

We welcome contributions! Please see our [Contributing Guidelines](CONTRIBUTING.md) for details.

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Authors

- **Your Name** - *Initial work* - [YourGitHub](https://github.com/safaamohamed225)

## 🙏 Acknowledgments

- ASP.NET Core team for the excellent framework
- Entity Framework Core for robust data access
- The open-source community for inspiration and tools

## 📞 Support

If you have any questions or need help, please:

- 📧 Email: support@surveybasket.com
- 🐛 [Open an issue](https://github.com/safaamohamed225/SurveyBasket.Api/issues)
- 💬 [Start a discussion](https://github.com/safaamohamed225/SurveyBasket.Api/discussions)

---
