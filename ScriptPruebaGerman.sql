USE master

GO

IF exists (select * from sysdatabases where name='FacturaBD')
BEGIN
  DROP database FacturaBD
END
ELSE
BEGIN
  CREATE DATABASE FacturaDB
ON
( NAME = Factura_dat,
    FILENAME = 'C:\MSSQL\DATA\Facturadat.mdf',
    SIZE = 10,
    MAXSIZE = 50,
    FILEGROWTH = 5 )
LOG ON
( NAME = Sales_log,
    FILENAME = 'C:\MSSQL\DATA\Facturalog.ldf',
    SIZE = 5MB,
    MAXSIZE = 25MB,
    FILEGROWTH = 5MB ) ;
END
GO


USE [FacturaBD]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 2/14/2019 11:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCliente] [nvarchar](5) NOT NULL,
	[NombreCliente] [nvarchar](20) NULL,
	[DireccionCliente] [nvarchar](60) NULL,
	[TelefonoCliente] [nvarchar](10) NULL,
	[DescripcionCliente] [nvarchar](10) NULL,
	[FechaIngreso] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaDetalle]    Script Date: 2/14/2019 11:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaDetalle](
	[IdFacturaDetalle] [int] IDENTITY(1,1) NOT NULL,
	[IdFacturaEncabezado] [int] NULL,
	[IdProducto] [int] NULL,
	[CodigoProducto] [nvarchar](5) NOT NULL,
	[NombreProducto] [nvarchar](30) NULL,
	[Descuento] [Decimal] NULL,
	[Cantidad] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFacturaDetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacturaEncabezado]    Script Date: 2/14/2019 11:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacturaEncabezado](
	[IdFacturaEncabezado] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NULL,
	[NumeroFactura] [nvarchar](6) NOT NULL,
	[CodigoEmpresa] [nvarchar](5) NULL,
	[CodigoCliente] [nvarchar](5) NULL,
	[Sub_Total] [Decimal] NULL,
	[Impuesto] [Decimal] NULL,
	[Total] [Decimal] NULL,
	[FechaFactura] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdFacturaEncabezado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 2/14/2019 11:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[CodigoProducto] [nvarchar](5) NOT NULL,
	[NombreProducto] [nvarchar](30) NULL,
	[PrecioUnitario] [Decimal] NULL,
	[PrecioCosto] [Decimal] NULL,
	[Stock] [smallint] NULL,
	[StockMinimo] [smallint] NULL,
	[FechaIngreso] [smalldatetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 2/14/2019 11:03:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[NombreUsuario] [nchar](20) NULL,
	[Clave] [nchar](20) NULL,
	[LogIngresos] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD FOREIGN KEY([IdFacturaEncabezado])
REFERENCES [dbo].[FacturaEncabezado] ([IdFacturaEncabezado])
GO
ALTER TABLE [dbo].[FacturaDetalle]  WITH CHECK ADD FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Productos] ([IdProducto])
GO
ALTER TABLE [dbo].[FacturaEncabezado]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO

SET IDENTITY_INSERT Clientes ON
GO
insert into clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente, DescripcionCliente, FechaIngreso) values (1, '0PSZ', 'Sheff Banham', '91 Sutteridge Hill', '183 5740', 'Peru', '12/14/2018');
insert into clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente, DescripcionCliente, FechaIngreso) values (2, '0BJZ', 'Gill Please', '6 Kinsman Point', '389 8090', 'Malta', '12/24/2018');
insert into clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente, DescripcionCliente, FechaIngreso) values (3, '09HZ', 'Paten Huglin', '48512 Ridgeway Point', '647 8987', 'Greece', '2/3/2019');
insert into clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente, DescripcionCliente, FechaIngreso) values (4, '06QZ', 'Gwenette Shawell', '903 Pankratz Plaza', '923 4461', 'China', '9/10/2018');
insert into clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente, DescripcionCliente, FechaIngreso) values (5, '0F9Z', 'Sileas Yeell', '3 Del Mar Park', '273 7261', 'Russia', '9/6/2018');
insert into clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente, DescripcionCliente, FechaIngreso) values (6, '0FWZ', 'Lemmy Carloni', '700 Utah Court', '457 1108', 'Croatia', '5/1/2018');
insert into clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente, DescripcionCliente, FechaIngreso) values (7, '0SNZ', 'Farica Markwick', '9 Dunning Lane', '467 6772', 'El Salvador', '3/21/2018');
insert into clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente, DescripcionCliente, FechaIngreso) values (8, 'CP1Z', 'Fallon Butterfint', '01 Becker Park', '991 5915', 'Sweden', '9/28/2018');
insert into clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente, DescripcionCliente, FechaIngreso) values (9, '089Z', 'Natale MacIllrick', '20214 Hazelcrest Center', '756 4058', 'Brazil', '12/20/2018');
insert into clientes (IdCliente, CodigoCliente, NombreCliente, DireccionCliente, TelefonoCliente, DescripcionCliente, FechaIngreso) values (10, '0LZZ', 'Hartley Chedgey', '3892 Park Meadow Circle', '338 2852', 'Indonesia', '2/5/2019');

