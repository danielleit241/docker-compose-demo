# 🐳 Docker Compose: .NET API + SQL Server Starter

A complete beginner-friendly template to run a containerized `.NET Web API` and `SQL Server` using **Docker Compose**.


## 📦 Project Overview

This repo includes:
- A minimal `.NET 8 Web API` with one controller
- A `docker-compose.yml` file to run SQL Server in a container
- A `Dockerfile` to containerize the API
- Sample database connection setup
- Instructions for running and testing locally

---

## 🚀 Getting Started

### 1. Clone the repo

```bash
git clone https://github.com/danielleit241/docker-compose-demo.git
```

### 2. Build & Run with Docker Compose

```bash
docker-compose up --build
```

This will:
- Build the .NET API container
- Pull the official SQL Server image
- Set up networking between containers

### 3. Test the API

Visit:  
`https://localhost:8081/swagger/index.html`
