[![downloads][downloads-shield]][downloads-url][![Contributors][contributors-shield]][contributors-url][![Forks][forks-shield]][forks-url][![Stargazers][stars-shield]][stars-url][![Issues][issues-shield]][issues-url][![License][license-shield]][license-url][![LinkedIn][linkedin-shield]][linkedin-url]

# ![Logo][Logo] Navigation Horizontal Example

## Overview

This project demonstrates a horizontal navigation menu in a Blazor WebAssembly application. On branch `01-MenuBasedOnJson`, the menu structure is defined in the `navBar.json` file (not in code), making it easy to customize the navigation without recompiling. It is designed as an example for building dynamic, multi-level navigation menus in modern .NET Blazor applications.

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

1. **Menu Data**: The menu structure is defined in the `navBar.json` file located at `src/Examples.Navigation.Horizontal.WebUI/Examples.Navigation.Horizontal.WebUI/wwwroot/navBar.json`. Each menu item can have nested `SubItems` for submenus.
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
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (optional, for containerization)

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

### Running with Docker-Compose

1. Build and run the application using Docker-Compose:
   ```sh
   docker-compose up --build
   ```
1. Open your browser and navigate to `http://localhost:5401` to see the application running.


## Customization

### Editing the Menu Structure (branch 01-MenuBasedOnJson)

To modify the menu structure, edit the `navBar.json` file located at:

```
src/Examples.Navigation.Horizontal.WebUI/Examples.Navigation.Horizontal.WebUI/wwwroot/navBar.json
```

#### Example `navBar.json` structure:

```json
{
  "NavBar": {
    "Title": "TirsvadWeb<br />Web Examples"
  },
  "NavItems": [
    {
      "Id": "8fdd56d5-fd85-46cb-9c75-5192aca81dc2",
      "Title": "Home",
      "Url": "/",
      "Order": 1
    },
    {
      "Id": "d1c9e5b8-3a2f-4c9e-8b6a-1f2e3d4c5b6a",
      "Title": "Menu 1",
      "Url": "/",
      "Order": 2,
      "SubItems": [
        {
          "Id": "a1b2c3d4-e5f6-7890-abcd-1234567890ab",
          "Title": "SubMenu 1.1",
          "Url": "/",
          "Order": 1
        }
      ]
    }
  ]
}
```

- Each menu item requires a unique `Id`, a `Title`, a `Url`, and an `Order` (for sorting).
- To add submenus, use the `SubItems` array inside a menu item.

After saving changes to `navBar.json`, restart the application to see the updated menu.

To change the UI, update the Blazor components in the `Components/TopNavBar` folder.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Branches

- **main**: The primary branch with the latest stable code.
- **01-MenuBasedOnJson**: Demonstrates menu structure defined in `navBar.json` for dynamic navigation
- **02-MenuBasedOnDatabase**: (Planned) Example of menu structure stored in a database with Entity Framework Core.
- 

<!-- Links Badges -->
[contributors-shield]: https://img.shields.io/github/contributors/TirsvadWeb/DotNet.Examples.Navigation.Horizontal?style=for-the-badge
[contributors-url]: https://github.com/TirsvadWeb/DotNet.Examples.Navigation.Horizontal/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/TirsvadWeb/DotNet.Examples.Navigation.Horizontal?style=for-the-badge
[forks-url]: https://github.com/TirsvadWeb/DotNet.Examples.Navigation.Horizontal/network/members
[stars-shield]: https://img.shields.io/github/stars/TirsvadWeb/DotNet.Examples.Navigation.Horizontal?style=for-the-badge
[stars-url]: https://github.com/TirsvadWeb/DotNet.Examples.Navigation.Horizontal/stargazers
[issues-shield]: https://img.shields.io/github/issues/TirsvadWeb/DotNet.Examples.Navigation.Horizontal?style=for-the-badge
[issues-url]: https://github.com/TirsvadWeb/DotNet.Examples.Navigation.Horizontal/issues
[license-shield]: https://img.shields.io/github/license/TirsvadWeb/DotNet.Examples.Navigation.Horizontal?style=for-the-badge
[license-url]: https://github.com/TirsvadWeb/DotNet.Examples.Navigation.Horizontal/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/jens-tirsvad-nielsen-13b795b9/
[downloads-shield]: https://img.shields.io/github/downloads/TirsvadWeb/DotNet.Examples.Navigation.Horizontal/total?style=for-the-badge
[downloads-url]: https://github.com/TirsvadWeb/DotNet.Examples.Navigation.Horizontal/releases

[logo]: https://raw.githubusercontent.com/TirsvadCLI/Logo/main/images/logo/32x32/logo.png "Logo"

<!-- Github Links -->
[githubIssue-url]: https://github.com/TirsvadWeb/DotNet.Examples.Navigation.Horizontal/issues/
[githubMilestones-url]: https://github.com/TirsvadWeb/DotNet.Examples.Navigation.Horizontal/milestones

<!-- Project Links -->
[projectDocumentation-url]: https://dev.tirsvad.dk/projects/TirsvadWeb/DotNet.Examples.Navigation.Horizontal
