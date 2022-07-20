# Coding-Assessment-RW-tpi
Utilized Tech Stack MySQL, ASP.NET, Angular, Microsoft SQL Server Management Studio, Visual Studio 2022, Visual Studio Code with Angular HTML Syntax Pluggins

This is the repository for a coding assessment assigned to Ryan West To develop a CRUD test program.
ASP.NET and Angular were utilized for the first time by myself eating into the designated time given.


The thought process for development was
1. Setup a MySQL Server Enviorment on a local system.
2. Take MySQL quarries and translate into functions using ASP.NET so long as they qualify the requirments
3. Connect API to MySQL Server
4. Utilize said functions inside the Angular UI Framework for a Web application
5. Display all Relative Data in a clean format utilizing Angular's GUI

Requirments to Run

1.SQL EXPRESS download

2.SQL managament service

Visual Studio 2022

  A.Visual Studio 2022 Features
  
    a.ASP.NET and Web Dev Kit
    
    b..NET desktop development
    
    c.data storing and processing 

  B.Visual Studio 2022 with nugu Plugins

    a.Microsoft.EntityFramework.Core
  
    b.Microsoft.EntityFramework.tools
  
    c.Microsoft.EntityFramework.SQLServer
  
4.Node.js

5.Angular(with requirments) 

Steps to Run from a Clean Setup
1. Run Microsoft SQL Server Management Studio and Connect to a Database
2. Load C# Solution into Visual Studio 2022 ensure connectionString connects to Database
3. in Visual Studio 2022 package manager Console input update Database for inital database creation using EntityFramework
4. In Visual Studio 2022 Run WebAPI Confirm SwaggerUI loads all functions
5. Open Angular Folder with Visual Studio Code. navigate using terminal to Assessment_RW and input 'ng serve' in  terminal

Current Results 
Delete in Front end UI works via Database cascade
Read functionality for 'Contact' Data-Table is displayed but not for 'Address' Data Table
Add and Update in Front end UI does not work

WebAPI Functionality
Add,Delete,Read and Update Works using Swagger UI

