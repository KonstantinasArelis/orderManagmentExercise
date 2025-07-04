# OrderManagmentExercise
This attempt to complete exercise https://github.com/erinev/order-management-api-exercise .

## Steps To Run:
1. Configure database connection by modifying `DefaultConnection` in `appsettings.Development.Json`. This solution uses PosgreSQL, ensure the database exists.
2. Apply Entity Framework migrations by running this command in the root folder: `dotnet ef database update --startup-project OrderManagment.API --project OrderManagment.DataAccess`
3. Build and run the project either by:
   1. Run`cd OrderManagment.API` from solution root, then `dotnet run`
   2. Or by clicking run in VSCode IDE from the API project.

Swagger can be conveniently used to test the API.

## Functiontal Requirments
I managed to complete all functional requirments which resulted in 8 endpoints.

## Non Functional Requirments
All non functional requirments are met too.
Systems uses a persistance layer (`OrderManagment.DataAccess`) with PostgreSQL.
Request are validated with model and attribute-based validation.
Solution uses dotnet 8.

## Bonus
1. Restful api.
2. System uses asyncronous methods to improve performance.
3. Api documentation is included with `Swagger.json`.
4. Code is structured using N-Tier architecture, with the addition of `OrderManagment.Contracts` project, which holds DTO's for API/BusinessLogic communication.
5. Project has commit history.
6. Project has comments in more complex places.

## Post Deadline
1. Added CI/CD:
   1. CI and containerization via github actions and docker. Docker image: `konstantinasarelis/order-management-exercise-api:latest`
   2. CD via Render. Try it out: `https://order-management-exercise-api.onrender.com/swagger/index.html`. You may encounter up to a minute delay for first request.

## Project Is Missing
1. Automated tests
2. GraphQL endpoint
