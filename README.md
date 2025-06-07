# KnowledgeCheck

A structured and scalable backend platform for managing knowledge testing, built with **ASP.NET Core Web API**, following a **clean layered architecture**.  
This solution is designed to support user authentication, question management, test assignments, and result tracking — all via RESTful endpoints.

---

## 📐 Project Architecture

The project follows a 4-layer architecture for separation of concerns:

- **KnowledgeCheck.API** → REST API endpoints
- **KnowledgeCheck.BLL** → Business logic (DTOs, Services, Validation)
- **KnowledgeCheck.DAL** → Data access (Models, DbContext, Repositories)
- **KnowledgeCheck.JWT** → Authentication (JWT, ASP.NET Identity)

Each layer has a clear responsibility and communicates only with adjacent layers to maintain modularity and testability.

---

## 🔧 Technologies Used

- **ASP.NET Core 8** (Web API)
- **Entity Framework Core** (Code-First)
- **PostgreSQL** (via `Npgsql` provider)
- **Mapster** (for DTO ↔ Entity mapping)
- **ASP.NET Identity** for user management
- **JWT (JSON Web Tokens)** for authentication/authorization
- **FluentValidation** for DTO validation
- **Swagger** (OpenAPI) for API testing
- **Postman** (for API development/debugging)

---

## 🎯 Core Features

| Module        | Description                                                                 |
|---------------|-----------------------------------------------------------------------------|
| Authentication| JWT-based login & registration (via `KnowledgeCheck.JWT`)                  |
| Users         | CRUD for users, roles, permissions                                          |
| Questions     | Create/update/delete questions, with options and correct answers            |
| Tests         | Assign questions into tests, define timing and structure                    |
| Results       | Submit answers, calculate score, show feedback                             |

---

## 🧱 Folder Structure

