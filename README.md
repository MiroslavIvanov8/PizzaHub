<p align="center">
  <a href="https://github.com/MiroslavIvanov8/PizzaHub)">
    <img src="https://cdn1.vectorstock.com/i/1000x1000/91/15/cartoon-pizza-delivery-guy-vector-9059115.jpg" alt="Project Name" width=150 height=150>
  </a>
  <h3 align="center">PizzaHub - Pizza Delivery App</h3>

  <p align="center">
    PizzaHub Delivery App (PDP) is an online platform for ordering pizza. <br>
    Customers can search the menu by ingredients and track their orders. The platform creates one environment where customers, couriers, and admins meet, dividing the app into three areas to simulate the working process of a delivery app.
    <br>
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

See the Schema here: DatabaseSchema

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
  
- **Customer-specific actions:**
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

- C#
- ASP.NET Core 6.0
- Entity Framework Core 6.0.28
- MS SQL Server
- Bootstrap 5
- JavaScript
- AJAX
- HTML5
- CSS
- MS Visual Studio 2022
- MS SQL Server Management Studio 2019
- Sendgrid API

---

### License

* See [LICENSE](https://github.com/YourUserNameHere/ProjectName/LICENSE.md) file

[![Open Source Love](https://badges.frapsoft.com/os/v2/open-source-200x33.png?v=103)](#)

[![license](https://img.shields.io/github/license/mashape/apistatus.svg?style=for-the-badge)](https://github.com/tamzi/ReadMe-MasterTemplates/blob/master/LICENSE)
