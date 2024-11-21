
# Blood Bank Management API

A comprehensive API for managing blood bank operations, built with **ASP.NET Core** and **.NET 8.0**. This project provides functionality for CRUD operations, pagination, sorting, and filtering of blood bank data.

---

## Features

- **CRUD Operations**: Create, read, update, and delete blood bank entries.
- **Pagination**: Fetch paginated results for efficient data retrieval.
- **Search Functionality**: Search by blood type, status, and donor name.
- **Sorting**: Sort entries by fields such as blood type, collection date, or donor name.
- **Validation**: Model validation to ensure data consistency.
- **In-Memory Database**: Store and manage data using an in-memory list.
- **Swagger Integration**: Document and test the API using Swagger UI.
- **Postman Testing**: API endpoints tested via Postman.

---

## Getting Started

### Prerequisites

- **.NET 8.0 SDK**: Ensure you have .NET 8.0 installed. [Download it here](https://dotnet.microsoft.com/download/dotnet/8.0).
- **IDE**: Visual Studio, Visual Studio Code, or any text editor of your choice.

### Setup Instructions

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/sai-vatturi/blood-bank-management-netcore-webapi.git
   ```
2. **Navigate to the Directory**:
   ```bash
   cd blood-bank-management-netcore-webapi

   ```
3. **Run the Application**:
   ```bash
   dotnet run
   ```

4. **Access Swagger**:
   - Open your browser and navigate to [`http://localhost:5087/swagger/index.html`](http://localhost:5087/swagger/index.html) to explore the API documentation.

---

## API Endpoints

### **Base URL**: [`http://localhost:5087/swagger/index.html`](http://localhost:5087/swagger/index.html)

| HTTP Method | Endpoint                      | Description                              |
|-------------|-------------------------------|------------------------------------------|
| `POST`      | `/api/bloodbank`              | Add a new blood bank entry.             |
| `GET`       | `/api/bloodbank`              | Retrieve all entries (supports pagination and sorting). |
| `GET`       | `/api/bloodbank/{id}`         | Retrieve a specific entry by ID.        |
| `PUT`       | `/api/bloodbank/{id}`         | Update an existing entry.               |
| `DELETE`    | `/api/bloodbank/{id}`         | Delete an entry by ID.                  |
| `GET`       | `/api/bloodbank/search`       | Search entries by blood type, status, or donor name. |

### **Query Parameters for Pagination and Sorting**

- **Pagination**:
  - `page`: The page number (default: 1).
  - `size`: The number of entries per page (default: 10).

- **Sorting**:
  - `sortBy`: Field to sort by (e.g., `bloodType`, `collectionDate`, `quantity`).

### **Search Filters**

| Parameter      | Type   | Description                          |
|----------------|--------|--------------------------------------|
| `bloodType`    | String | Filter by blood type (e.g., `O+`).   |
| `status`       | String | Filter by status (`Available`, `Requested`, `Expired`). |
| `donorName`    | String | Filter by donor name (partial match).|
| `minQuantity`  | Int    | Filter by minimum blood quantity.    |
| `maxQuantity`  | Int    | Filter by maximum blood quantity.    |

---


## Bonus Features

- **Sorting**: Implement sorting by multiple fields.
- **Filters**: Allow combined filtering using multiple query parameters.
- **Custom Middleware**: Add exception handling for better error responses.

---

## Sample Data

Here’s some sample blood bank data used in the in-memory database:

| Id                                   | Donor Name       | Age | Blood Type | Contact Info               | Quantity (ml) | Collection Date | Expiration Date | Status     |
|--------------------------------------|------------------|-----|------------|----------------------------|---------------|-----------------|-----------------|------------|
| `Generated GUID`                    | Sainadh Vatturi  | 21  | O+         | sainadhvatturi@gmail.com   | 500           | 10 days ago     | In 30 days      | Available  |
| `Generated GUID`                    | Divya Reddy      | 30  | A+         | divya.reddy@gmail.com      | 450           | 5 days ago      | In 25 days      | Requested  |
| `Generated GUID`                    | Harshitha N      | 28  | B+         | harshitha.n@gmail.com      | 480           | 7 days ago      | In 23 days      | Available  |
| `Generated GUID`                    | Suresh Yadav     | 35  | AB-        | suresh.yadav@gmail.com     | 520           | 12 days ago     | In 28 days      | Available  |
| `Generated GUID`                    | Sneha Rao        | 32  | O+         | sneha.rao@gmail.com        | 500           | 3 days ago      | In 27 days      | Requested  |
| `Generated GUID`                    | Vikram Patil     | 29  | A-         | vikram.patil@gmail.com     | 470           | 8 days ago      | In 22 days      | Available  |
| `Generated GUID`                    | Keerthi Varma    | 26  | B-         | keerthi.varma@gmail.com    | 460           | 4 days ago      | In 26 days      | Available  |
| `Generated GUID`                    | Rahul Naidu      | 40  | AB+        | rahul.naidu@gmail.com      | 510           | 15 days ago     | In 25 days      | Requested  |
| `Generated GUID`                    | Anusha K         | 27  | O+         | anusha.k@gmail.com         | 495           | 6 days ago      | In 24 days      | Available  |
| `Generated GUID`                    | Rakesh Singh     | 33  | A+         | rakesh.singh@gmail.com     | 505           | 9 days ago      | 4 days ago      | Expired  |
| `Generated GUID`                    | Meghana Iyer     | 24  | B+         | meghana.iyer@gmail.com     | 475           | 2 days ago      | In 28 days      | Requested  |
| `Generated GUID`                    | Ajay K           | 31  | O-         | ajay.k@gmail.com           | 490           | 11 days ago     | In 19 days      | Available  |


---

## Screenshots and Tests

Detailed testing of the api with screenshots are given in this markdown file: 



---

### License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
