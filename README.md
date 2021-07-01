## Install Dependencies

1. `dotnet tool install dotnet-ef -g --version 5.0.5`
2. `dotnet add package Pomelo.EntityFrameworkCore.MySql --version 5.0.0`
3. `dotnet add package Pomelo.EntityFrameworkCore.MySql.Desing --version 1.1.2`
4. `dotnet add package Microsoft.EntityFrameworkCore --version 5.0.6`
5. `dotnet add package Microsoft.EntityFrameworkCore.Desing --version 5.0.6`
6. `dotnet add package Microsoft.Windows.Compatibility --version 3.0.0`

## Building Data Base

1. `dotnet ef migrations add DBv1`
2. `dotnet ef database update`