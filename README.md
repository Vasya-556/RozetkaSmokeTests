# Rozetka Smoke Tests

Automated smoke tests for Rozetka on C# .NET 9.

Table of contents:
- [Rozetka Smoke Tests](#rozetka-smoke-tests)
  - [Run tests](#run-tests)
    - [Manual](#manual)
    - [Docker](#docker)
  - [Project Structure](#project-structure)
    - [BasePage](#basepage)
    - [AboutPage](#aboutpage)
    - [HomePage](#homepage)
    - [ProductPage](#productpage)
  - [Limitations](#limitations)

## Run tests

### Manual

```bash
HEADED=1 dotnet test
```

Preferred to run it in headed mode since in headless mode tests get blocked by CloudFlare.

### Docker

1. Build the docker image
```bash
docker build -t rozetka-smoke-tests .
```
2. Run the tests
```bash
docker run --rm --init --ipc=host rozetka-smoke-tests
```

## Project Structure

root
|- Readme.md
|- RozetkaSmokeTests.csproj
|
|- Tests/
|-- AboutPage.cs
|-- BasePage.cs
|-- HomePage.cs
|-- ProductPage.cs
|  
|- bin/
|- obj/

### BasePage

Parent of other *Page tests. It inherits from PageTest, provides with BaseUrl, and shared tests.

Shared tests include: 
- Page title contains "Rozetka"
- Nav bar is visible
- Footer is visible

The PageTest provides access to browser page and browser context lifecycle for each test.

### AboutPage

- Expected text visible
- Expected link visible

### HomePage

- Category sidebar works
- Search submission works

### ProductPage

- Product image loads
- Product tabs visible
- But button visible

## Limitations

- Navigation cannot be reliably verified because of CloudFlare. Because of that search test verifies URL navigation, not page results.
- Auth and cart pop-ups do not load in the playwright controlled browser.