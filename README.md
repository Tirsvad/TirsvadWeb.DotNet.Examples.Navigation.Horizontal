# DotNet.Navigation.Horizontal.Example

## Overview

This project demonstrates a horizontal navigation menu in a Blazor WebAssembly application, using in-memory data to define the menu structure. It is designed as an example for building dynamic, multi-level navigation menus in modern .NET Blazor applications.

The solution is organized into several projects following clean architecture principles:

- **Domain**: Core business entities (e.g., `MenuFragment`).
- **Application**: Service and repository interfaces (e.g., `IMenuService`, `IMenuRepository`).
- **Infrastructure**: In-memory repository implementation for menu data (`MenuRepository`).
- **WebUI**: Blazor WebAssembly client and server hosting the UI and components.
- **API**: (Optional) Example API endpoints.

## Features

- Horizontal navigation bar with multi-level dropdown support
- Menu items and hierarchy defined in-memory (no database required)
- Responsive design with collapse/expand for smaller screens
- Easily extensible for real data sources or additional features

## How It Works

1. **Menu Data**: The menu structure is defined in-memory in the `MenuRepository` class. Each menu item is a `MenuFragment` object, supporting nested children for submenus.
2. **Dependency Injection**: The infrastructure project registers the repository and services for dependency injection, making them available to the Blazor components.
3. **Blazor Components**: The `TopNavBar` and `MenuFragmentRender` components render the navigation bar and its items recursively, supporting multi-level dropdowns.
4. **UI Rendering**: The navigation bar is rendered horizontally at the top of the page, with dropdowns for submenus. The menu is responsive and collapses on smaller screens.

## Project Structure

- `src/Examples.Navigation.Horizontal.Domain`: Contains the `MenuFragment` entity.
- `src/Examples.Navigation.Horizontal.Application`: Contains interfaces like `IMenuService`.
- `src/Examples.Navigation.Horizontal.Infrastructure`: Contains the in-memory `MenuRepository` and dependency injection setup.
- `src/Examples.Navigation.Horizontal.WebUI`: Contains the Blazor WebAssembly client and server projects, including UI components.

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Running the Application

1. Clone the repository:
   ```sh
   git clone https://github.com/Tirsvad/TirsvadWeb.DotNet.Examples.Navigation.Horizontal.git
   cd TirsvadWeb.DotNet.Examples.Navigation.Horizontal
   ```
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Build the solution:
   ```sh
   dotnet build
   ```
4. Run the WebUI host project (server):
   ```sh
   dotnet run --project src/Examples.Navigation.Horizontal.WebUI/Examples.Navigation.Horizontal.WebUI/Examples.Navigation.Horizontal.WebUI.csproj
   ```
5. Open your browser and navigate to the provided URL (usually `https://localhost:5001` or similar).

## Customization

- To modify the menu structure, edit the `SeedData` method in `MenuRepository.cs`.
- To change the UI, update the Blazor components in the `Components/TopNavBar` folder.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
