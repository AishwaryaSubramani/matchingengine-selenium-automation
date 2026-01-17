# 🧩 Matching Engine – Selenium Automation Framework

This repository contains a **UI automation testing framework** built using **Selenium WebDriver with C# and NUnit** to validate functionality on  
https://www.matchingengine.com

The automation focuses on the **Repertoire Management Module**, ensuring that supported products are displayed correctly and consistently.
---

## 🎯 Project Objective

The goal of this project is to automatically verify:

- Navigation to the **Repertoire Management Module**
- Visibility of the **Products Supported** section
- Accuracy of the supported product list displayed on the website

---

## 📁 Project Structure

MatchingEngineSeleniumAutomation

├── Drivers  (Browser and WebDriver setup(Chrome))

├── PageObjects (Page Object Models (locators + user actions) )

├── Tests (NUnit test classes)

├── Utilities  (Reusable assertions and wait helpers)

├── TestResults  (Raw test execution results (ignored in .gitignore) )

├── TestReports  (HTML code coverage reports (ignored in .gitignore) )

├── test.runsettings  (Code coverage configuration)

├── MatchingEngineAutomation.csproj

├── README.md  (Project documentation)


---

## Test Scenario Automated

1. Navigate to [https://www.matchingengine.com](https://www.matchingengine.com)
2. Expand **Modules** in the header
3. Click on **Repertoire Management Module**
4. Scroll to the **Additional Features** section
5. Click on **Products Supported**
6. Assert the visibility of the heading:  
   *There are several types of Product Supported:*
7. Validate the presence of:
   - Cue Sheet / AV Work
   - Recording
   - Bundle
   - Advertisement
   

---

## ⚙️ Tech Stack

- **Language:** C#
- **Framework:** .NET 9
- **Test Framework:** NUnit
- **Browser Automation:** Selenium WebDriver (Chrome)
- **Reporting:** ReportGenerator (HTML Code Coverage)
- **Design Pattern:** Page Object Model (POM)

---

## ▶️ How to Run the Tests

# Restore packages
dotnet restore

# Build the project
dotnet build

# Run tests with code coverage
dotnet test --collect:"XPlat Code Coverage" --settings test.runsettings

## Generate HTML Coverage Report

reportgenerator -reports:"TestResults\**\coverage.cobertura.xml" -targetdir:"TestReports" -reporttypes:Html

Then open:
TestReports/index.html

##NuGet Packages Used

1. Selenium.WebDriver
2. Selenium.WebDriver.ChromeDriver
3. DotNetSeleniumExtras.WaitHelpers
4. NUnit, NUnit3TestAdapter, Microsoft.NET.Test.Sdk
5. coverlet.collector (for code coverage)

## Git Ignore Highlights

Compiled files (bin/, obj/)

Test outputs (TestResults/, TestReports/)

Editor configs and system files

