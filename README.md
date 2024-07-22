# Pizza-Com

Pizza-Com is a domain-driven design web app service that provides a pizza catalog and allows building orders for specific customers.

## Features

- **Pizza Catalog**: Browse a variety of pizzas with detailed descriptions, ingredients, and prices.
- **Order Building**: Customize your order by selecting from the available pizza options.
- **Customer-Specific Orders**: Tailor orders to meet specific customer preferences and requirements.

## Getting Started

To get started with Pizza-Com, follow these steps:

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) 8.0 or later
- [PostgreSQL Server](https://www.postgresql.org/download/) or another database

### Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/your-username/pizza-com.git
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

### Contributing

Contributions are welcome! Please read the `CONTRIBUTING.md` file for more information on how to contribute to this project.