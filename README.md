# StockMaster

StockMaster is a simple, lightweight stock management system that allows businesses to track their inventory, manage product movements, suppliers, customers, and sales orders. This project is built using ASP.NET Core with Entity Framework for database access.

## Features

- **Product Management**: Add, edit, and remove products from your inventory. Track details such as barcode, stock quantity, price, supplier, and category.
- **Supplier Management**: Maintain a list of suppliers, including contact details, tax ID, and more.
- **Customer Management**: Manage customer data such as name, contact information, and address.
- **Sales Orders**: Track customer orders and update the status of sales (pending, completed).
- **Stock Movements**: Log product movements (inbound and outbound) and track stock levels in real-time.

## Technologies Used

- **ASP.NET Core**: Web API development framework.
- **Entity Framework Core**: ORM for database access.
- **MySQL**: Database engine (configurable to use other databases like MySQL).
- **FluentValidation**: For request validation.
- **AutoMapper**: For mapping between DTOs and domain models.

## Getting Started

### Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [MySQL](https://dev.mysql.com/downloads/mysql/) (or another compatible database like MariaDB)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (or Visual Studio Code)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/PD1-Grupo-2/stock-master-backend.git
   cd StockMaster

📦StockMaster
 ┣ 📂StockMaster.Api            # API Layer - Controllers, Middlewares, DTOs
 ┣ 📂StockMaster.Application    # Application Layer - Use cases, services
 ┣ 📂StockMaster.Domain         # Domain Layer - Entities, Enums, Repositories
 ┣ 📂StockMaster.Infrastructure # Infrastructure Layer - Data access, EF configurations
