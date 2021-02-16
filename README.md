# Increo_Shaibal_Sarkar

This is a basic web application using .Net Core 3.1 Framework and cshtml pages along with MS SQL and Entity framework to do database transactions. The ToDoWeb application is the main application which is developed on MVC, however all the CRUD operations are being done using JQuery/Ajax(as specified in the requirment).

The database interactions are kept in a seperate DAL project and the DbContext and service classes are instantiated using Dependency Injection in the main web application. The interaction between web client and the database is done using Ajax asynchronous calls. The data for tasks are stored in a database which consists of one table ToDoData. 

The database script is kept in a seperate directory which is for creating the whole database including the database object(only ToDo in this case).

#Setting Up the application

a) Solution is developed in VS2019.
b) Execute the database script after checking/correcting the backup and log folder path.
c) Update the database connection strings in the appsettings.json file in the Web Project. The DAL project is a Class Library.
d) Run the application.
