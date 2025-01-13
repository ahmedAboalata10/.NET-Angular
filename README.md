# .NET Core Web API and Angular Project

This project is a full-stack web application developed using **.NET Core Web API** and **Angular**. It showcases key concepts and features I've recently learned, including database integration, dependency injection, CORS policy configuration, and handling self-signed certificates for secure local development.

---

## 📦 Technologies Used
- **Backend:** .NET Core 9 Web API
- **Frontend:** Angular 19
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **Version Control:** Git & GitHub
- **Package Manager:** npm
- **Security:** HTTPS with Self-Signed Certificate Handling, JWT
- **Tools:** Visual Studio, Postman, Swagger UI, VS Code, JetBrains Rider 2024

---

## 📚 Features Implemented
### Backend (ASP.NET Core Web API)
- ✅ **Entity Framework Core Integration:** Configured with `UseSqlServer`.
- ✅ **Database Context:** `DbContext` for managing database operations.
- ✅ **Dependency Injection:** Implemented with scoped services and repositories.
- ✅ **CORS Configuration:** Allowed flexible cross-origin requests for development.
- ✅ **HTTPS Handling:** Configured self-signed certificate handling for local development.

### Frontend (Angular)
- ✅ **Component-Based Architecture:** Modular Angular components structure.
- ✅ **Service Handling:** Implemented Angular services for API communication.
- ✅ **Error Management:** Managed HTTP errors using `HttpErrorResponse`.
- ✅ **Package Management:** Managed dependencies with `npm`.

---

## 🎯 How to Run This Project
### Prerequisites:
- .NET Core SDK Installed
- Node.js Installed
- SQL Server Running
- Visual Studio or VS Code Installed

### Steps:
1. **Clone the Repository:**
   ```bash
   git clone <repository-url>
   ```
2. **Backend Setup:**
   ```bash
   cd API
   dotnet restore
   dotnet build
   dotnet run
   ```
3. **Frontend Setup:**
   ```bash
   cd UI
   npm install
   npm start
   ```
4. **Access the Application:**
   - Swagger UI: `https://localhost:44330/swagger`
   - Angular UI: `http://localhost:4200`

---

## 📂 Project Structure
```
/ProjectRoot
├── API/               # .NET Core Web API
│   ├── Controllers/
│   ├── Context/
│   ├── Repository/
│   └── Program.cs
├── UI/                # Angular Frontend
│   ├── src/app/
│   └── package.json
└── README.md          # Project Documentation
```

---

## ✅ Key Learnings & Concepts Practiced
- 🔥 **Entity Framework Core:** Configured database integration.
- 🔥 **CORS Policies:** Allowed cross-origin resource sharing for development.
- 🔥 **Dependency Injection:** Implemented a clean architecture pattern.
- 🔥 **Self-Signed Certificates:** Handled HTTPS security for local testing.

---

## 📈 Future Improvements
- [ ] Add JWT Authentication
- [ ] Implement Unit Testing for API and Angular components
- [ ] Dockerize the Application
- [ ] Deploy to Cloud Services

---

## 🤝 Contributing
Contributions are welcome! Please fork this repository and submit a pull request with your changes.

---

## 📧 Contact
- **Developer:** Ahmed Mohamed AboAlata
- **Email:** ahmed_c44@outlook.com
- **LinkedIn:** [Ahmed AboAlata](https://www.linkedin.com/in/ahmedaboalata/)

---

### ⭐️ If you found this project helpful, consider giving it a star on GitHub!

