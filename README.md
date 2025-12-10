# ?? Prueba Técnica — Gestión de Tareas (Clean Architecture + .NET 8 + EF Core)

Este proyecto implementa una API REST para gestionar tareas, desarrollada como parte de una prueba técnica.  
Incluye buenas prácticas, arquitectura limpia, validaciones, mapeos, migraciones y CI/CD preparado para Azure DevOps.

---

## ?? Tecnologías utilizadas

- .NET 8 (API REST)
- Entity Framework Core 8 (Code First)
- SQL Server / LocalDB
- AutoMapper
- FluentValidation
- Swagger / OpenAPI
- Azure DevOps Repos y Pipelines
- Clean Architecture (Core, Infrastructure, API)

---

## ?? Estructura del proyecto

/TaskManager.Core
??? Entities
??? Enums
??? Interfaces
??? DTOs

/TaskManager.Infrastructure
??? Context
??? Repositories
??? Migrations

/PruebaTecnicaLslGestionTareas (API)
??? Controllers
??? Profiles
??? Validators
??? Requests
??? Responses
??? Middlewares


### ??? Arquitectura

El proyecto está dividido siguiendo el patrón **Clean Architecture**:

- **Core**  
  Contiene reglas de negocio puras: entidades, interfaces, enums, DTOs.

- **Infrastructure**  
  Contiene implementaciones concretas: EF Core, Repositorios, DBContext.

- **API**  
  Expone los endpoints, controla solicitudes, validaciones, AutoMapper, middlewares y DI.

---

## ??? Configuración del entorno

### ?? 1. Clonar el repositorio

bash
git clone https://san2486@dev.azure.com/san2486/Sistema%20de%20Gesti%C3%B3n%20de%20Tareas/_git/Sistema%20de%20Gesti%C3%B3n%20de%20Tareas
cd PruebaTecnicaLslGestionTareas

?? 2. Configurar cadena de conexión

En appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TaskManagerDb;Trusted_Connection=True;"
}

??? 3. Aplicar migraciones

Desde la carpeta de la API:

dotnet ef migrations add InitialCreate -p ../TaskManager.Infrastructure -s .
dotnet ef database update -p ../TaskManager.Infrastructure -s .


? 4. Ejecutar el proyecto
dotnet run

La API estará disponible en http://localhost:5000 o https://localhost:5001

Swagger disponible en:
http://localhost:5000/swagger/index.html


?? Endpoints principales (TasksController)
Método	URL	Descripción
GET	/api/tasks	Listar tareas
GET	/api/tasks/{id}	Obtener tarea por ID
POST	/api/tasks	Crear nueva tarea
PUT	/api/tasks/{id}	Actualizar tarea
DELETE	/api/tasks/{id}	Eliminar tarea

?? Patrones aplicados

Repository Pattern
Abstrae operaciones CRUD.

Unit of Work
Maneja transacciones coherentes.

DTOs + AutoMapper
Desacopla modelos de dominio de modelos de entrada/salida.

FluentValidation
Para validar DTOs de entrada.

Middleware global de excepciones
Manejo de errores consistente.

Dependency Injection
Nativo de .NET, configurado en Program.cs.


?? CI/CD en Azure DevOps

El pipeline incluye:

?? Build

Restauración de paquetes

Compilación del proyecto

Ejecución de migraciones (opcional en Release)

?? Deploy

Publicación a Azure App Service

Pipeline YAML ubicado en:
.azure-pipelines/ci-cd-pipeline.yml

????? Autor

Luis Santiago
Prueba técnica realizada como entrega para arquitectura de software .NET