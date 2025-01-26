
# Aircraft Management API

## Overview

The Aircraft Management API is a simple and robust web API designed for managing aircraft-related data. Built using **ASP.NET Core 7** and integrated with **PostgreSQL**, this API offers features like authentication, authorization, and seamless interaction with the database using Entity Framework Core.

## Features

-   **JWT Authentication & Authorization**:
    -   Secure access to endpoints using JSON Web Tokens (JWT).
    -   Role-based user management with ASP.NET Identity.
-   **Database Integration**:
    -   Utilizes PostgreSQL as the database provider.
    -   Database interaction is implemented through Entity Framework Core.
-   **Swagger Integration**:
    -   Interactive API documentation using Swagger UI.
    -   Easy testing of API endpoints with JWT token support.

## Technologies Used

-   **.NET Version**: 7.0
-   **Database**: PostgreSQL
-   **ORM**: Entity Framework Core
-   **Authentication**: ASP.NET Identity with JWT Bearer Authentication
-   **API Documentation**: Swagger (Swashbuckle)

## Getting Started

### Prerequisites

-   [.NET 7 SDK](https://dotnet.microsoft.com/download)
-   [PostgreSQL](https://www.postgresql.org/download/)

### Setup

1.  **Clone the Repository**
    
    
2.  **Configure Database Connection**
    
    -   Update the connection string in `appsettings.json`:
        
        ```json
        "ConnectionStrings": {
          "DefaultConnectionString": "Host=localhost;Port=5432;Database=AircraftDB;Username=yourusername;Password=yourpassword"
        }
        
        ```
        
3.  **Apply Migrations**
    
    -   Ensure the database is created and up-to-date:
        
4.  **Run the Application**
    
    The application will be available at `https://localhost:5001`.
    

## Authentication & Authorization

-   **JWT Bearer Tokens**:
    -   Obtain a JWT token by authenticating with valid credentials.
    -   Pass the token in the `Authorization` header of API requests:
        
        ```
        Authorization: Bearer <your_token>
        
        ```
        

## API Documentation

-   Swagger UI is available at `https://localhost:5001/swagger`.
-   Use it to explore and test all available API endpoints.

## Dependencies

-   [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)
-   [Microsoft.AspNetCore.Identity.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore)
-   [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL)
-   [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore)
-   [Dapper](https://www.nuget.org/packages/Dapper)

## License

This project is open-source. Feel free to use and modify it for your own purposes.

## Contact

If you have any questions or suggestions, feel free to reach out: 
- **GitHub**: [andrunovostavskyi](https://github.com/andrunovostavskyi) 
- **LinkedIn**: https://www.linkedin.com/in/andriy-novostavskyi-073879325/
-  **Email**: novostavskuy@gmail.com