GO
SET IDENTITY_INSERT Clientes OFF

GO

SET IDENTITY_INSERT Productos ON

GO

insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (1, '6446', 'Soup - Knorr, Chicken Noodle', 514.78, 16, 49, 11, '10/25/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (2, '4885', 'Chilli Paste, Sambal Oelek', 7425.75, 862, 46, 35, '6/1/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (3, '1336', 'Kale - Red', 5994.59, 851, 51, 64, '10/17/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (4, '9239', 'Soup - Boston Clam Chowder', 3393.76, 975, 17, 21, '12/30/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (5, '3277', 'Soup - Campbells', 4864.53, 128, 84, 41, '3/12/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (6, '2083', 'Cookie Dough - Chocolate Chip', 6061.19, 949, 6, 45, '9/30/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (7, '6122', 'Pasta - Shells, Medium, Dry', 1862.82, 992, 83, 6, '1/17/2019');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (8, '7132', 'Toothpick Frilled', 3315.11, 923, 21, 36, '3/18/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (9, '4922', 'Savory', 2684.76, 782, 67, 65, '2/2/2019');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (10, '5525', 'Salt - Sea', 2789.07, 697, 53, 64, '11/20/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (11, '4482', 'Vaccum Bag 10x13', 2237.09, 296, 45, 2, '1/18/2019');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (12, '3378', 'Pie Shell - 9', 271.54, 873, 31, 80, '7/20/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (13, '3290', 'Urban Zen Drinks', 7551.9, 969, 47, 4, '12/12/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (14, '5052', 'Cardamon Seed / Pod', 9677.14, 484, 62, 78, '5/25/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (15, '0101', 'Beef - Cow Feet Split', 9132.94, 693, 25, 57, '12/18/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (16, '3134', 'Oil - Olive', 3295.84, 643, 90, 28, '9/30/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (17, '6775', 'Bread - 10 Grain Parisian', 894.43, 357, 9, 81, '1/4/2019');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (18, '5786', 'Seedlings - Mix, Organic', 7818.31, 443, 12, 95, '3/7/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (19, '7910', 'Mint - Fresh', 4769.11, 966, 60, 49, '9/1/2018');
insert into Productos (IdProducto, CodigoProducto, NombreProducto, precioUnitario, precioCosto, stock, stockMinimo, FechaIngreso) values (20, '0791', 'Nut - Natural', 654.39, 777, 42, 89, '6/29/2018');

GO

SET IDENTITY_INSERT Productos OFF

GO

CREATE PROCEDURE [dbo].[GetAllClientes]

AS
	SELECT
	      IdCliente,
		  CodigoCliente, 
		   NombreCliente, 
		   DireccionCliente, 
		   TelefonoCliente,
		   DescripcionCliente
		   FechaIngreso
		   FROM Clientes
RETURN 0

GO

CREATE PROCEDURE [dbo].[ClientesInsert]
	@P_CodigoCliente NVARCHAR (5), 
	@P_NombreCliente nvarchar(20),
	@P_DireccionCliente nvarchar(60), 
	@P_TelefonoCliente nvarchar(10),
	@P_DescripcionCliente nvarchar(10),
	@P_FechaIngreso smalldatetime,
	@Identity INT OUT
AS
	INSERT INTO Clientes(
		    CodigoCliente, 
		    NombreCliente, 
		    DireccionCliente, 
		    TelefonoCliente,
		    DescripcionCliente,
		    FechaIngreso)
	values(
		@P_CodigoCliente,
		@P_NombreCliente,
		@P_DireccionCliente, 
		@P_TelefonoCliente,
		@P_DescripcionCliente,
		@P_FechaIngreso
	);
	SET @Identity = SCOPE_IDENTITY();
GO

CREATE PROCEDURE [dbo].[ClientesUpdate]
	@P_CodigoCliente NVARCHAR (5), 
	@P_NombreCliente nvarchar(20),
	@P_DireccionCliente nvarchar(60), 
	@P_TelefonoCliente nvarchar(10),
	@P_DescripcionCliente nvarchar(10),
	@P_FechaIngreso smalldatetime,
	@P_IdCliente int
AS

	UPDATE Clientes 
	SET
		   CodigoCliente    = @P_CodigoCliente,
		    NombreCliente	= @P_NombreCliente,
		    DireccionCliente = @P_DireccionCliente,
		    TelefonoCliente  =  @P_TelefonoCliente,
		    DescripcionCliente = @P_DescripcionCliente,
		    FechaIngreso	  = @P_FechaIngreso
 WHERE 			  
		IdCliente = @P_IdCliente;

SET @Identity = SCOPE_IDENTITY();
GO
CREATE PROCEDURE [dbo].[ClientesDelete]
	@P_IdCliente int
	
AS
	DELETE FROM Clientes WHERE IdCliente = @P_IdCliente
RETURN 0

GO

CREATE PROCEDURE [dbo].[GetIdClientes]
	@P_IdCliente int
AS
	SELECT CodigoCliente, 
		   NombreCliente, 
		   DireccionCliente, 
		   TelefonoCliente,
		   DescripcionCliente
		   FechaIngreso
		   FROM Clientes
		   WHERE IdCliente = @P_IdCliente

RETURN 0

GO
CREATE PROCEDURE [dbo].[GetAllFacturaDetalle]

AS
	SELECT IdFacturaDetalle,   
           IdFacturaEncabezado,
           IdProducto         ,
           CodigoProducto     ,
           NombreProducto     ,
           Descuento         ,
           Cantidad          
	FROM FacturaDetalle
RETURN 0

GO

CREATE PROCEDURE [dbo].[FacturaDetalleInsert]
    @P_IdFacturaEncabezado  int,
    @P_IdProducto           int,
    @P_CodigoProducto       NVARCHAR (5),
    @P_NombreProducto       NVARCHAR (30),
    @P_Descuento            DECIMAL (18), 
    @P_Cantidad             SMALLINT,
	@Identity int OUT

AS
	INSERT INTO FacturaDetalle(
            IdFacturaEncabezado,
            IdProducto,
            CodigoProducto,
            NombreProducto,
            Descuento,
            Cantidad           
            )
	values(
		@P_IdFacturaEncabezado,
        @P_IdProducto         ,
        @P_CodigoProducto     ,
        @P_NombreProducto     ,
        @P_Descuento          ,
        @P_Cantidad           
	);
	--SELECT SCOPE_IDENTITY()
	SET @Identity = SCOPE_IDENTITY()
GO

CREATE PROCEDURE [dbo].[FacturaDetalleUpdate]
    @P_IdFacturaDetalle		int,
	@P_IdFacturaEncabezado  int,
    @P_IdProducto           int,
    @P_CodigoProducto       NVARCHAR (5),
    @P_NombreProducto       NVARCHAR (30),
    @P_Descuento            DECIMAL (18), 
    @P_Cantidad             SMALLINT
AS

	UPDATE FacturaDetalle 
	SET
		    IdFacturaEncabezado = @P_IdFacturaEncabezado,
            IdProducto          = @P_IdProducto,
            CodigoProducto      = @P_CodigoProducto,
            NombreProducto      = @P_NombreProducto ,
            Descuento           = @P_Descuento,
            Cantidad            = @P_Cantidad   
 WHERE 			  
		IdFacturaDetalle = @P_IdFacturaDetalle

RETURN 0
GO
CREATE PROCEDURE [dbo].[FacturaDetalleDelete]
	@P_IdFacturaDetalle int
	
AS
	DELETE FROM FacturaDetalle WHERE IdFacturaDetalle = @P_IdFacturaDetalle
RETURN 0

GO

CREATE PROCEDURE [dbo].[GetIdFacturaDetalle]
	@P_IdFacturaDetalle int
AS
	SELECT IdFacturaDetalle    , 
           IdFacturaEncabezado ,
           IdProducto          ,
           CodigoProducto      ,
           NombreProducto      ,
           Descuento          ,
           Cantidad           
	FROM FacturaDetalle
	WHERE IdFacturaDetalle = @P_IdFacturaDetalle

RETURN 0

GO

CREATE PROCEDURE [dbo].[GetAllFacturaEncabezado]

AS
	SELECT IdFacturaEncabezado,
        IdCliente,          
        NumeroFactura, 
        CodigoEmpresa,  
        CodigoCliente,  
        Sub_Total, 
        Impuesto,     
        Total,      
        FechaFactura
	FROM FacturaEncabezado
RETURN 0

GO

CREATE PROCEDURE [dbo].[FacturaEncabezadoInsert]
    @P_IdCliente          INT           ,
    @P_NumeroFactura      NVARCHAR (6)  ,
    @P_CodigoEmpresa      NVARCHAR (5)  ,
    @P_CodigoCliente      NVARCHAR (5)  ,
    @P_sub_total          DECIMAL (18)  ,
    @P_impuesto           DECIMAL (18)  ,
    @P_Total              DECIMAL (18)  ,
    @P_fechaFactura       SMALLDATETIME,
	@Identity INT OUT

AS
	INSERT INTO FacturaEncabezado(
            IdCliente,          
            NumeroFactura, 
            CodigoEmpresa,  
            CodigoCliente,  
            Sub_Total, 
            Impuesto,     
            Total,      
            FechaFactura         
            )
	values(
		@P_IdCliente ,    
        @P_NumeroFactura,
        @P_CodigoEmpresa,
        @P_CodigoCliente,
        @P_sub_total,
        @P_impuesto,
        @P_Total,
        @P_fechaFactura         
	);
	--SELECT SCOPE_IDENTITY();
	SET @Identity = SCOPE_IDENTITY()
GO

CREATE PROCEDURE [dbo].[FacturaEncabezadoUpdate]
    @P_IdFacturaEncabezado INT			,
	@P_IdCliente          INT           ,
    @P_NumeroFactura      NVARCHAR (6)  ,
    @P_CodigoEmpresa      NVARCHAR (5)  ,
    @P_CodigoCliente      NVARCHAR (5)  ,
    @P_sub_total          DECIMAL (18)  ,
    @P_impuesto           DECIMAL (18)  ,
    @P_Total              DECIMAL (18)  ,
    @P_fechaFactura       SMALLDATETIME 
AS

	UPDATE FacturaEncabezado 
	SET
		    IdCliente     = @P_IdCliente,          
            NumeroFactura = @P_NumeroFactura, 
            CodigoEmpresa = @P_CodigoEmpresa,  
            CodigoCliente = @P_CodigoCliente,  
            Sub_Total     = @P_sub_total, 
            Impuesto      = @P_impuesto,     
            Total         = @P_Total,      
            FechaFactura  = @P_fechaFactura
 WHERE 			  
		IdFacturaEncabezado = @P_IdFacturaEncabezado

RETURN 0
GO
CREATE PROCEDURE [dbo].[FacturaEncabezadoDelete]
	@P_IdFacturaEncabezado int
	
AS
	DELETE FROM FacturaEncabezado WHERE IdFacturaEncabezado = @P_IdFacturaEncabezado
RETURN 0

GO

CREATE PROCEDURE [dbo].[GetIdFacturaEncabezado]
	@P_IdFacturaEncabezado int
AS
	SELECT IdFacturaEncabezado,
        IdCliente,          
        NumeroFactura, 
        CodigoEmpresa,  
        CodigoCliente,  
        Sub_Total, 
        Impuesto,     
        Total,      
        FechaFactura
	FROM FacturaEncabezado
	WHERE IdFacturaEncabezado = @P_IdFacturaEncabezado

RETURN 0

GO

CREATE PROCEDURE [dbo].[GetAllProducto]

AS
	SELECT 
    IdProducto    ,
    CodigoProducto,
    NombreProducto,
    PrecioUnitario,
    PrecioCosto,
    Stock            ,
    StockMinimo      ,
    FechaIngreso 
	FROM Productos
RETURN 0

GO

CREATE PROCEDURE [dbo].[ProductoInsert]
    @P_IdProducto    INT         ,
    @P_CodigoProducto NVARCHAR (5),
    @P_NombreProducto NVARCHAR (30) ,
    @P_PrecioUnitario DECIMAL (18)  ,
    @P_PrecioCosto    DECIMAL (18)  ,
    @P_Stock          SMALLINT      ,
    @P_StockMinimo    SMALLINT      ,
    @P_FechaIngreso   SMALLDATETIME,
	@Identity INT OUT

AS
	INSERT INTO Productos(
            IdProducto    ,
            CodigoProducto,
            NombreProducto,
            PrecioUnitario,
            PrecioCosto,
            Stock,
            StockMinimo,
            FechaIngreso
            )
	values(
		@P_IdProducto,
    @P_CodigoProducto,
    @P_NombreProducto ,
    @P_PrecioUnitario,
    @P_PrecioCosto   ,
    @P_Stock         ,
    @P_StockMinimo   ,
    @P_FechaIngreso        
	);
RETURN 0

GO

CREATE PROCEDURE [dbo].[ProductoUpdate]
        @P_IdProducto    INT         ,
    @P_CodigoProducto NVARCHAR (5),
    @P_NombreProducto NVARCHAR (30) ,
    @P_PrecioUnitario DECIMAL (18)  ,
    @P_PrecioCosto    DECIMAL (18)  ,
    @P_Stock          SMALLINT      ,
    @P_StockMinimo    SMALLINT      ,
    @P_FechaIngreso   SMALLDATETIME 
AS

	UPDATE Productos
	SET
        CodigoProducto = @P_CodigoProducto,
        NombreProducto = @P_NombreProducto ,
        PrecioUnitario = @P_PrecioUnitario ,
        PrecioCosto    = @P_PrecioCosto    ,
        Stock          = @P_Stock          ,
        StockMinimo    = @P_StockMinimo    ,
       FechaIngreso    = @P_FechaIngreso    
 WHERE 			  	
 	IdProducto = @P_IdProducto

RETURN 0
GO
CREATE PROCEDURE [dbo].[ProductoDelete]
	@P_IdProducto int
	
AS
	DELETE FROM Productos WHERE IdProducto = @P_IdProducto
RETURN 0

GO

CREATE PROCEDURE [dbo].[GetIdProducto]
	@P_IdProducto int
AS
	SELECT     
        IdProducto    ,
        CodigoProducto,
        NombreProducto,
        PrecioUnitario,
        PrecioCosto,
        Stock,
        StockMinimo,
        FechaIngreso
	FROM Productos
	WHERE IdProducto = @P_IdProducto

RETURN 0

GO


CREATE PROCEDURE [dbo].[GetAllUsuario]

AS
	SELECT 
    UserId    ,
    NombreUsuario,
    Clave,
    LogIngresos
	FROM Usuario
RETURN 0

GO

CREATE PROCEDURE [dbo].[UsuarioInsert]
    @P_IdUsuario INT,
    @P_NombreUsuario NCHAR (20) NULL,
    @P_Clave         NCHAR (20) NULL,
    @P_LogIngresos   NCHAR (10) NULL,
	@Identity INT OUT

AS
	INSERT INTO Usuario(
                UserId,
                NombreUsuario,
                Clave,
                LogIngresos
            )
	values(
		@P_IdUsuario,
        @P_NombreUsuario,
        @P_Clave,
        @P_LogIngresos
    );
RETURN 0

GO

CREATE PROCEDURE [dbo].[UsuarioUpdate]
          @P_IdUsuario INT,
          @P_NombreUsuario NCHAR (20) NULL,
          @P_Clave         NCHAR (20) NULL,
          @P_LogIngresos   NCHAR (10) NULL
AS

	UPDATE Usuario 
	SET
        NombreUsuario = @P_NombreUsuario,
        Clave         = @P_Clave,
        LogIngresos   = @P_LogIngresos
 WHERE 			  	
 	UserId = @P_IdUsuario

RETURN 0
GO
CREATE PROCEDURE [dbo].[UsuarioDelete]
	@P_IdUsuario int
	
AS
	DELETE FROM Usuario WHERE UserId = @P_IdUsuario
RETURN 0

GO

CREATE PROCEDURE [dbo].[GetIdUsuario]
	@P_IdUsuario int
AS
	SELECT 
        UserId    ,
        NombreUsuario,
        Clave,
        LogIngresos
	FROM Usuario
	WHERE UserId = @P_IdUsuario

RETURN 0

GO
SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT INTO [dbo].[Usuario] ([userId], [NombreUsuario], [Clave], [LogIngresos]) VALUES (1, N'greg_dorian         ', N'12345               ', NULL)
SET IDENTITY_INSERT [dbo].[Usuario] OFF


--DBCC CHECKIDENT ('FacturaDetalle', RESEED, 0);  
--GO  
--DBCC CHECKIDENT ('FacturaEncabezado', RESEED, 0);  
--GO  