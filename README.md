# VideoGameCharacterApi

A minimal ASP.NET Core Web API for managing video game characters. The project demonstrates a simple CRUD API using .NET 10, Entity Framework Core, and SQL Server.

## Features

- RESTful API for Create, Read, Update and Delete operations on video game characters
- Uses Entity Framework Core for data access
- OpenAPI/Scalar support for API documentation (enabled in Development)
- Centralized error handling that maps common exceptions to appropriate HTTP status codes

## Technology

- .NET 10
- ASP.NET Core Web API
- Entity Framework Core (EF Core)
- SQL Server (configured via connection string)

## Project structure (key files)

- Program.cs — application startup, DI registration, middleware and routing
- Data/AppDbContext.cs — EF Core DbContext (Characters DbSet)
- Models/Character.cs — EF entity for a video game character
- Dtos/*.cs — request/response DTOs (CreateCharacterRequest, UpdateCharacterRequest, CharacterResponse)
- Services/IVideoGameCharacterService.cs — service contract
- Services/VideoGameCharacterService.cs — service implementation (CRUD using AppDbContext)
- Controllers/VideoGameCharactersController.cs — API endpoints for characters
- Migrations/ — EF Core migrations for initializing the database

## Data model

Character entity fields:

- Id (int) — primary key
- Name (string)
- Game (string)
- Role (string)

## API Endpoints

- GET /api/VideoGameCharacters — Get all characters
- GET /api/VideoGameCharacters/{id} — Get a character by id
- POST /api/VideoGameCharacters — Create a new character (body: CreateCharacterRequest)
- PUT /api/VideoGameCharacters/{id} — Update an existing character (body: UpdateCharacterRequest)
- DELETE /api/VideoGameCharacters/{id} — Delete a character

Request/response DTOs are located in the Dtos folder and mirror the Character entity shape for client interactions.

## Getting started (local development)

Prerequisites:

- .NET 10 SDK
- SQL Server (local or remote)

Steps:

1. Clone the repository and open it in Visual Studio or your preferred IDE.
2. Configure a connection string named `DefaultConnection` in appsettings.Development.json or in User Secrets / environment variables. Example connection string (LocalDB):

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=VideoGameCharacterDb;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

3. Apply migrations and create the database (from project root):

   ```bash
   dotnet ef database update --project VideoGameCharacterApi
   ```

4. Run the application:

   ```bash
   dotnet run --project VideoGameCharacterApi
   ```

5. When running in Development the OpenAPI (Swagger) UI is available to explore endpoints.

## Error handling

The application uses a global exception handler (configured in Program.cs) that converts common exceptions to HTTP responses:

- ArgumentNullException => 400 Bad Request
- KeyNotFoundException => 404 Not Found
- InvalidOperationException => 409 Conflict
- Other exceptions => 500 Internal Server Error

## Migrations

EF Core migrations are included in the Migrations folder. To add a new migration:

```bash
dotnet ef migrations add <MigrationName> --project VideoGameCharacterApi
```

Then update the database:

```bash
dotnet ef database update --project VideoGameCharacterApi
```

## Contributing

Contributions are welcome. Please open an issue or submit a pull request with a clear description of the change.

## License

MIT License

Copyright (c) 2026 Ricardo Vega

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
