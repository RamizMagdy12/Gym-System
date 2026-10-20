# Gym System

A Windows desktop application for running a gym: members, packages, coaches, attendance, payments, equipment, and staff access.

Built with **C#**, **.NET 8**, **Windows Forms**, **Entity Framework Core**, and **SQL Server**, in a **3-tier** layout.

---

## Architecture

| Project | Layer | Responsibility |
|---------|--------|----------------|
| **GymMSWF** | Presentation | Windows Forms, navigation, and dialogs |
| **GymServices** | Business | Membership rules, billing, attendance, and roles |
| **GymData** | Data | Models, `DbContext`, and EF Core migrations |

---

## What the system does

- Sign-in with a username and password. Each role only sees the pages it is allowed to open, and only the actions it is allowed to take.
- Register a client on a package and lock a billing cycle of **1, 3, 6, or 12 months**. The end date and the invoice amount come from that choice.
- One invoice is created for the whole cycle. Staff collect it from the Payments page. The amount is not typed again.
- After the invoice is paid, the client status becomes active. Check-in works only inside the paid period, and it shows which session this is and how many remain.
- If the package has ended or the invoice is still unpaid, check-in stops and explains why.
- Manage coaches, employees, equipment, and a dashboard for packages, active memberships, and the month's revenue.

---

## Roles

Access is stored per screen. **Can see** opens the page. **Can edit** allows add, update, delete, check-in, and collecting a payment.

| Role | Typical access |
|------|----------------|
| **Admin** | Every page, view and edit. This role stays fully open. |
| **Reception** | Dashboard and packages (view). Clients, attendance, and payments (edit). Equipment (view). |
| **Coach** | Packages and clients (view). Attendance (edit). |
| **User** | Packages, equipment, and payments (view). Clients and attendance (edit). |

An administrator can add roles and change these checkboxes from the **Users** page. A change to the signed-in role applies on the next sign-in.

---

## Main screens

| Screen | What it is for |
|--------|----------------|
| **Log in** | Username and password |
| **Home** | Package count, active memberships, monthly revenue, and the latest check-in |
| **Dashboard** | Payment rings, the week's attendance, today's schedule, and notifications |
| **Packages** | Package cards, with a billing cycle and a coach |
| **Clients** | Member list, status, cycle, amount, and check-in |
| **Attendance** | Who can train today, the current session, and remaining sessions |
| **Instructors** | Coach cards |
| **Employees** | Staff records |
| **Users** | Accounts, roles, and page permissions |
| **Payments** | Cycle invoices. Collect marks an invoice as paid |
| **Equipment** | Gym equipment, condition, and availability |
| **FAQ / About** | Help and gym information |

---

## Models

| Model | Holds |
|-------|--------|
| **Client** | Member profile, package, billing cycle, and dates |
| **Package** | Title, price, sessions, default cycle, and coach |
| **Payment** | The invoice generated for the current cycle |
| **Attendance** | A check-in for a member |
| **Instructor** | Coach profile |
| **Employee** | Staff profile, username, and role name |
| **AppRole / RolePermission** | Role name and what each screen can see or edit |
| **Equipment** | Item, quantity, condition, and availability |
| **FinanceRecord** | Monthly finance figures |

---

## Technologies

| Technology | Use |
|------------|-----|
| C# / .NET 8 | Application |
| Windows Forms | User interface |
| Entity Framework Core | Data access and migrations |
| SQL Server | Database |
| LINQ | Queries |

---

## Team

| Name | Role |
|------|------|
| **Mennatullah Atef** | Developer |
| **Rawan Ahmed** | Developer |
| **Abdalaa Khaleel** | Developer |
| **Ramiz Magdy Awad** | Developer |

The team shared the UI, the services, and testing. Gym System is founded by **Ramiz Magdy Awad**.

---

## Screenshots

### Log in

<img src="screenshots/01-login.png" alt="Log in" width="900" />

### Home

<img src="screenshots/02-home.png" alt="Home cards and latest check-in" width="900" />

### Dashboard

<img src="screenshots/03-dashboard.png" alt="Payments, attendance, schedule, and notifications" width="900" />

<img src="screenshots/04-dashboard-schedule.png" alt="Today's schedule and a check-in notification" width="900" />

### Packages

<img src="screenshots/05-packages.png" alt="Package card" width="900" />

<img src="screenshots/06-add-package.png" alt="Add a package" width="900" />

<img src="screenshots/07-edit-package.png" alt="Edit a package" width="900" />

### Clients

<img src="screenshots/08-clients.png" alt="Client list" width="900" />

<img src="screenshots/09-add-client.png" alt="Add a client and choose a billing cycle" width="900" />

### Attendance

<img src="screenshots/10-attendance.png" alt="Attendance board and remaining sessions" width="900" />

### Instructors

<img src="screenshots/11-instructors.png" alt="Instructor cards" width="900" />

<img src="screenshots/12-add-instructor.png" alt="Add an instructor" width="900" />

### Employees

<img src="screenshots/13-employees.png" alt="Employee list" width="900" />

<img src="screenshots/14-add-employee.png" alt="Add an employee" width="900" />

### Users and roles

<img src="screenshots/15-users-roles.png" alt="Users and role permissions" width="900" />

### Payments

<img src="screenshots/16-payments.png" alt="Cycle invoices" width="900" />

<img src="screenshots/17-collect-payment.png" alt="Collect a payment" width="900" />

### Equipment

<img src="screenshots/18-equipment.png" alt="Add equipment" width="900" />

### FAQ and About

<img src="screenshots/19-faq.png" alt="FAQ" width="900" />

<img src="screenshots/20-about.png" alt="About Gym System" width="900" />
