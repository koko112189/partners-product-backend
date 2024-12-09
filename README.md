# API RESTful para Gestión de Productos
Esta es una API RESTful desarrollada en .NET 6 para la gestión de productos en una tienda en línea. Permite a los usuarios buscar productos, ver sus detalles, guardar productos en una lista de deseos, y gestionar productos y categorías.

## Características

- **Gestión de Productos**: Consultar, agregar y eliminar productos.
- **Gestión de Categorías**: Consultar, agregar y eliminar categorías.
- **Lista de Deseos**: Agregar y eliminar productos en la lista de deseos de un usuario.
- Arquitectura basada en **Clean Architecture**.
- Gestión de datos con **Entity Framework Core** y patrón **Unit of Work**.

---

## Requisitos Previos

- **.NET 6 SDK**
- **SQL Server** (o cualquier base de datos soportada por Entity Framework Core)
- **Herramienta de cliente HTTP** como Postman o cURL para probar la API

---

## Instalación y Configuración

1. **Clonar el repositorio:**

   ```bash
   git clone https://github.com/koko112189/partners-product-backend.git
   cd partners-shop

2. Configurar la base de datos:

Modifica el archivo appsettings.json para incluir la conexión a tu base de datos.

"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DBOnlineStore;User Id=sa;Password=*******;Trust Server Certificate=true;Trusted_Connection=True;"
  }
  
3. Ejecutar migraciones:

Aplica las migraciones para crear las tablas en la base de datos.

´´´bash

dotnet ef database update


# **Endpoints Principales**

## Productos
GET /api/products - Consultar listado de productos.

GET /api/products/{id} - Consultar detalle de un producto.

POST /api/products - Agregar un nuevo producto.

DELETE /api/products/{id} - Eliminar un producto.
## Categorías
GET /api/categories - Consultar listado de categorías.

POST /api/categories - Agregar una nueva categoría.

DELETE /api/categories/{id} - Eliminar una categoría.
## Lista de Deseos
GET /api/wishlist - Consultar lista de deseos de un usuario.

POST /api/wishlist - Agregar un producto a la lista de deseos.

DELETE /api/wishlist/{id} - Eliminar un producto de la lista de deseos.

# Arquitectura
El proyecto sigue los principios de Clean Architecture, con las siguientes capas:

Domain: Contiene las entidades del dominio y lógica empresarial.

Application: Define los servicios, interfaces y casos de uso.

Infrastructure: Implementa los repositorios, acceso a datos y configuración de persistencia.

Presentation: Contiene los controladores de la API.

Desarrollado por John Edison Upegui Acevedo

