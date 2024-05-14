# Contacts Api with Identity 
Simple contacts managment api for training asp.net core using Identity for auth. Every user of the API has a set of associated 
contacts. The users can get, delete, and update the contacts that are associated with their username. The age of the contacts must be greater than 18.

## Architecture:
The application follows a 3-tier architecture, comprising the following layers:

### DataAccess Layer (DataAccess):
This layer contains the definitions of entity sets present in the SQL Server database.
It defines the EF Core context used for communication with the database server.
The defined entity sets include:

- Contact:
  - Id: GUID
  - FirstName: string (128 chars)
  - LastName: string (128 chars)
  - Email: string (128 chars)
  - DateOfBirth: DateTime
  - Phone: string (20 chars)
  - Owner: string. This property points to the Id of an IdentityUser of Identity
    
Additionally, this layer implements a set of repositories to decouple the application from the data persistence mechanism.

### BusinessLogic Layer:
In this layer, all business logic is implemented, and data validation occurs.
Two Data Transfer Objects (DTOs) are implemented:
- One for receiving contact data that the user wants to add or update.
- Another for responding to user GET requests.

The response DTO includes an additional field called “Age” which stores the contact’s age calculated from their date of birth.
The ContactService acts as an intermediary between the Presentation layer requests and the repositories. It also handles data validation before storage.
The Result pattern is used to return query results from the database to the Presentation layer.

### Presentation Layer:
This layer houses the API controllers.
Authentication is utilized with Identity using Cookies and Bearer Tokens.

## Testing
Due to time constraints, the integration tests and unit tests have not yet been included.
