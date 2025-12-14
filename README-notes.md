This repository implements a Commission Calculator for Avalpha Technologies.
The application calculates both Avalpha and competitor commissions based on local and foreign sales, and average sale amount.

The project is divided into:

Backend: .NET C# API (api folder)

Frontend: React (ui folder)

Features Implemented

Backend

CommissionCalculatorService calculates:

Avalpha Technologies Commission (Local: 20%, Foreign: 35%)

Competitor Commission (Local: 2%, Foreign: 7.55%)

CommisionController uses the service to return a structured JSON response.

Input validation included in API via typed model CommissionCalculationRequest.

Frontend (React)

Form inputs for Local Sales Count, Foreign Sales Count, Average Sale Amount.

Calls backend API (/Commision) via fetch.

Displays:

Avalpha Technologies Commission

Competitor Commission

Advantage (difference between Avalpha and competitor)

Handles loading state and errors gracefully.

Currency formatting for GBP.

Unit Tests

xUnit tests added for CommissionCalculatorService.

Tests verify commission calculations and edge cases.

How to Run
Backend

Open the solution in Visual Studio.

Build the solution to restore NuGet packages.

Run the API project (api) → it will start at https://localhost:5000 by default.

Use Swagger UI (https://localhost:5000/swagger/index.html) to test endpoints.

Frontend

Navigate to ui folder in terminal.

Install dependencies:

npm install

Start the React app:

npm start

Open browser: http://localhost:3000

The app will call the backend API for commission calculation.

Ensure backend is running on port 5000 before submitting the frontend form.

How to Test
Backend Unit Tests

Open Test Explorer in Visual Studio.

Build the solution.

Run all tests in the xUnit test project.

The tests validate correct calculation of Avalpha and competitor commissions using CommissionCalculationRequest.

Frontend

Manual testing via the React form by entering values and verifying results.

Design Decisions & Trade-offs

Service Layer (SOLID Principles)

Commission calculation is separated into CommissionCalculatorService to follow Single Responsibility Principle.

Controller only handles HTTP request/response.

Frontend

Used React useState for form and results state.

fetch is used instead of Axios to keep dependencies minimal.

Conditional rendering added to prevent errors when API results are null.

Error Handling

Backend: Returns 400/500 for invalid or failed requests.

Frontend: Shows error messages without crashing the UI.

Testing

xUnit chosen for backend unit tests.