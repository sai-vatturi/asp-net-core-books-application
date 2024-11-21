
# Comprehensive API Testing Instructions and Screenshots

This section contains a variety of tests performed on the Blood Bank Management API using **Swagger** and **Postman**.

---

## **Swagger Tests**

### 1. **Create a New Blood Entry**
- **Endpoint**: `POST /api/bloodbank`
- **Input**:
  ```json
  {
    "donorName": "Neha Sharma",
    "age": 30,
    "bloodType": "A+",
    "contactInfo": "neha.sharma@example.com",
    "quantity": 500,
    "collectionDate": "2024-11-01",
    "expirationDate": "2024-12-01",
    "status": "Available"
  }
  ```
- **Expected Output**:
  - HTTP Status Code: `201 Created`
  - Response body with the newly created entry and `Id`.

**Screenshot Placeholder**:
![Swagger POST Create Entry](./screenshots/swagger-post-create-entry.png)

---

### 2. **Retrieve All Entries (Pagination)**
- **Endpoint**: `GET /api/bloodbank`
- **Query Parameters**:
  - `page=1`
  - `size=5`
  - `sortBy=age`
- **Expected Output**:
  - HTTP Status Code: `200 OK`
  - Paginated list of entries sorted by `age`.

**Screenshot Placeholder**:
![Swagger GET All Entries with Pagination](./screenshots/swagger-get-pagination.png)

---

### 3. **Search by Multiple Filters**
- **Endpoint**: `GET /api/bloodbank/search`
- **Query Parameters**:
  - `bloodType=O+`
  - `status=Available`
- **Expected Output**:
  - HTTP Status Code: `200 OK`
  - List of entries matching `bloodType=O+` and `status=Available`.

**Screenshot Placeholder**:
![Swagger GET Search by Filters](./screenshots/swagger-get-search-filters.png)

---

### 4. **Update an Entry**
- **Endpoint**: `PUT /api/bloodbank/{id}`
- **Input**: Replace `{id}` with an existing entry's `Id`.
  ```json
  {
    "donorName": "Neha Sharma",
    "age": 31,
    "bloodType": "A+",
    "contactInfo": "neha.updated@example.com",
    "quantity": 450,
    "collectionDate": "2024-11-01",
    "expirationDate": "2024-12-01",
    "status": "Requested"
  }
  ```
- **Expected Output**:
  - HTTP Status Code: `204 No Content`

**Screenshot Placeholder**:
![Swagger PUT Update Entry](./screenshots/swagger-put-update-entry.png)

---

### 5. **Retrieve Entry by Status**
- **Endpoint**: `GET /api/bloodbank/search`
- **Query Parameter**:
  - `status=Requested`
- **Expected Output**:
  - HTTP Status Code: `200 OK`
  - List of entries with `status=Requested`.

**Screenshot Placeholder**:
![Swagger GET Search by Status](./screenshots/swagger-get-search-status.png)

---

### 6. **Delete an Entry**
- **Endpoint**: `DELETE /api/bloodbank/{id}`
- **Input**: Replace `{id}` with an entry's `Id`.
- **Expected Output**:
  - HTTP Status Code: `204 No Content`.

**Screenshot Placeholder**:
![Swagger DELETE Entry](./screenshots/swagger-delete-entry.png)

---

## **Postman Tests**

### 1. **Create Another Blood Entry**
- **Endpoint**: `POST /api/bloodbank`
- **Input**:
  ```json
  {
    "donorName": "Arjun Kapoor",
    "age": 35,
    "bloodType": "B-",
    "contactInfo": "arjun.kapoor@example.com",
    "quantity": 470,
    "collectionDate": "2024-11-02",
    "expirationDate": "2024-12-02",
    "status": "Available"
  }
  ```
- **Expected Output**:
  - HTTP Status Code: `201 Created`
  - Response body with the newly created entry and `Id`.

**Screenshot Placeholder**:
![Postman POST Create Entry](./screenshots/postman-post-create-entry.png)

---

### 2. **Retrieve All Entries (Different Page)**
- **Endpoint**: `GET /api/bloodbank`
- **Query Parameters**:
  - `page=2`
  - `size=3`
- **Expected Output**:
  - HTTP Status Code: `200 OK`
  - Paginated list of entries on page 2.

**Screenshot Placeholder**:
![Postman GET All Entries](./screenshots/postman-get-pagination.png)

---

### 3. **Search by Donor Name**
- **Endpoint**: `GET /api/bloodbank/search`
- **Query Parameter**:
  - `donorName=Arjun`
- **Expected Output**:
  - HTTP Status Code: `200 OK`
  - List of entries where `donorName` contains "Arjun".

**Screenshot Placeholder**:
![Postman GET Search by Donor Name](./screenshots/postman-get-search-donorname.png)

---

### 4. **Retrieve Entry by Quantity Range**
- **Endpoint**: `GET /api/bloodbank/search`
- **Query Parameters**:
  - `minQuantity=450`
  - `maxQuantity=500`
- **Expected Output**:
  - HTTP Status Code: `200 OK`
  - List of entries with `quantity` between 450 and 500.

**Screenshot Placeholder**:
![Postman GET Search by Quantity](./screenshots/postman-get-search-quantity.png)

---

### 5. **Retrieve All Entries Sorted by Collection Date**
- **Endpoint**: `GET /api/bloodbank`
- **Query Parameter**:
  - `sortBy=collectionDate`
- **Expected Output**:
  - HTTP Status Code: `200 OK`
  - List of entries sorted by `collectionDate`.

**Screenshot Placeholder**:
![Postman GET Sort by Collection Date](./screenshots/postman-get-sort-collectiondate.png)

---

## **Summary of Tests**

### **Swagger Screenshots**
1. POST Create Entry
2. GET All Entries (Pagination)
3. GET Search by Multiple Filters
4. PUT Update Entry
5. GET Search by Status
6. DELETE Entry

### **Postman Screenshots**
1. POST Create Another Entry
2. GET All Entries (Page 2)
3. GET Search by Donor Name
4. GET Search by Quantity Range
5. GET All Entries Sorted by Collection Date

---

Save the screenshots in the `./screenshots/` directory as per the placeholders above. Let me know if further modifications are required.
