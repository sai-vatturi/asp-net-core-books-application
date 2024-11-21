
# Comprehensive API Testing Instructions and Screenshots

This section contains a variety of tests performed on the Blood Bank Management API using **Swagger** and **Postman**.

---

## **Swagger Tests**

### 1. **Create a New Blood Entry**
- **Endpoint**: `POST /api/bloodbank`
- **Sample Payload**:
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
<img width="472" alt=" POST" src="https://github.com/user-attachments/assets/be9269af-caad-43e6-a664-4d41ff3c10e7">

---

### 2. **Retrieve All Entries (Pagination)**

<img width="464" alt="GET" src="https://github.com/user-attachments/assets/8f82da50-93c3-4849-a7f6-b0d3c4f2a323">


---

### 3. **Search by Multiple Filters**

<img width="470" alt="GET_Search" src="https://github.com/user-attachments/assets/674a120d-3975-440d-a327-704d410f6983">


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

<img width="474" alt="PUT" src="https://github.com/user-attachments/assets/db07a547-0e1a-4b54-bf6f-7668cc59461d">


---

### 6. **Delete an Entry**

<img width="470" alt="DELETE" src="https://github.com/user-attachments/assets/73352083-983f-4fc9-b60f-123afffed3d7">


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

<img width="661" alt="POST " src="https://github.com/user-attachments/assets/8c28089c-8125-4d04-88d2-6ebf4fc8afd8">


---

### 2. **Retrieve All Entries (Different size)**
- **Endpoint**: `GET /api/bloodbank`

<img width="660" alt="GET" src="https://github.com/user-attachments/assets/92f5b9b9-8a00-427a-8761-440c0277a767">


---

### 3. **Search by Donor Name**
- **Endpoint**: `GET /api/bloodbank/search`
<img width="670" alt="GET_Search" src="https://github.com/user-attachments/assets/cdbcaa03-2f09-4760-b1ac-b36fb2fb2c4e">

---


### 5. **Retrieve All Entries Sorted by Collection Date**
- **Endpoint**: `DELETE /api/id`
<img width="660" alt="DELETE" src="https://github.com/user-attachments/assets/9ba4d79b-b97e-4265-bef9-b1250403c361">

---

Look at the screenshots folder for more tests!
