<div align="center">

<img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/>
<img src="https://img.shields.io/badge/Entity_Framework_Core-8.0-512BD4?style=for-the-badge&logo=nuget&logoColor=white"/>
<img src="https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white"/>
<img src="https://img.shields.io/badge/Bootstrap-5-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white"/>
<img src="https://img.shields.io/badge/JWT-000000?style=for-the-badge&logo=jsonwebtokens&logoColor=white"/>

<br/><br/>

# 📊 PublicSurvey

**A social survey platform where authors, companies, and commentators connect — share posts, follow users, like, comment, and chat.**

</div>

---

## 🚀 Features

| Feature | Description |
|---|---|
| 👤 **Role-Based Access** | Author, Boss, Commentator and Admin roles with separate flows |
| 📝 **Post System** | Create global or local posts, like and comment |
| 💬 **Direct Messaging** | Real-time chat between users |
| 🔍 **User Search** | AJAX-powered live search by name or surname |
| 🏢 **Company Management** | Bosses can create companies; authors can join them |
| ✅ **Membership Approval** | Admin confirms user memberships before activation |
| 🛡️ **Admin Panel** | Full user and role management dashboard |
| 🔐 **JWT Auth** | Secure API endpoints with JWT Bearer tokens |

---

## 🛠️ Tech Stack

### Backend
- **ASP.NET Core MVC** (.NET 8) — server-side rendering with Razor views
- **Entity Framework Core 8** — Code-First database management
- **ASP.NET Core Identity** — authentication & role-based authorization (RBAC)
- **JWT Bearer Token** — secure REST API authentication
- **AutoMapper** — clean Entity ↔ DTO mapping

### Frontend
- **Bootstrap 5** + **Font Awesome 6** — responsive & modern UI
- **jQuery** + **AJAX** — live user search without page reload

### Architecture
- **N-Tier Layered Architecture** (Presentation → Services → Repositories → Entities)
- **Repository Pattern** — abstracted data access layer
- **Unit of Work Pattern** — consistent transaction management
- **View Components** — modular, reusable UI blocks

---

## 🏗️ Project Structure

```
PublicSurvey/
├── Survey/           # Main app — controllers, views, program.cs
├── Services/         # Business logic layer
├── Repositories/     # Data access layer (EF Core)
├── Entities/         # Domain models & DTOs
├── Presentation/     # API controllers
└── Benimkiler/       # Shared utilities & enums
```

---

## 👥 User Roles

```
SurveyUser (base)
├── Author       → Creates and publishes posts
├── Boss         → Manages a company, publishes posts
├── Commentator  → Reads and comments on posts
└── Admin        → Full platform management
```

---

## ⚙️ Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Run

```bash
git clone https://github.com/mboyr4z/Public_Survey.git
cd Public_Survey/Survey
dotnet run
```

Open your browser at `https://localhost:5001`

---

## 📸 Screenshots

> _(Add screenshots here)_

---

<div align="center">

Made with ❤️ using ASP.NET Core

</div>
