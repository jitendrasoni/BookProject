# Book  Project

This is a sample .NET MVC project for managing books. It demonstrates the use of the Repository Pattern and Service Pattern for data access and business logic, respectively.

## Project Structure

The project follows a typical MVC structure, with the following main components:

- **Controllers**: Contains MVC controller classes responsible for handling incoming requests and invoking services.
- **Models**: Contains model classes that represent the application's domain entities, such as Book.
- **Repositories**: Contains interfaces and implementations for data access. The `IBookRepository` interface defines the contract for interacting with book data, while `BookRepository` provides the implementation of data access logic.
- **Services**: Contains interfaces and implementations for business logic. The `IBookService` interface defines methods for interacting with books at a higher level, while `BookService` provides the implementation of business logic using repositories.
- **Views**: Contains the view templates organized by controller. Views are responsible for rendering HTML content to the client based on data provided by controllers.
- **App_Start**: Contains configuration files and classes that are executed on application startup, such as route configuration, filter configuration, etc.

## Getting Started

To run the project locally, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution file (`MyBookLibrary.sln`) in Visual Studio.
3. Build the solution to restore NuGet packages and compile the project.
4. Set the `MyBookLibrary` project as the startup project.
5. Press F5 to run the project in debug mode.
