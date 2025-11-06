---

# 🍕 PizzaStore (WPF | .NET 8 | EF Core | JWT)

A **modern desktop-based pizza ordering system** built with **WPF (.NET 8)** using **Entity Framework Core** for data access and **JWT Authentication** for secure local login.
Designed with **Clean Architecture (MVVM + Repository Pattern)** — this project demonstrates professional software structure, layered design, and maintainable code practices in desktop applications.

---

## 🧱 Architecture Overview

This project follows a **multi-layered clean architecture** to separate concerns and maintain scalability:

```
PizzaStore/
│
├── PizzaStore.Domain           → Entities, Models, Core Logic
├── PizzaStore.Infrastructure   → EF Core (DbContext, Repositories, JWT Services)
├── PizzaStore.ApplicationCore  → Services, Interfaces, Business Logic
├── PizzaStore.Presentation     → WPF UI Layer (MVVM: Views, ViewModels, Commands)
│
└── PizzaStore.sln
```

### 🧩 Key Architectural Concepts

* **MVVM Pattern** → Decouples UI (View) from logic (ViewModel)
* **Repository Pattern** → Clean data access using EF Core
* **Dependency Injection** → For maintainable, testable components
* **JWT Authentication** → Secure local authentication (no API required)
* **SQL Server Database** → Persistent local data storage

---

## ⚙️ Tech Stack

| Layer          | Technology                   |
| :------------- | :--------------------------- |
| UI             | WPF (.NET 8, XAML, MVVM)     |
| Database       | SQL Server 2021 (LocalDB)    |
| ORM            | Entity Framework Core        |
| Language       | C#                           |
| Authentication | JSON Web Tokens (JWT)        |
| IDE            | Visual Studio Community 2022 |

---

## 🚀 Features

* 🔑 **User Authentication** (JWT-based local login)
* 🍕 **Pizza Management** (Add, update, delete menu items)
* 🛒 **Order System** (Place and track orders)
* 👤 **Role-based Access** (Admin, Customer)
* 📦 **Persistent Storage** with EF Core & SQL Server
* 🎨 **Modern UI** built fully with WPF (XAML + MVVM)

---

## 💡 Project Use Case

This software simulates a **desktop pizza ordering system** for local use — suitable for:

* Restaurant front-desk ordering
* Desktop POS-style apps
* Student/portfolio projects demonstrating full-stack desktop development

---

## 🧭 How to Run

1. **Clone the repository:**

   ```bash
   git clone https://github.com/TalhaProgrammer92/PizzaStore
   cd PizzaStore
   ```

2. **Open in Visual Studio 2022**

3. **Set Startup Project:**

   * Right-click `PizzaStore.Presentation` → *Set as Startup Project*

4. **Update Database:**

   ```bash
   dotnet ef database update
   ```

5. **Run the Application**
   Press **F5** to build and launch the PizzaStore desktop app 🎉

---

## 🔐 Authentication (Local JWT)

Even though this is a **desktop-only** app, JWT tokens are used internally for:

* Session management
* Role validation (Admin/Customer)
* Local security simulation

The tokens are generated and validated within the app using local logic (no external API).

---

## 🧑‍💻 Developer Notes

* Follows enterprise-style folder structure
* Implements **SOLID principles**
* Demonstrates **Clean Architecture** in desktop app context
* Great for **portfolios, case studies, or learning advanced .NET**

---

## 📸 Screenshots

### 👤 Login UI
I tranformed the login UI from old fashion to a cool modern look. There's two active accounts in my database:

| Username | Password | Role |
|----------|----------|------|
| admin | 12345 | 1 (Admin) |
| customer | customer123 | 0 (User) |

The login UI now looks like this:

![Login Window](/Screenshots/Login%20Window/Login%20window%20-%20ui.png)

### 🎨 Main Window UI - Dashboard
I created a modern and clean UI of the main window using only XAML, without replying on any third-party libraries/tools. You can take a look:

![Main Window](/Screenshots/Main%20Window/Main%20Window%20-%20UI%20v3.png)

It can be polished even further and I'll add more components like graphs, cards, cart, filters, etc. and all related features for each section.

### 🍕 Manage Pizzas UI
I created a UserControl for the ManagePizzas section so that admin can perform CRUD operations with Pizza entities with the database. Here's a look:

![Manage Pizzas](/Screenshots/Manage%20Pizzas/Manage%20Pizzas%20-%20First%20look%20-%20UI.png)

The UI is simple, just insert data about the pizza and perform CRUD using buttons below. There are two special feature buttons:

1. **Filter Pizzas:** It's used to filter the list of pizzas depending on variety, size and price.

2. **Pizza Varieties Manager:** It's used to perform CRUD with pizza varieties so that these can be shown in the ComboBox items list of the PizzaVariety ComboBox.

---

## 📄 License

This project is open-source under the [**MIT License**](/LICENSE).

---

## 🏗️ Author

**Talha Ahmad**
🚀 *.NET & ASP.NET Developer | Software Engineer*
📎 [LinkedIn Profile](https://www.linkedin.com/in/talha-ahmad-720171324/)
📎 [GitHub Profile](https://github.com/TalhaProgrammer92)

---