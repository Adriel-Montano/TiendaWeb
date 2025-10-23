#  Gestión de Productos en Línea – ASP.NET Core MVC + Web API

##  Descripción General
**Gestión de Productos en Línea** es una aplicación desarrollada en **ASP.NET Core 8.0** que permite administrar un inventario básico de productos electrónicos.  
El sistema está estructurado bajo una arquitectura **en tres capas (Datos, API y Web)**, con integración directa a **SQL Server** mediante **Entity Framework Core** y comunicación entre proyectos usando **HttpClient**.

---

## Estructura del Proyecto

### 1 Capa de Datos (SQL Server / EF Core)
- Base de datos: `ProductoDb`  
- Tabla principal: `Productos`
- Campos:
  - `Id` (int, PK, identity)
  - `Nombre` (nvarchar(100))
  - `Precio` (decimal(10,2))
  - `Stock` (int)

> La base de datos fue **creada manualmente** en SQL Server Management Studio (SSMS) y conectada al proyecto API desde el **Explorador de servidores** en Visual Studio.

 **Script de creación:**
```sql
IF DB_ID('TiendaDB') IS NULL
BEGIN
    CREATE DATABASE TiendaDB;
END
GO

USE TiendaDB;
GO

IF OBJECT_ID('dbo.Productos','U') IS NULL
BEGIN
    CREATE TABLE dbo.Productos (
        Id     INT IDENTITY(1,1) PRIMARY KEY,
        Nombre NVARCHAR(100) NOT NULL,
        Precio DECIMAL(10,2) NOT NULL,
        Stock  INT NOT NULL DEFAULT 0
    );
END
GO
```

**Inserción de productos de ejemplo:**
```sql
USE ProductoDb;
GO

INSERT INTO dbo.Productos (Nombre, Precio, Stock) VALUES
('Disco duro externo Seagate 2TB', 74.50, 11),
('Memoria USB Kingston 64GB', 12.99, 20),
('Cargador rápido Anker 25W USB-C', 24.99, 15),
('Smartwatch Amazfit Bip 3', 89.00, 6),
('Webcam Logitech C920 HD', 69.99, 8),
('Micrófono condensador Fifine K690', 84.50, 5),
('Router TP-Link Archer AX23 WiFi 6', 99.99, 7),
('Power Bank Baseus 20,000mAh', 38.90, 10),
('Impresora Epson EcoTank L3250', 199.00, 3),
('Adaptador HDMI a VGA', 9.50, 25),
('Cable USB-C trenzado 1m', 6.99, 30),
('Monitor curvo LG UltraGear 27”', 289.00, 2);
```

---

### 2 Capa de Servicios (Web API)
**Proyecto:** `TiendaAPI`

Proporciona los endpoints RESTful que permiten realizar las operaciones CRUD sobre la base de datos.

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | `/api/productos` | Lista todos los productos |
| GET | `/api/productos/{id}` | Obtiene un producto por ID |
| POST | `/api/productos` | Crea un nuevo producto |
| PUT | `/api/productos/{id}` | Actualiza un producto |
| DELETE | `/api/productos/{id}` | Elimina un producto |

 **Swagger:**  
`https://localhost:44314/swagger`

---

### 3Capa de Presentación (Web MVC)
**Proyecto:** `TiendaWeb`

Consume los endpoints del API mediante **HttpClient**.  
Incluye controladores y vistas Razor para gestionar los productos.

 **Vistas principales:**
- `Index.cshtml` → Lista de productos.  
- `Create.cshtml` → Formulario de alta.  
- `Details.cshtml` → Vista detallada.  
- `Edit.cshtml` → Edición de productos.  
- `Delete.cshtml` → Confirmación de eliminación.  

 **Diseño visual:**  
Interfaz moderna basada en **Bootstrap 5**, con fondo violeta-rosado degradado y botones con colores tipo Swagger (azul, verde, naranja, rojo).

---

## ⚙️ Ejecución del Proyecto

1. **Ejecutar la API (TiendaAPI)**  
   Abre `https://localhost:44314/swagger` para probar los endpoints CRUD.

2. **Ejecutar la Web (TiendaWeb)**  
   Abre `https://localhost:44317/Productos` para acceder al sitio.

3. **Verificación de datos**  
   Los cambios realizados desde la web se reflejan en la base de datos `ProductoDb` en SQL Server.

---

##  Autor
**Adriel Caleb Montano Lemus**  
Proyecto desarrollado como parte del *Tercer Desafío Práctico – Programación Web ASP.NET Core (2025)*.
  

  ## link de la api` https://github.com/Adriel-Montano/TiendaAPI`
