# Task Management Backend

The task management app backend API

# Running Database Migrations From VS2022
Ensure that you have a reference to 'Microsoft.EntityFrameworkCore.Tools'.

```
Add-Migration -Context AppDbContext -Name "MigrationName" -OutputDir "Data/Migrations"
Update-Database
```

# Script Migrations
```
Script-Migration -Context AppDbContext
```

# TODO
- Double check property nullability of Data Models, API Models and DTOs
- Paging for tasks