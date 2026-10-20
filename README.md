# 🏋️‍♂️ Gym Management System

A **Windows Forms Application** built using **C# (.NET Framework)** and **Entity Framework Core**, following a **3-Tier Architecture** design pattern.  
This project provides a complete solution to manage gym operations including clients, instructors, employees, packages, attendance, and finance records.

---

## 🧩 Project Architecture (3-Tier)

The system follows the **3-Tier Architecture** pattern for separation of concerns and maintainability:


### 📁 Layers Overview

1. **GymManagementSystemWinForms**  
   - Presentation Layer (UI)  
   - Contains all Windows Forms for user interaction.  

2. **GymManagementSystemServices**  
   - Business Logic Layer (Services)  
   - Contains logic for handling data between the UI and the Data Layer.  

3. **GymManagementSystemData**  
   - Data Access Layer  
   - Contains models, DbContext, and Entity Framework Core configurations.

---

## 🧱 Models

The system manages several entities related to the gym:

| Model Name     | Description |
|----------------|-------------|
| **Client**      | Stores client information, package, and payment details. |
| **Attendance**  | Tracks attendance records of clients. |
| **Employee**    | Stores gym employee data. |
| **Instructor**  | Holds instructor (coach) details and assigned packages. |
| **Package**     | Defines gym subscription plans and details. |
| **Payment**     | Records client payments and related information. |
| **FinanceRecord** | Keeps monthly finance statistics (scheduled, paid, overdue). |

---

## 🧠 Services

The **Services Layer** handles all core business operations:

| Service Name | Purpose |
|---------------|----------|
| **AttendanceService** | Manages attendance tracking and reporting. |
| **ClientServices** | Handles CRUD operations for clients. |
| **CoachService** | Manages instructors' data and schedules. |
| **EmployeeServices** | Handles employee management. |
| **FinanceService** | Calculates and manages finance records (income, payments). |
| **PackageService** | Manages gym packages and related offers. |
| **PaymentService** | Records and validates client payments. |

---

## 🖥️ Main Forms

| Form Name | Purpose |
|------------|----------|
| **LogInForm** | User authentication form. |
| **Home** | Main navigation hub after login. |
| **Dashboard** | Displays statistics and summaries (clients, finance, attendance). |
| **Packages** | Displays and manages gym subscription packages. |
| **InstructorForm** | Shows instructor details. |
| **ClientPage** | Displays all client data and history. |
| **EmployeeForm** | Manages employees. |
| **PaymentForm** | Handles payment operations. |
| **About** | Application information page. |
| **FAQ** | Frequently Asked Questions section. |
| **AddClient / AddEmployee / AddInstructor / AddPackageForm / AddPayment** | Forms for adding new entities. |
| **EditInstructorForm / EditPackageForm** | Forms for editing existing data. |

---

---

## 🔐 Roles & Access Control (Admin & User)

The system supports two main roles with different access levels and privileges:

| Role | Permissions & Access |
|------|----------------------|
| **Admin** | - Full access to all system features.<br> - Can **add, edit, and delete** Clients, Employees, Instructors, Packages, and Payments.<br> - Can view and manage **Finance Records** and **Attendance Reports**.<br> - Can create new users and assign roles.<br> - Access to **Dashboard**, **All Management Forms**, and **System Settings**. |
| **User** | - Limited access to basic views.<br> - Can **view** Clients, Instructors, and Packages but **cannot delete or modify** data.<br> - Can record or check **Attendance**.<br> - Has access to **Home**, **ClientPage**, and **FAQ**.<br> - Cannot access **Finance** or **Employee Management** sections. |

---

## 🧮 Features

- Manage **Clients**, **Employees**, **Instructors**, and **Packages**.
- Record and monitor **Attendance**.
- Handle **Payments** and generate **Finance Reports**.
- Track **Remaining Sessions**, **Active Packages**, and **Payment History**.
- Built with a clean **3-tier structure** for scalability and easy maintenance.

---

## 🛠️ Technologies Used

| Technology | Description |
|-------------|-------------|
| **C# (.NET Framework)** | Core programming language |
| **Entity Framework Core** | ORM for database management |
| **Windows Forms (WinForms)** | UI Framework |
| **SQL Server** | Database backend |
| **LINQ** | For querying data |
| **3-Tier Architecture** | Structural pattern for separation of concerns |

---

## 👥 Team Members

| Name | Role |
|------|------|
| **Mennatullah Atef** | Developer |
| **Rawan Ahmed** | Developer |
| **Abdalaa Khaleel** | Developer |
| **Ramiz Magdy** | Developer |

---

## 🧑‍🤝‍🧑 Team Collaboration & Work Distribution

We worked together as a **team** throughout the entire development process.  
All members participated in **coding, designing, and testing** different parts of the project.

### 🧠 Collaboration Highlights:
- We always worked together in **team meetings**, sharing ideas and helping each other solve problems.  
- Every member contributed to both **frontend (WinForms UI)** and **backend (EF Core & Services)**.  
- Some tasks were **shared between two members**, such as working on attendance logic and dashboard integration.  
- The project was built through **continuous communication, feedback, and collaboration** on all modules.

---

## 📸 Screenshots (Optional)

Here are some screenshots of the **Gym Management System** showing the interface, forms, and features of the application:

---

<div align="center"> <img src="https://github.com/user-attachments/assets/58b7ca6d-59a3-465a-bdb7-bd985b865b17" height="300" /> <img src="https://github.com/user-attachments/assets/b0e449cd-39df-415a-825e-51b4aeebef9a" height="300" /> <img src="https://github.com/user-attachments/assets/ec22f553-c7b4-482c-9b8d-30a5a04ae8b4" height="300" /> <img src="https://github.com/user-attachments/assets/29d79511-130e-4d17-83c7-8f42266a102f" height="300" /> <img src="https://github.com/user-attachments/assets/43e9da5a-52b8-4bce-a6b2-cb88cca933f6" height="300" /> <img src="https://github.com/user-attachments/assets/206470cb-170c-47c9-9067-8f11fd0eb0b3" height="300" /> <img src="https://github.com/user-attachments/assets/b0899f2c-8408-4e51-ad15-b051a0219306" height="300" /> <img src="https://github.com/user-attachments/assets/7f8dc3a1-31e0-43d2-b5e1-8f49aae2981a" height="300" /> <img src="https://github.com/user-attachments/assets/0809c7e3-b1ce-4b47-bbbb-8baf4b6fe5c7" height="300" /> <img src="https://github.com/user-attachments/assets/767cdd7a-5402-4cc3-9663-24efaf4c81ac" height="300" /> <img src="https://github.com/user-attachments/assets/de57e510-4914-4107-9c32-c7a377805199" height="300" /> <img src="https://github.com/user-attachments/assets/ddd41556-a024-40b1-a836-e245acb33b53" height="300" /> <img src="https://github.com/user-attachments/assets/524f209a-a218-4a08-bd92-17ff9f3c52f4" height="300" /> <img src="https://github.com/user-attachments/assets/a961718b-d90c-4e45-8886-b65192303474" height="300" /> <img src="https://github.com/user-attachments/assets/33f60b68-8217-418b-8c60-b0e5802eb451" height="300" /> </div>

---


