PizzaHub - Pizza Delivery App
ASP .NET Core 6.0 Web Application Project

C# Web Development Path at Software University, Bulgaria
ABOUT my web project:

PizzaHub Delivery App (PDP) is an online platform for ordering pizza. Customes can search the menu by ingredients and track their orders.

The platform creates one enviroment where customers, couriers and admins meet. Dividing the app into 3 areas it tries to simulate the working proccess of a delivery app that creates a smooth workflow.
Access to the website: HOMY at AZURE

PizzaHub
Database
Microsoft SQL Server along with Entity Framework Core were used to create and store the values. The database schema consists of the following main entities:

Users
Customers
Couriers
Admins
Restaurants
Menu Items
CustomerCart
Orders
Order Status
Payment Methods
Courier Application Requests
Order Items

See the Schema here: DatabaseSchema

Backend
The web project contains:

3 different areas: Customer, Courier, Admin
85+ service methods
29 controllers
35+ views
Features

This web platform allows a guest to the website to view and menu but requires him to register in order to make an order Activating an account requires a confirming account's email.

A user can confirm his email, create a request in case he forgot his email or password and regain his account back.

Signed in user(customer) has three main choices:

To browse the menu, thus adding an item to his cart and creating an order.
Every customer gets a list of his ongoing and previous orders.
To submit a request of becoming a courier and joining PizzaHub Team

Using a searchbar to filter all the items in the menu by entering ingedients that he wants his pizza to have and being show only the results that contain ALL of them.
By utilizing Ajax requests the customer has been given the ability to dinamically change the quantities of the items in his cart.
He can also dinamically remove and item from his cart without reloading the page and aall those actions will alter the entities in the database.
Feature that allows customer to track his ongoing orders statues being updated. Customer receives an email when his order has reached certain points. E.g. being picked by courier for delivery.

If customer chooses to submit a request to become a courier he'll be asked to submit a form
In the case this form being accepted, he will get whole different options and **** to the website

A courier has a different layout from the other users. 
Upon login he'll be asked wheter he is here to order or deliver. Based on his choice user will be redirected to his desired layout.

A courier can list with details of the available orders for pick up (orders in the procces of being prepaired)
When courier picks and order, its status is changed and the customer accociated with that order is notified via email that his order is on the way.
A courier can check the details of his currently picked orders and the ones he already delivered.
Upon delivery courier can send an email notification that he is on the given adress and when he give the order to the customer to mark the order as delivered.
If a courier still has an order waiting to be delivered he is not given the right to logout.

Admin upon login is redirected to his layout.
He have different set of options along changing the menu/create/edit/delete.
Approving/decline courier application requests
List, filter and track orders by given criteria through an implemented pagination logic.

Technologies Used
This website is designed and runs using the main technologies below:

C#
ASP.NET Core 6.0
Entity Framework Core 6.0.28
MS SQL Server
Bootstrap 5
JavaScript
AJAX
HTML5
CSS
MS Visual Studio 2022
MS SQL Server Management Studio 2019
Sendgrid API

This website has been created solely for educational purposes
