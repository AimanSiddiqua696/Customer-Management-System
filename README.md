# Customer-Management-System
Customer Management System (C# + SQL Server) – A C# application connected with SQL Server for managing customer data. The system performs full CRUD operations on the database, including advanced features like search, contact validation, and duplicate prevention, without using file handling.
# 👤 Customer-Management-System-CSharp-SQL

A simple C# application connected with SQL Server to manage customer data, including adding, viewing, updating, deleting, and performing advanced functions like search and validation.  
This system uses **database storage** instead of file handling.

---

## 📖 Project Overview
This C# application is connected with SQL Server.  
It allows users to perform **full CRUD operations** on customer records and includes advanced features such as search, input validation, and duplicate prevention.  
All data is stored in the database, and no file handling is used.

---

## ⚙️ Technologies Used
- C# (.NET Framework / Console or Class Library)  
- SQL Server  
- ADO.NET  
- Visual Studio  

---

## 💡 Features

### ✅ Basic CRUD Functions
- ➕ Add new customers  
- 🔍 View all customer records  
- ✏️ Update existing customer details  
- ❌ Delete customers  

### ⭐ Advanced Features
- 🔎 Search customers by Name or Contact number  
- 📱 Contact number validation  
- ⚠️ Prevents empty or invalid fields  
- 🔁 Refresh customer list automatically  
- 🧠 Parameterized queries to prevent SQL Injection  
- 🎯 Filters results dynamically  
- ✔️ Ensures no duplicate contact numbers  

---

## 🗄️ Database Setup

### 1️⃣ Create Database
```sql
CREATE DATABASE POS;
CREATE TABLE Customer (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Contact NVARCHAR(20),
    Address NVARCHAR(255)
);
