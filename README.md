# Scalable Unit Conversion API

A robust, production-ready ASP.NET Core Web API built to handle seamless unit conversions across different physical dimensions (Length and Temperature). 

This solution is engineered using clean code principles and architectural design patterns that make it highly maintainable and easily scalable for an engineering team.

---

## Architectural Highlights

- **The Strategy Pattern:** Instead of relying on a massive, hard-to-maintain block of `if/else` or `switch` statements, each conversion category has its own independent "strategy" class. 
- **High Scalability:** Adding support for "hundreds of units" or brand-new categories (e.g., Volume, Speed, Mass) down the road is simple. A developer only needs to create a new strategy class implementing the `IConversionStrategy` interface—the existing API code remains completely untouched (**Open/Closed Principle**).
- **Two-Step Conversion Model:** To prevent a combinatorial explosion of conversion logic (e.g., writing specific code for Feet-to-CM, Feet-to-MM, Feet-to-Inches), inputs are dynamically converted to a standardized **Base Unit** (like Meters) first, and then translated to the target unit.

---

## Technical Stack
- **Framework:** .NET Core (Latest Web API template)
- **Language:** C#
- **Testing Tool:** `curl` / Command Line HTTP Clients

---

## Getting Started & Execution

### Prerequisites
- .NET SDK (Version 8.0 or 9.0) installed on your system.

### Running the Project Locally
1. Open your terminal and navigate to the project repository folder:
   ```bash
   cd UnitConversionApi
