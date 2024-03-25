# Trendora

## Overview
This is a Blazor web application for a clothing store, featuring functionalities common in e-commerce sites.  
***Whole documentation is located [here](https://trendora.atlassian.net/wiki/external/ZGIxZmZlMzZhNzZjNDY3MDliOTFiZDkyODE0YTc4MDQ).***

## Reason for choosing Blazor Server instead of WebAssembly
I am aware that a site of this type should be made using WebAssembly and that using Blazor server is a terrible choice.  
The reason I chose Blazor Server is because I wanted to try working with SignalR and to minimize client-side resources.  
In a real scenario I would have chosen Blazor WebAssembly.

## Simplicity choices
Because I wanted to keep it fairly simple, some options clothing stores ussualy have are limited.  
For example:  
- you can't declare sizes for each product, but for the category itself  
- colors are pre-made  
- there is no storage tracking how many products are left in stock  

## Prerequisites
- .NET 8 SDK
- SQL Server LocalDB

## Setup
1. Clone the repository locally
2. Navigate to solution folder
3. Install the project dependencies using `dotnet restore`
4. Build the project to check for any compilation errors using `dotnet build`

## Database Configuration
Ensure LocalDB is installed. **(localdb)\MSSQLLocalDB**  
Update the connection string in `appsettings.json` if necessary.

To set up the database for the first time and apply the Entity Framework migrations, follow these steps:

1. Open a command prompt or terminal window.
2. Navigate to the project's directory where the `Wardrobe.Data_Access.csproj` file is located which is in **Wardrobe.Data_Access** folder.
3. Run the following command to apply the migrations to the database:

```shell
dotnet ef database update
```

## License and Usage Terms
This project is intended for portfolio use only and should not be used as a basis for commercial applications. The code is provided as-is for demonstration purposes, and while you may use it to learn and explore Blazor and .NET technologies, you should not use this code directly in your own projects that are intended for commercial release.
