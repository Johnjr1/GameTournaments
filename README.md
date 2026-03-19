# 🎮 Game Tournament API

## 🚀 Description
This is a backend API built with **ASP.NET Core Web API**.

The API is used in a fullstack application where users can manage tournaments and games.

It handles all data operations such as:
- creating data  
- retrieving data  
- updating data  
- deleting data  

The backend is connected to a database using **Entity Framework Core**.

---

## 🧠 Purpose
This API is designed to work together with a frontend application built in HTML, CSS and JavaScript.

The frontend communicates with this API to:
- display tournaments and games  
- create new data  
- update existing data  
- delete data  

---

## 🧱 Tech Stack
- ASP.NET Core Web API  
- Entity Framework Core  
- SQL Server  
- Controllers + Services architecture  

---

## ⚙️ How to run

1. Open the project in Visual Studio or VS Code  

2. Run database migrations (if needed):

dotnet ef database update


3. Start the API:

dotnet run


The API will run on:
- https://localhost:7003  
- http://localhost:5249  

Swagger is available at:
https://localhost:7003/swagger  

---

## 🧩 Structure

The project is organized into:
- Controllers → handle HTTP requests  
- Services → contain business logic  
- Models → represent database entities  
- DTOs → handle data transfer  
- DbContext → database connection  

---

## 📡 Endpoints

### 🎯 Tournaments
- GET /api/tournaments  
- GET /api/tournaments/{id}  
- POST /api/tournaments  
- PUT /api/tournaments/{id}  
- DELETE /api/tournaments/{id}  

### 🎮 Games
- GET /api/games  
- GET /api/games/{id}  
- POST /api/games  
- PUT /api/games/{id}  
- DELETE /api/games/{id}  

---

## 💭 Summary
This API is part of a fullstack application and is responsible for handling all backend logic and database communication.
