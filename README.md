# Personal Website

This repository contains the source code for my personal website, implemented using .NET 5.0. The website showcases my resume and professional work, featuring a modern design and an efficient admin dashboard for content management.

## Project Overview

- **Framework:** ASP.NET Core
- **Database:** SQL Server
- **Purpose:** Display resume and professional work
- **Features:**
  - Admin dashboard for efficient content management
  - Responsive design with Bootstrap
  - Dynamic content rendering

## Technologies Used
- **IDE:**
  - Visual Studio 2022
- **Backend:**
  - C#
  - ASP.NET Core
  - Entity Framework Core
  - MSSQL Server
- **Frontend:**
  - HTML
  - CSS
  - Bootstrap
  - JavaScript

## Setup Instructions

To get a local copy up and running, follow these steps:

1. **Clone the repository:**
   ```sh
   git clone https://github.com/erfanfarhanian/PersonalWebsite.git
2. Navigate to the project directory:
   ```sh
   cd PersonalWebsite
3. Restore dependencies:
   ```sh
   dotnet restore
4. Update the database connection string:
Update the appsettings.json file with your SQL Server connection string.
5. Apply database migrations:
   ```sh
   dotnet run
6. Run the application:
   ```sh
   dotnet run
## Features
### Resume Display
View detailed professional resume
Interactive sections for education, work experience, and skills
### Admin Dashboard
Secure login for admin access
Manage content including resume details, blog posts, and more
User-friendly interface for adding, updating, and deleting content
### Responsive Design
Fully responsive layout using Bootstrap
Optimized for various screen sizes and devices
