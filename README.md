
# Restaurant WebAPI

This is an application that represents a restaurant developed on .NET 7 platform.

## Tech stack

### Server
- .NET 7 WebAPI
- PostgreSQL
- Entity Framework Core 7

### Features
- AutoMapper
- CQRS + MediatR
- XUnit

### Software
- Swagger
- Docker


## What does it do?
- Send CRUD requests for various products (burgers, drinks etc).
- Authentication and authorization based on a JWT token and a refresh token are available.
- It is possible to create orders and add them to the user's cart.

## Architecture

The application uses a clean (onion) architecture:

- Core layer (Domain, Application)
- Infrastructure layer(Persistence)
- Presentation Layer (WebAPI)

Testing is also used in the application (XUnit).
