# RaceDay Unit Testing Summary

## Overview
Automated unit tests are implemented using **xUnit** in .NET 8.

## Test Classes Covered
* `RaceDayModelTests.cs` - Core model and DTO instantiation tests.
* `EventModelTests.cs` - Event property validation and date logic.
* `CategoryModelTests.cs` - Distance and naming validations.
* `EnrolmentModelTests.cs` - Participant registration status checks.

## Execution
Tests run automatically via **GitHub Actions** on every push to `main` and pull request.
