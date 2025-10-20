# DotNetCoreWebStarter

A clean and modular .NET Core starter template using Onion Architecture. Includes Web API, Web App, and core modules for:

- ✅ User Management
- ✅ Menu Items
- ✅ Error Logging

Built for scalable and maintainable enterprise-grade applications using:

- ASP.NET Core (MVC & Web API)
- Entity Framework Core (Code-First)
- Identity (Authentication & Authorization)
- Tailwind CSS (Modern UI styling)
- Unit Testing (xUnit)

---

## 🛠 Prerequisites

Before running this project, ensure you have the following installed:

- [.NET 6 SDK or later](https://dotnet.microsoft.com/en-us/download)
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms)
- A running local or remote SQL Server instance

> ⚠️ **Note:** You must have a working SQL Server setup (e.g., accessible through SSMS) to run and test this project properly.

---

## ⚙️ Configuration

### 1. Update the Connection String

Open `appsettings.json` or `appsettings.Development.json` located in the `DotNetCoreWebStarter` project and update the `DefaultConnection` string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=DotNetCoreWebStarterDb;Trusted_Connection=True;MultipleActiveResultSets=true"
}


## 🧪 Database Setup

To apply the migrations and create the SQL Server database using Entity Framework Core, open a terminal or command prompt at the solution root and run the following command:

```bash
dotnet ef database update -p DotNetCoreWebStarter.Data -s DotNetCoreWebStarter.Web

## 🧾 Seed Default Data (Users, Roles, Menu Items)

Once your database is created, you can optionally run the provided SQL script to insert default data including roles, menu items, and a sample admin user.

### 📌 Script: `DefaultUsers_Roles_MenuItems.sql`

1. Open **SQL Server Management Studio (SSMS)**
2. Connect to your SQL Server instance
3. Open the file: `DefaultUsers_Roles_MenuItems.sql`
4. Run the script against the `DotNetCoreWebStarterDb` database (or the name you used in your connection string)

This script will insert:

- Default **roles**
- Default **menu items**
- A sample **Admin** user

### 🔐 Default Admin Credentials

```text
Username: admin
Password: Admin@123

