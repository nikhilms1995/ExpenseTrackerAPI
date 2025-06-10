# Expense Tracker API

This is a secure and modular ASP.NET Core Web API designed for tracking personal expenses. The project implements the CQRS (Command Query Responsibility Segregation) pattern and authentication is handled via JSON Web Tokens (JWT).

The main objectice was to practice JWT based authentication and implement CQRS.

## Features

- User Registration and Login with JWT-based authentication
- Expense operations:
  - Create, update, delete expenses
  - Retrieve expenses by user
- CQRS pattern for clear separation of concerns
- EF Core with Code-First approach
- Token-based authentication and authorization
- Logging and centralized error handling

## Project Structure
ExpenseTracker.API/
│
├── Controllers/ # API endpoints
├── Features/ # Commands, Queries, and Handlers
├── Domain/ # Core domain models and repository interfaces
├── Infrastructure/ # EF DbContext, Repositories, JWT utilities
├── Common/ # Shared helpers, exceptions, validations
├── Migrations/ # EF Core migrations
├── Program.cs # Application entry and configuration

## Tech Stack

- ASP.NET Core 8 Web API
- Entity Framework Core (Code-First)
- MediatR (for CQRS)
- JWT Authentication

## Authentication Flow
Upon registration, a JWT token is generated and returned.

The same applies for login; the token is returned if credentials are valid.

For protected endpoints, the token must be passed in the Authorization header using the Bearer scheme.

Optionally, a refresh token system can be introduced for renewing expired tokens.

## Potential Enhancements
Implement refresh tokens with HttpOnly cookie storage

Support expense categories, reports, and recurring entries

Integrate with external budgeting APIs or tools
