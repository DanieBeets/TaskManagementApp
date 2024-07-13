# Task Management Backend

The task management app backend API

# Running Database Migrations From VS2022
Ensure that you have a reference to 'Microsoft.EntityFrameworkCore.Tools'. Then from package manager console run:

```
Add-Migration <MigrationName>
Update-Database
```

# Running Database Migrations From CLI
From a terminal run:

```
dotnet ef migrations add <MigrationName>
dotnet ef database update
```
