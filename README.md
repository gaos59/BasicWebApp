# BasicWebApp

**Aplicación web básica** desarrollada en C#, con arquitectura dividida en API REST (`ProyectoApiRest`) y frontend MVC (`ProyectoWebMVC`). Incluye también una base de datos gestionada con el proyecto `BasicWebApplicationBD`.

---

##  Contenido del repositorio

- `ProyectoApiRest/`  
  API RESTful para manejar operaciones con **Clientes**, **Empleados**, **Vehículos** y **Lavados**.
- `ProyectoWebMVC/`  
  Aplicación web MVC que trabaja como cliente del API, incluyendo vistas para **crear**, **editar**, **borrar** y **reportar** entidades.
- `BasicWebApplicationBD/`  
  Scripts o definiciones de base de datos (o acceso a datos) usados por los proyectos anteriores.

---

##  Tecnologías utilizadas

- ASP.NET Core (C#)
- MVC Pattern (en `ProyectoWebMVC`)
- API REST con `ProyectoApiRest`
- Colecciones en memoria o base de datos ligera
- Swagger (OpenAPI) para documentar y probar el API
- Razor Views en el frontend MVC

---

##  Instalación & ejecución

### Clonado del proyecto

```bash
git clone https://github.com/gaos59/BasicWebApp.git
cd BasicWebApp
