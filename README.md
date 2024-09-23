## 🛒 Product Management App

### Overview
A full-stack product management application built with:
- **Vue.js (Vite)** for the front-end, enabling users to perform **CRUD operations** on products.
- **.NET 6 Web API** with **Dapper** and a layered architecture (Domain, Data Access, Infrastructure) for efficient data access from an SQL Server database.
- **Axios** for handling HTTP requests from the Vue front-end to the .NET API.

This project demonstrates how to build a robust, scalable full-stack application using a layered architecture, with **CORS-enabled** communication between a front-end app and a back-end API.

### Folder Structure (Backend)

- **ProductsApi**: The entry point for the API project, handling HTTP requests and routing.
- **DataAccess**: Contains the database interaction logic using **Dapper** to manage CRUD operations.
- **Domain**: Holds core business models and entities.
- **Infrastructure**: Manages cross-cutting concerns such as configuration, logging, and possibly other services.

### Features
- **Vue.js Front-End**: Built using the Composition API and Pinia for state management.
- **CRUD Operations**: Create, read, update, and delete products directly from the Vue front-end.
- **.NET 6 API**: A back-end API built with a layered architecture, using Dapper for efficient database access and separation of concerns.
- **Axios**: Manages API calls from the front-end with support for environment-based configurations.
- **CORS**: Cross-origin requests are enabled to ensure smooth communication between the Vue front-end and the .NET back-end.
- **SQL Server**: Stores and retrieves product data.

### Technologies Used
- **Front-End**: Vue 3, Vite, Pinia, Axios
- **Back-End**: .NET 6, Dapper, SQL Server
- **Architecture**: Layered architecture with separate projects for Data Access, Domain, and Infrastructure
- **Tools**: Axios, CORS, Environment Variables, TypeScript (optional)

### Running the Project
1. **Back-End Setup**:
   - Ensure you have a running **SQL Server** instance.
   - Create a database with a `Products` table.
   - Start the .NET API with the following commands:
     ```bash
     dotnet restore
     dotnet run --project ProductsApi
     ```

2. **Front-End Setup**:
   - Configure the API base URL in the `.env` file for the Vue app:
     ```
     VITE_APP_API_BASE_URL=https://localhost:7106/api/
     ```
   - Start the front-end app with the following commands:
     ```bash
     npm install
     npm run dev
     ```

### Backend Solution Structure
```
/ProductsApi (Solution)
/DataAccess      # Handles data access using Dapper
/Domain          # Contains business models and entities
/Infrastructure  # Manages cross-cutting concerns like configuration and logging
/ProductsApi     # API controllers and entry point
```

### Frontend Structure
```
/frontend (Vue.js)
  /src
    /assets
    /components
    /views
    /stores
    axios.ts
  .env
  package.json
```

### Future Enhancements
- **Authentication**: Add JWT-based authentication for secure access.
- **Pagination**: Implement pagination for the product list.
- **Deployment**: Configure CI/CD for automatic deployment.
- **Notification**: Adding notification via Azure Service bus and cosmos db.

---

