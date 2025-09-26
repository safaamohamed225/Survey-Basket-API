# VoteHub API 📊

## 🛠️ Tech Stack

### 🔹 Backend
[![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)](https://dotnet.microsoft.com/download)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-9.0-blue.svg)](https://docs.microsoft.com/en-us/aspnet/core/)
[![ASP.NET Core Web API](https://img.shields.io/badge/ASP.NET-Core%20Web%20API-blueviolet.svg)](https://learn.microsoft.com/en-us/aspnet/core/web-api)
[![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework-Core-orange.svg)](https://docs.microsoft.com/en-us/ef/core/)
[![LINQ](https://img.shields.io/badge/LINQ-Query-blue.svg)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927.svg?logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)

---

### 🔹 Security
[![ASP.NET Identity](https://img.shields.io/badge/ASP.NET-Identity-2C3E50.svg)](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity)
[![JWT Authentication](https://img.shields.io/badge/JWT-Authentication-000000.svg?logo=jsonwebtokens)](https://jwt.io/)
[![Refresh Token](https://img.shields.io/badge/Token-Refresh-lightgrey.svg)](#)
[![Roles & Permissions](https://img.shields.io/badge/Role%20&%20Permission-Management-yellowgreen.svg)](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/roles)
[![CORS](https://img.shields.io/badge/CORS-Enabled-informational.svg)](https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS)

---

### 🔹 Architecture & Patterns
[![Repository Pattern](https://img.shields.io/badge/Repository-Pattern-orange.svg)](https://martinfowler.com/eaaCatalog/repository.html)
[![Unit of Work](https://img.shields.io/badge/Unit%20of%20Work-Pattern-lightgrey.svg)](https://martinfowler.com/eaaCatalog/unitOfWork.html)
[![Dependency Injection](https://img.shields.io/badge/Dependency-Injection-6DB33F.svg)](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
[![AutoMapper](https://img.shields.io/badge/AutoMapper-Tool-ff69b4.svg)](https://automapper.org/)

---

### 🔹 Tools & Features
[![Error Handling](https://img.shields.io/badge/Exception%20&%20Error-Handling-red.svg)](#)
[![Hangfire](https://img.shields.io/badge/Hangfire-Background%20Jobs-5C2D91.svg)](https://www.hangfire.io/)
[![OpenAPI](https://img.shields.io/badge/OpenAPI-Swagger-85EA2D.svg?logo=swagger&logoColor=black)](https://swagger.io/specification/)
[![MailKit](https://img.shields.io/badge/MailKit-Email%20Service-0078D4.svg)](https://github.com/jstedfast/MailKit)
[![Caching](https://img.shields.io/badge/Caching-Enabled-yellow.svg)](#)
[![Pagination](https://img.shields.io/badge/Pagination-Supported-blue.svg)](#)
[![Filtering & Sorting](https://img.shields.io/badge/Filtering%20&%20Sorting-Supported-lightblue.svg)](#)
[![Health Monitoring](https://img.shields.io/badge/Health-Monitoring-brightgreen.svg)](https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks)
[![Logging](https://img.shields.io/badge/Logging-Enabled-9cf.svg)](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/)

---

### 🔹 License
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)


A robust and scalable RESTful API built with ASP.NET Core for comprehensive poll management and voting systems. Features enterprise-grade security, role-based access control, and a clean architecture designed for maintainability and extensibility.

<img width="764" height="552" alt="MindMap" src="https://github.com/user-attachments/assets/dc3a6c6f-5e4b-456e-9193-dbf49d0c1d56" />
<br/>
<br/>

## 🌟 Database Diagram:


<img width="773" height="632" alt="Design" src="https://github.com/user-attachments/assets/da1817b9-93df-4185-8b22-94760f8cc268" />




## 🌟 Glimpse of the working solution: 🌟

<img width="1269" height="733" alt="1" src="https://github.com/user-attachments/assets/89e0fac1-6de0-4418-b68c-f0d87410f1c0" />
<img width="1264" height="380" alt="Users" src="https://github.com/user-attachments/assets/d5e35499-1e7a-41d1-a717-46cd7e31e78d" />

<img width="1265" height="655" alt="2" src="https://github.com/user-attachments/assets/e5c2f699-aa60-4060-a401-0666137db6b6" />
<img width="1105" height="328" alt="3" src="https://github.com/user-attachments/assets/c52acffb-35f9-4f9d-8782-884c895e9a76" />


<img width="1118" height="855" alt="4" src="https://github.com/user-attachments/assets/e930b7b8-4494-4890-909d-babac70966f4" />

<img width="1125" height="558" alt="6" src="https://github.com/user-attachments/assets/7fd06227-98cb-475b-b0fb-ccb0abd76180" />





## 🌟 Key Features

### 📝 Poll Management
- **Full CRUD Operations** for polls and questions  
- **Dynamic Poll Creation** with flexible question types  
- **Vote Collection** and validation  
- **Poll Analytics** and comprehensive reporting  
- **Publish/Unpublish** polls with status management  

### 🔐 Security & Authentication
- **ASP.NET Core Identity** integration  
- **JWT Authentication** with refresh token support  
- **Role-Based Access Control (RBAC)** with granular permissions  
- **User & Role Management** (Admin, Creator, Voter)  
- **Secure API endpoints** with authorization policies  

### ⚙️ System & API Features
- **Entity Framework Core & LINQ** for efficient data access  
- **OpenAPI (Swagger)** for interactive API documentation  
- **API Versioning** for backward compatibility  
- **Rate Limiting** to prevent API abuse  
- **Pagination, Filtering & Sorting** for large datasets  
- **Caching** for performance optimization  
- **Logging & Exception Handling** for monitoring & debugging  
- **Background Jobs** for scheduled or async tasks  
- **Health Checks** for system reliability  


### 🏗️ Architecture & Design
- **Clean Architecture** principles
- **Repository Pattern** for data access
- **Service Layer** for business logic
- **AutoMapper** for object mapping
- **Comprehensive error handling** and logging

## 🛠️ Tech Stack

| Technology | Purpose |
|------------|---------|
| **ASP.NET Core 9.0** | Web API Framework |
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
│   ├── PollsController.cs   # Poll management
│   ├── QuestionsController.cs # Question management
│   ├── VotesController.cs   # Voting endpoints
│   ├── ResultsController.cs # Analytics and results
│   └── AccountController.cs # User account management
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

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB for development)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/safaamohamed225/SurveyBasket.Api.git
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
   - API: `https://localhost:7196`
   - Swagger UI: `https://localhost:7196/swagger`

## 📖 API Documentation

This project uses **Swagger UI** for API documentation.  
You can explore and test the API endpoints by running the project and navigating to:

👉 https://localhost:{port}/swagger


⚡ Note: Swagger is enabled by default in **Development** environment.  
To enable it in **Production**, you need to update the `Program.cs` configuration.


### Authentication Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `POST` | `/auth/register` | Register new user |
| `POST` | `/auth/login` | User login |
| `POST` | `/auth/refresh` | Refresh JWT token |
| `POST` | `/auth/revoke-refresh-token` | Revoke refresh token |
| `POST` | `/auth/confirm-email` | Confirm user email |
| `POST` | `/auth/resend-confirmation-email` | Resend confirmation email |
| `POST` | `/auth/forget-password` | Request password reset |
| `POST` | `/auth/reset-password` | Reset user password |

### Account Management

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/me` | Get current user info | ✅ |
| `PUT` | `/me/info` | Update user profile | ✅ |
| `PUT` | `/me/change-password` | Change user password | ✅ |

### Polls (Surveys) Management

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/Polls` | Get all polls | ✅ |
| `POST` | `/api/Polls` | Create new poll | ✅ (Admin) |
| `GET` | `/api/Polls/current` | Get current active polls | ✅ |
| `GET` | `/api/Polls/{id}` | Get poll by ID | ✅ |
| `PUT` | `/api/Polls/{id}` | Update poll | ✅ (Admin/Owner) |
| `DELETE` | `/api/Polls/{id}` | Delete poll | ✅ (Admin/Owner) |
| `PUT` | `/api/Polls/{id}/togglePublish` | Toggle poll publish status | ✅ (Admin/Owner) |

### Questions Management

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/polls/{pollId}/Questions` | Get poll questions | ✅ |
| `POST` | `/api/polls/{pollId}/Questions` | Add question to poll | ✅ (Admin/Owner) |
| `GET` | `/api/polls/{pollId}/Questions/{id}` | Get question by ID | ✅ |
| `PUT` | `/api/polls/{pollId}/Questions/{id}` | Update question | ✅ (Admin/Owner) |
| `PUT` | `/api/polls/{pollId}/Questions/{id}/toggleStatus` | Toggle question status | ✅ (Admin/Owner) |

### Voting & Results

| Method | Endpoint | Description | Auth Required |
|--------|----------|-------------|---------------|
| `GET` | `/api/polls/{pollId}/vote` | Get voting form | ✅ |
| `POST` | `/api/polls/{pollId}/vote` | Submit vote | ✅ |
| `GET` | `/api/polls/{pollId}/Results/row-data` | Get raw results data | ✅ (Admin/Owner) |
| `GET` | `/api/polls/{pollId}/Results/votes-per-day` | Get votes per day statistics | ✅ (Admin/Owner) |
| `GET` | `/api/polls/{pollId}/Results/votes-per-question` | Get votes per question | ✅ (Admin/Owner) |

## 🔑 Authentication & Authorization

### JWT Configuration

The API uses JWT tokens for authentication. Include the token in the Authorization header:

```http
Authorization: Bearer <your-jwt-token>
```

### User Roles

| Role | Permissions |
|------|-------------|
| **Admin** | Full access to all polls, questions, and results |
| **PollCreator** | Create, edit, and manage own polls |
| **Voter** | Submit votes to published polls |

## 📊 Sample Requests

### Register User
```http
POST /auth/register
Content-Type: application/json

{
  "email": "safa1225@mail.com",
  "password": "Safa$12225",
  "firstName": "Safa",
  "lastName": "Muhammad"
}
```

### Login User
```http
POST /auth/login
Content-Type: application/json

{
  "email": "safamm@mail.com",
  "password": "Safa$12225"
}
```

### Create Poll
```http
POST /api/Polls
Authorization: Bearer <token>
Content-Type: application/json

{
  "title": "Customer Satisfaction Survey",
  "summary": "Help us improve our services",
  "startsAt": "2024-01-01T00:00:00Z",
  "endsAt": "2024-12-31T23:59:59Z"
}
```

### Submit Vote
```http
POST /api/polls/{pollId}/vote
Authorization: Bearer <token>
Content-Type: application/json

{
  "answers": [
    {
      "questionId": 1,
      "answer": "Very Satisfied"
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

This project is developed and maintained solely by **Safaa Muhammad**.  
Currently, external contributions are not accepted.


## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

- Safaa Muhammad  
  - [GitHub](https://github.com/safaamohamed225)  
  - [LinkedIn](https://www.linkedin.com/in/safa-mohamed-dotnet/)   

## 🙏 Acknowledgments
This project was developed individually with the support of amazing open-source tools and frameworks:

- ASP.NET Core for the excellent framework
- Entity Framework Core for robust data access
- The open-source community for inspiration

