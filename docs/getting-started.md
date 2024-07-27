# Getting Started

To get started with Pizza-Com, follow these steps:

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) 8.0 or later
- [PostgreSQL Server](https://www.postgresql.org/download/) or another database

### Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/olexandr-harmash/Pizza-Com.git
    cd pizza-com
    ```

2. **Set up the database:**

    - Create a new database in your preferred database management system.
    - Update the connection string in the `appsettings.json` file to point to your database.

3. **Build and run the application:**

    ```bash
    dotnet build
    dotnet run
    ```

4. **Navigate to the web application:**

    Open your browser and go to `http://localhost:5000`.

### Running Tests

To run the tests for Pizza-Com, use the following command:

```bash
dotnet test
```

### Running Doc

To run the doc for Pizza-Com, use the following command:

```bash
dotnet tool update -g docfx
docfx metadata
docfx build
docfx serve _site
```