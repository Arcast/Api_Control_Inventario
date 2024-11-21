
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
    Codigo VARCHAR(20),
	Estado bit
);
go

CREATE TABLE Inventario.Producto (
    ProductoId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    NombreProducto VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255),
	FechaCreacion datetime,
	CreadoPor VARCHAR(100)
);
go

CREATE TABLE Inventario.MovimientoInventario (
    MovimientoId UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ProductoId UNIQUEIDENTIFIER,
	BodegaId UNIQUEIDENTIFIER,
    TipoMovimiento VARCHAR(10),
    Cantidad decimal(18,2) NOT NULL,
	Observaciones VARCHAR(255),
    FechaMovimiento DATETIME,
	CreadoPor VARCHAR(100),
    CONSTRAINT FK_ProductoID FOREIGN KEY (ProductoId) REFERENCES Inventario.Producto(ProductoID),
	CONSTRAINT FK_BodegaID FOREIGN KEY (BodegaId) REFERENCES Inventario.Bodega(BodegaId),
	CONSTRAINT CHK_TipoMovimiento CHECK (TipoMovimiento IN ('Entrada', 'Salida')),
);

