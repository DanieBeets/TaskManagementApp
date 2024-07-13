# Task Management Backend

The task management app backend API

# Running Database Migrations From VS2022
Ensure that you have a reference to 'Microsoft.EntityFrameworkCore.Tools'.

```
Add-Migration -Context TaskManagementDbContext -Name "MigrationName" -OutputDir "Data/Migrations"
Update-Database
```

# Script Migrations
```
Script-Migration -Context TaskManagementDbContext
```

# TODO
- Double check nullability of Data Models, API Models and API DTOs