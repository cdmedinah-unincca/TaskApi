# Gestión de Tareas – API RESTful  
##Autor: CRISTIAN DAVID MEDINA HERNÁNDEZ
##Código: 90108
##Fecha: v0.1 - 20/01/2026 | v0.2 - 20/01/2026

## Descripción v0.1
Esta API RESTful permite gestionar tareas personales mediante operaciones CRUD (Crear, Leer, Actualizar, Eliminar) y la funcionalidad adicional de marcar tareas como completadas. Fue desarrollada en **ASP.NET Core** y utiliza **almacenamiento en memoria** (sin base de datos externa), cumpliendo con los requisitos de la actividad académica.

### Actualización v0.2
Para la actividad 2 se adicionan todas validaciones que se realizan mediante **Data Annotations**.
- El campo title es obligatorio.
- Se usan Data Annotations ([Required], [MinLength]) en el modelo TaskModel.
- ASP.NET Core valida automáticamente el modelo: si falla, devuelve errores detallados en JSON.

Ejemplo de error:
```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Title": ["El título es obligatorio."]
  }
}
```

Este proyecto corresponde a las **Actividades 1 y 2** del curso, cumpliendo con los siguientes requisitos:
- Operaciones CRUD básicas
- Búsqueda por título o descripción
- Cambio de estado entre "completada" y "pendiente"
- Validación obligatoria del título

---

## Documentación

### v0.1
La documentación de la API se encuentra en el archivo `API RESTful | CRISTIAN DAVID MEDINA H | Código 90108.pdf`.

### v0.2
La documentación de la API se encuentra en el archivo `Complemento API RESTful | CRISTIAN DAVID MEDINA H | Código 90108.pdf`.

---

## Endpoints disponibles v0.1
- POST `/api/tareas` → Crear tarea
- GET `/api/tareas` → Listar tareas
- PUT `/api/tareas/{id}` → Actualizar tarea
- DELETE `/api/tareas/{id}` → Eliminar tarea
- PATCH `/api/tareas/{id}/completar` → Marcar tarea como completada

### Actualización v0.2
Para la actividad 2 se adicionan los siguientes endpoints:

- GET `/api/tareas/buscar?q={palabra}` → Buscar tareas por título o descripción
- PATCH `/api/tareas/{id}/pendiente` → Marcar tarea como pendiente

---

## Requisitos

- SDK de .NET 8 instalado ([descargar aquí](https://dotnet.microsoft.com/en-us/download/dotnet/8.0))
- Editor de código (por ejemplo, Visual Studio Code, Antigravity, etc.)
- Postman (para pruebas)

## Cómo ejecutar la API

1. Clonar o descargar el repositorio.
2. Abrir una terminal en la carpeta del proyecto (donde está `TaskApi.csproj`).
3. Ejecutar el siguiente comando:
   ```bash
   dotnet run

## Cómo ejecutar las pruebas

1. Abrir Postman.

### Pruebas v0.1
2. Importar la colección de pruebas (TaskApi.postman_collection.json).
3. Configurar la variable de entorno `base_url` con la URL de la API (por ejemplo, `http://localhost:5278`).
4. Ejecutar las pruebas.

### Pruebas v0.2
2. Importar la colección de pruebas (TaskApi.postman_collection_v0.2.json).
3. Configurar la variable de entorno `base_url` con la URL de la API (por ejemplo, `http://localhost:5278`).
4. Ejecutar las pruebas.
