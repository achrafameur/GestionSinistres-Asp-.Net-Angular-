# Welcome to Insurise project 

## Architecture
We adopted onion architecture based on a [template](https://github.com/ardalis/CleanArchitecture) created by [Adralis](https://github.com/ardalis).

The Onion Architecture is an Architectural Pattern that enables maintainable and evolutionary enterprise systems

![!](Docs/images/onion_architecture.jpg)

### Core
The Core project is the center of the Onion Architecture design, and all other project dependencies should point toward. As such, it has very few
external dependencies. In fact, this project encapsulates both the domain model and domain services layer.

A domain model is a structured visual representation of interconnected concepts or real-world objects that incorporates vocabulary, key concepts, 
behavior, and relationships of all of its entities. The domain services provide a place in the model to hold behavior that does not belong
elsewhere in the domain. They may be used in orchestrating workflow like transfer between accounts or process order.

The Core project should include components like:
- Entities
- Aggregates
- Domain events
- Event Handlers
- Interfaces


### Application
The Application projects represents the Application Services layer in The onion architecture. It reference the the Core project and implements its interfaces.

In general, in this project we define:
- DTOs
- Exceptions
- Services (not domain)
- Implementations of core interfaces

### Infrastructure
Contains most of our application's dependencies on external resources such as database and third party apis which are defined in classes implementing interfaces
defined in Core. It includes data access and domain event implementations, but we would also add things like email providers, identity provider, web api clients,
etc. to this project so they're not adding coupling to the Core or API projects.

### Api
Represents our application entry point. It is based on WEB Api template. It includes system configuration and register dependencies.

### Shared kernel
Part of the model that is shared by two or more teams, who agree not to change it without collaboration. Usually it contains basic abstractions that may be used
in different solutions along with cross-cutting concerns ones.