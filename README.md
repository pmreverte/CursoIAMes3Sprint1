# 📌 Tasks

## 📖 Descripción

Tasks es una aplicación ASP.NET Core con MVC que proporciona endpoints y vistas para gestionar tareas.

## 🚀 Características

- Aplicación ASP.NET Core MVC.
- Configuración de enrutamiento con `Tasks/Index` como página de inicio.
- CRUD de tareas con estados (`Pendiente`, `En Progreso`, `Completado`).

## 📂 Estructura del Proyecto

```
Task/
│-- appsettings.json
│-- appsettings.Development.json
│-- launchSettings.json
│-- Program.cs
│-- Task.csproj
│-- Task.http
│-- Clases/
│   │-- Tareas.cs
│-- Views/
│   │-- Tasks/
│       │-- _Layout.cshtml
│       │-- Create.cshtml
│       │-- Delete.cshtml
│       │-- Edit.cshtml
│       │-- Index.cshtml
```

## ⚙️ Configuración y Uso

### 📌 Requisitos

- .NET 9.0 o superior
- Visual Studio o Visual Studio Code

### 🛠 Instalación

1. Clona el repositorio:
   ```sh
   git clone https://github.com/pmreverte/CursoIAMes3Sprint1
   cd task
   ```
2. Restaura los paquetes:
   ```sh
   dotnet restore
   ```
3. Compila y ejecuta la aplicación:
   ```sh
   dotnet run
   ```

### ▶️ Ejecución en Visual Studio Code

1. Abre Visual Studio Code y carga el directorio del proyecto:
   ```sh
   code .
   ```
2. Asegúrate de tener instalado el **C# Dev Kit** en VS Code.
3. Abre el terminal en VS Code y ejecuta:
   ```sh
   dotnet run
   ```
4. Para depurar la aplicación, presiona `F5` y selecciona **.NET Core Launch (web)**.
5. Accede a la aplicación desde el navegador en:
   ```
   http://localhost:5080
   ```

### 🔗 Endpoints Disponibles

#### 📝 Gestión de Tareas

- **GET** `/tasks/index` → Lista todas las tareas.
- **POST** `/tasks/create` → Crea una nueva tarea.
- **POST** `/tasks/edit` → Edita una tarea existente.
- **POST** `/tasks/delete` → Elimina una tarea.

