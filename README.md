# QuizApp

An interactive quiz application built with **ASP.NET Core (Razor Pages)** and **Entity Framework Core**. The app allows users to take multiple-choice quizzes, records attempts, and calculates results. Designed with a clean architecture separating **Models**, **Services**, and **ViewModels** for maintainability.

---

## ✨ Features

- 📝 Create and manage quizzes with questions and answer options  
- 🎯 Attempt quizzes and track user answers  
- 📊 Automatic scoring and quiz attempt history  
- 🗄️ EF Core database with migrations (`ApplicationDbContext`)  
- 🎨 Razor Pages front-end with shared layouts and partials  
- ⚡ Modular architecture with **Models**, **Services**, and **ViewModels**

---

## 🛠 Tech Stack

- **ASP.NET Core 7/8** (Razor Pages)  
- **Entity Framework Core** (SQL database, migrations)  
- **C#** (backend logic, models, services)  
- **Razor Pages (.cshtml)** for UI  
- **wwwroot** (CSS, JS, static assets)  

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/en-us/download) (7 or 8 recommended)  
- (Optional) SQL Server / SQLite  
- Git  

### Clone & Run

```bash
git clone https://github.com/bocongamco/QuizApp.git
cd QuizApp

# Restore dependencies
dotnet restore

# Apply database migrations
dotnet ef database update

# Build & run
dotnet run
```

The app will start on:  
👉 `http://localhost:5000` or `http://localhost:5187`

---

## 📂 Project Structure

```
QuizApp/
├─ Data/
│  ├─ ApplicationDbContext.cs     # EF Core DB context
│  └─ Configuration/              # DB config (if any)
│
├─ Migrations/                    # EF Core migrations
│
├─ Models/                        # Domain models
│  ├─ Quiz.cs
│  ├─ Question.cs
│  ├─ AnswerOption.cs
│  ├─ QuizAttempt.cs
│  └─ QuizAttemptAnswer.cs
│
├─ Pages/                         # Razor Pages (.cshtml)
│  ├─ Account/                    # (Auth-related pages, if any)
│  ├─ Error/                      # Error handling
│  ├─ Quizzes/                    # Quiz pages (listing, taking quizzes)
│  ├─ Shared/                     # Shared UI (_Layout, partials)
│  ├─ Index.cshtml                # Landing page
│  └─ Privacy.cshtml              # Privacy policy
│
├─ Services/                      # Business logic services
├─ ViewModel/                     # Data transfer & binding between UI and Models
├─ wwwroot/                       # Static assets (css, js, images)
│
├─ Program.cs                     # App entry, DI, and middleware setup
├─ appsettings.json               # Main config
├─ appsettings.Development.json   # Dev-specific config
├─ libman.json                    # Client-side lib management
└─ QuizApp.csproj                 # Project file
```

---

## ⚙️ Configuration

- **Database connection string**: set in `appsettings.json`  
- **Development overrides**: `appsettings.Development.json`  
- Run migrations to create/update schema:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## 📌 Development Notes

- Add new quizzes by updating **Models/Services** and creating UI in `Pages/Quizzes/`.  
- Use **ViewModels** to separate UI state from database models.  
- Register services (e.g., `QuizService`) in `Program.cs` with dependency injection.  
- Static content (CSS/JS) goes in `wwwroot/`.  

---

## 🧪 Testing

Add a test project, then run:

```bash
dotnet test
```

---

## 📄 License

MIT (or add your own license file).

---

## 🙌 Acknowledgements

- ASP.NET Core Docs  
- Entity Framework Core Docs  
- Contributors & testers  

---

⚡ Built with **ASP.NET Core + EF Core** for modern, interactive quiz apps.
