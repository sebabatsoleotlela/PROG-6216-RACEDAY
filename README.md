# RaceDay - Full-Stack Event Management System

## Project Overview
**RaceDay** is a web-based event management system designed specifically for the South African road running, walking, and cycling community. It enables Event Organisers to create and manage events, categories, and participant results while allowing Participants to browse events, enter categories, and track performance history.

* **Course Module:** PROG6212 / PROG6216
* **Project Phase:** Part 2 - RESTful API & Automated Testing

---

## Repository Structure

```text
RaceDay/
├── .github/
│   └── workflows/
│       ├── ci-cd.yml             # Automated CI/CD build & test pipeline
│       └── docs-validation.yml   # CI/CD Workflow for /docs verification
├── docs/
│   ├── api-plan.md               # RESTful API Endpoint Specification
│   ├── erd.png                   # Entity Relationship Diagram
│   └── schema.sql                # Database Schema & Seed Data Script
├── RaceDay.API/                  # ASP.NET Core Web API Project
└── RaceDay.Tests/                # xUnit Automated Unit Test Suite
