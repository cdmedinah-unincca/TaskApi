# Gestión de Tareas – API RESTful  
**Autor:** CRISTIAN DAVID MEDINA HERNÁNDEZ
**Código:** 90108
**Fecha:** 20/01/2026

## Descripción  
Esta API RESTful permite gestionar tareas personales mediante operaciones CRUD (Crear, Leer, Actualizar, Eliminar) y la funcionalidad adicional de marcar tareas como completadas. Fue desarrollada en **ASP.NET Core** y utiliza **almacenamiento en memoria** (sin base de datos externa), cumpliendo con los requisitos de la actividad académica.

## Documentación
La documentación de la API se encuentra en el archivo `API RESTful | CRISTIAN DAVID MEDINA H | Código 90108.pdf`.

## Endpoints disponibles
- POST `/api/tareas` → Crear tarea
- GET `/api/tareas` → Listar tareas
- PUT `/api/tareas/{id}` → Actualizar tarea
- DELETE `/api/tareas/{id}` → Eliminar tarea
- PATCH `/api/tareas/{id}/completar` → Marcar tarea como completada

---

## Requisitos

- SDK de .NET 8 instalado ([descargar aquí](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))
- Editor de código (por ejemplo, Visual Studio Code, Antigravity, etc.)
- Postman (para pruebas)

---

## Cómo ejecutar la API

1. Clonar o descargar el repositorio.
2. Abrir una terminal en la carpeta del proyecto (donde está `TaskApi.csproj`).
3. Ejecutar el siguiente comando:
   ```bash
   dotnet run

## Cómo ejecutar las pruebas

1. Abrir Postman.
2. Importar la colección de pruebas (TaskApi.postman_collection.json).
3. Configurar la variable de entorno `base_url` con la URL de la API (por ejemplo, `http://localhost:5278`).
4. Ejecutar las pruebas.