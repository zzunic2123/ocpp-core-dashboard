# ⚡ OCPP Proxy Dashboard

A web application for monitoring electric vehicle (EV) charging stations via the **Open Charge Point Protocol (OCPP) 1.6**. It exposes a REST API for frontend data retrieval while maintaining a real‑time WebSocket connection to charge points, enabling live status, session tracking and historical insight.
## Features
- Display of **active charging sessions**, **historical sessions**, and **registered chargers** with their current status. 
- OCPP 1.6 message handling (e.g., `BootNotification`, `MeterValues`, `StartTransaction`, `StopTransaction`).
- Dual‑channel backend: REST layer for the dashboard UI + WebSocket layer for bidirectional charger communication.
- JSON used as the uniform data exchange format

## Technologies
**Backend:** C# / .NET 8 (ASP.NET Core Web API with WebSocket support)  
**Frontend:** HTML5, CSS3, JavaScript (single static page consuming REST API)  
**Protocols:** WebSocket (real‑time OCPP), REST (dashboard), JSON (payloads)  
**Tooling:** Git & GitHub for version control.

## OCPP Overview
OCPP is an open protocol standardizing communication between EV charging stations (charge points) and a central management system (CPMS). This project implements the **OCPP 1.6 JSON/WebSocket** variant to ensure interoperability and real‑time event handling. 

## System Architecture
The system is organized into three parts:  
- **Frontend:** HTML/JS dashboard consuming REST endpoints to render charger status and sessions.  
- **Backend:** .NET 8 service exposing REST endpoints and a WebSocket endpoint; processes incoming OCPP messages and persists/serves session data.  
- **Chargers:** Physical or simulated devices connecting over WebSocket to send events and receive commands. 

Backend layering separates message processing, business logic (session storage, validation), and data access to keep the solution modular, testable, and scalable.

## ▶️ Running the Project

### 1. Backend (OCPP.Core)
Ensure .NET 8 SDK is installed, then from the repository root run:
```bash
dotnet run --project OCPP.Core/OCPP.Core.csproj
```
The backend listens at http://localhost:5281

### 2.  Frontend
Open Frontend.html directly in a browser or via a simple local server (e.g., VS Code Live Server). It will automatically call the REST API to display active, historical sessions and charger list. 
