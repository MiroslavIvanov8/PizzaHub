<p align="center">
  <h3 align="center">
  <img src="https://img.icons8.com/?size=48&id=lxxwrZV7q7Yr&format=png" alt="Pizza Icon" width="48" height="48">
  PizzaHub - Pizza Delivery App
</h3>
  <p align="center">
    PizzaHub Delivery App (PDP) is an online platform for ordering pizza. Customers can search the menu by ingredients and track their orders. The platform creates one environment where customers, couriers, and admins meet, dividing the app into three areas to simulate the working process of a delivery app.
  </p>
  <p align="center">
    <a href="https://github.com/MiroslavIvanov8/PizzaHub">
      <img src="https://i.postimg.cc/j2SmPjsM/Pizza-Hub-Preview.gif" alt="Project Name" width=800 height=500>
    </a>
  </p>
</p>

<br>

## Table of Contents

- [Database Schema](#database-schema)
- [Backend Features](#backend-features)
- [Technologies Used](#technologies-used)
- [License](#license)
---

### Database Schema

Microsoft SQL Server along with Entity Framework Core were used to create and store the values. The database schema consists of the following main entities:

- Users
- Customers
- Couriers
- Admins
- Restaurants
- Menu Items
- CustomerCart
- Orders
- Order Status
- Payment Methods
- Courier Application Requests
- Order Items

See the Schema here: [DatabaseSchema](https://i.postimg.cc/0QwL9N83/Database-Schema.png)

---

### Backend Features

#### Areas

- Customer
- Courier
- Admin

#### Service Methods

- 40+ service methods

#### Controllers

- 15 controllers

#### Views

- 25+ views

---

### Features

- Guest viewing of the menu; registration required for orders
- Account activation via confirming email
- Email confirmation, password recovery, and account regain options

**Customer-specific actions:**
- Browsing the menu
- Creating orders
- Tracking ongoing and previous orders
- Submitting a courier application request
- Dynamic cart management (Ajax requests)
- Email notifications for order status updates

#### Courier Actions

- Listing available orders for pickup
- Changing order status and notifying customers
- Tracking ongoing and delivered orders
- Email notification upon delivery

#### Admin Features

- Menu management (create/edit/delete)
- Approving/declining courier applications
- Order management with pagination

---

### Technologies Used

This project uses:

- [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [ASP.NET Core 6.0](https://docs.microsoft.com/en-us/aspnet/core)
- [Entity Framework Core 6.0.28](https://docs.microsoft.com/en-us/ef/core/)
- [MS SQL Server](https://www.microsoft.com/en-us/sql-server/)
- [Bootstrap 5](https://getbootstrap.com/docs/5.0/getting-started/introduction/)
- [JavaScript](https://developer.mozilla.org/en-US/docs/Web/JavaScript)
- [AJAX](https://developer.mozilla.org/en-US/docs/Web/Guide/AJAX)
- [HTML5](https://developer.mozilla.org/en-US/docs/Web/Guide/HTML/HTML5)
- [CSS](https://developer.mozilla.org/en-US/docs/Web/CSS)
- [MS Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [MS SQL Server Management Studio 2019](https://docs.microsoft.com/en-us/sql/ssms/)
- [Sendgrid API](https://sendgrid.com/docs/)

---

### License

This website has been created solely for educational purposes under the [MIT License](https://opensource.org/licenses/MIT).

[![Open Source Love](https://badges.frapsoft.com/os/v2/open-source-200x33.png?v=103)](#)

[![MIT License](https://img.shields.io/github/license/mashape/apistatus.svg?style=for-the-badge)](https://opensource.org/licenses/MIT)
