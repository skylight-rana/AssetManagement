**Asset Management System - Backend (ASP.NET Core Web API)**
This is the backend API for the Asset Management System, built using ASP.NET Core Web API, Entity Framework Core, and SQL Server.

The system allows organizations to manage assets, employees, assignments, IT tickets, maintenance logs, and documents using a clean and scalable architecture.

**Project Overview**
The backend provides RESTful APIs to:

- Manage employees and authentication
- Perform asset CRUD operations
- Assign and return assets
- Handle IT support tickets
- Track maintenance logs
- Upload and manage documents

**Architecture**
This project follows a multi-layered architecture:

"Layers"
API Layer → Controllers (handles HTTP requests)
Service Layer → Business logic and validations
Repository Layer → Database operations
Data Layer → DbContext and EF Core configurations
Models Layer → Entities and DTOs

**Core Concepts Used**
Dependency Injection (DI)
Repository Pattern
DTO Pattern
Entity Framework Core (Code First)
RESTful API Design
File Handling (Upload & Storage)

**Tech Stack**
ASP.NET Core Web API
Entity Framework Core
SQL Server
Swagger (API Testing)

**Features**
👤 User & Authentication
Simple login API
Role-based users (Admin / Employee)
💻 Asset Management
Add, view, delete assets
Track asset status (Available / Assigned / UnderRepair)
🔄 Asset Assignment
Assign asset to employee
Track issue and return dates
Prevent duplicate assignment
Auto-update asset status
🎫 Ticket System
Employees raise issues
Admin updates status
Status flow: Open → InProgress → Resolved
🛠️ Maintenance Logs
Track repairs and upgrades
Store cost and descriptions
Maintain asset history
📄 Document Upload
Upload asset-related files
Store file path in database
Retrieve documents by asset

**Database Design**
Main Entities
- User
- Employee
- Asset
- AssetAssignment
- Ticket
- MaintenanceLog
  AssetDocument
The database is designed using a relational structure aligned with real-world workflows.

**Project Structure**
AssetManagement.Api           → Controllers
AssetManagement.Services      → Business Logic
AssetManagement.Repositories  → Data Access
AssetManagement.Data          → DbContext
AssetManagement.Models        → Entities & DTOs

**Important Notes**
File uploads are stored in a local Uploads/ folder
Only file paths are stored in the database
No JWT authentication (kept simple for learning purpose)

**Author**
Rana Pratap Singh
