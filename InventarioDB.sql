
----Proyecto de curso Noel Vilchez

Create database Control_Inventario;
go

use Control_Inventario;
go

-- Crear un esquema de base de datos "Inventario"
CREATE SCHEMA Inventario;

CREATE TABLE Inventario.Bodega (
    BodegaId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Nombre VARCHAR(100) NOT NULL,
    Codigo VARCHAR(20)    
);
go

CREATE TABLE Inventario.Proveedor (
    ProveedorId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Direccion VARCHAR(255)
);
go

CREATE TABLE Inventario.Categoria (
    CategoriaId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255)
);

CREATE TABLE Inventario.Producto (
    ProductoId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255),
    Precio DECIMAL(10, 2) NOT NULL,
    StockActual INT NOT NULL,
    StockMinimo INT NOT NULL,
    CategoriaId UNIQUEIDENTIFIER,
	FechaCreacion datetime,
	CreadoPor VARCHAR(100),
	FechaModificacion datetime,
	ModificadoPor VARCHAR(100),
	CONSTRAINT FK_CategoriaID FOREIGN KEY (CategoriaId) REFERENCES Inventario.Categoria(CategoriaId)
);
go

CREATE TABLE Inventario.MovimientoInventario (
    MovimientoID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ProductoID UNIQUEIDENTIFIER,
    ProveedorID UNIQUEIDENTIFIER,
    TipoMovimiento VARCHAR(10),
    Cantidad INT NOT NULL,
    FechaMovimiento DATE NOT NULL,
    Observaciones VARCHAR(255),
	FechaCreacion datetime,
	CreadoPor VARCHAR(100),
	FechaModificacion datetime,
	ModificadoPor VARCHAR(100)
    CONSTRAINT FK_ProductoID FOREIGN KEY (ProductoId) REFERENCES Inventario.Producto(ProductoID),
    CONSTRAINT FK_ProveedorID FOREIGN KEY (ProveedorId) REFERENCES Inventario.Proveedor(ProveedorID),
	CONSTRAINT CHK_TipoMovimiento CHECK (TipoMovimiento IN ('Entrada', 'Salida')),
);

