# A Pool Dinner Application Using 'Clean Architecture' & 'Domain Driven Design'

**Project Status**: Work-in-Progress

## Project Description

This project is a practical exploration of Clean Architecture and Domain-Driven Design (DDD) principles with a focus on Command Query Responsibility Segregation (CQRS). It serves as a valuable resource for anyone eager to learn these architectural and design concepts and their practical application.

The project is inspired by a YouTube video by 'Amichai Mantinband' and has been extended with my own implementation.

## Support Material for DDD
[Event Storming Document](https://www.figma.com/file/Xj1WCi3gBLszQvpkbXStYY/Pool-Dinner?type=design&node-id=0%3A1&mode=design&t=1Kb5xAMe5gCsns0b-1) on figma.

## Technologies Used

- .NET 7
- Mediatr
- Mapster
- Fluent Validation
- Entity Framework Core
- xUnit
- Moq
- Fluent Assertion

## Scope of Application

The application simulates a dinner pooling/ management system similar to services like Uber. Users can register as hosts or guests:

- **Hosts** can create dinners, each with one or multiple menus, a specific date, time slot, and a limit on the number of guests.
- **Guests** can join dinners hosted by others and enjoy meals together.
- Both hosts and guests can leave menu reviews.

## Getting Started

1. Clone this repository.
2. Build and run the application using .NET 7.
3. Explore the codebase to learn about Clean Architecture, DDD, and CQRS principles.

## Usage
**Endpoints**
- ```POST {{host}}/auth/register``` : Registers a new user and returns valid JWT.
- ```POST {{host}}/auth/login``` : Login user with valid token.
- ```POST {{host}}/hosts/{hostId}/menu``` : Creates new menu with the provided hostId.
- ```GET {{host}}/dinners``` : Fetch list of all the dinners.
- **Other endpoints are under progress**

## How to Contribute

**Contributions are not currently accepted for this project.**

## Contact
if you have any questions or suggestions, feel free to contact me at mehrozdurrani@gmail.com

## License

This project is licensed under the MIT License - see the [LICENSE](https://opensource.org/license/mit/) file for details.

**Note:** While you are free to clone and use this project for personal purposes, I do not accept contributions or provide support for custom modifications.
