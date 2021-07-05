REM change directory to eKart directory
cd eKart
REM creates an empty solution
dotnet new sln --name eKart
REM creates an ASP.NET Core web api project
dotnet new webapi --name eKart.Api
REM adds both the projects to the solution
dotnet sln add .\eKart.Api\eKart.Api.csproj
dotnet restore .\eKart.Api\eKart.Api.csproj
dotnet build .\eKart.Api\eKart.Api.csproj

dotnet add package Swashbuckle.AspNetCore

dotnet build --project .\eKart.Api\eKart.Api.csproj
dotnet run --project .\eKart.Api\eKart.Api.csproj

dotnet add package Microsoft.EntityFrameworkCore.SqlServer