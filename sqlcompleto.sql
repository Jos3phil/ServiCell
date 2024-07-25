USE [master]
GO
/****** Object:  Database [SERVICELL]    Script Date: 23/07/2024 02:28:51 p. m. ******/
CREATE DATABASE [SERVICELL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SERVICELL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SERVICELL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SERVICELL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\SERVICELL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SERVICELL] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SERVICELL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SERVICELL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SERVICELL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SERVICELL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SERVICELL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SERVICELL] SET ARITHABORT OFF 
GO
ALTER DATABASE [SERVICELL] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SERVICELL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SERVICELL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SERVICELL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SERVICELL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SERVICELL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SERVICELL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SERVICELL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SERVICELL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SERVICELL] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SERVICELL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SERVICELL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SERVICELL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SERVICELL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SERVICELL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SERVICELL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SERVICELL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SERVICELL] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SERVICELL] SET  MULTI_USER 
GO
ALTER DATABASE [SERVICELL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SERVICELL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SERVICELL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SERVICELL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SERVICELL] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SERVICELL] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SERVICELL] SET QUERY_STORE = OFF
GO
USE [SERVICELL]
GO
/****** Object:  Table [dbo].[Categoría]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoría](
	[IdCategoría] [varchar](6) NOT NULL,
	[Descripción] [varchar](100) NULL,
	[FechaRegistro] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoría] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [varchar](6) NOT NULL,
	[DNI] [varchar](8) NULL,
	[Nombre] [varchar](64) NULL,
	[Correo] [varchar](255) NULL,
	[Teléfono] [varchar](20) NULL,
	[Estado] [bit] NOT NULL,
	[FechaRegistro] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[IdCompra] [varchar](6) NOT NULL,
	[IdEmpleado] [varchar](6) NULL,
	[IdProveedor] [varchar](6) NULL,
	[TipoDocumento] [varchar](20) NULL,
	[NumeroDocumento] [varchar](20) NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaRegistro] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Compra]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Compra](
	[IdDetalleCompra] [varchar](6) NOT NULL,
	[IdCompra] [varchar](6) NULL,
	[IdRepuesto] [varchar](6) NULL,
	[PrecioCompra] [decimal](10, 2) NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Cantidad] [int] NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaIngreso] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleCompra] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Venta]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Venta](
	[IdDetalleVenta] [varchar](6) NOT NULL,
	[IdVenta] [varchar](6) NULL,
	[IdRepuesto] [varchar](6) NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[Cantidad] [int] NULL,
	[SubTotal] [decimal](10, 2) NULL,
	[FechaIngreso] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [varchar](6) NOT NULL,
	[Nombre] [varchar](64) NULL,
	[DNI] [varchar](8) NULL,
	[Correo] [varchar](255) NULL,
	[Teléfono] [varchar](20) NULL,
	[IdRol] [varchar](6) NULL,
	[NombreUsuario] [varchar](20) NULL,
	[Contraseña] [varchar](50) NULL,
	[FechaRegistro] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[IdMarca] [varchar](6) NOT NULL,
	[Nombre] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdMarca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [varchar](6) NOT NULL,
	[Nombre] [varchar](255) NULL,
	[Teléfono] [varchar](20) NULL,
	[Estado] [bit] NOT NULL,
	[FechaIngreso] [date] NULL,
	[NumeroProveedor] [varchar](20) NULL,
	[RazonSocial] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Repuesto]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Repuesto](
	[IdRepuesto] [varchar](6) NOT NULL,
	[IdMarca] [varchar](6) NULL,
	[Modelo] [varchar](30) NULL,
	[IdCategoría] [varchar](6) NULL,
	[Color] [varchar](20) NULL,
	[Stock] [int] NULL,
	[PrecioCompra] [decimal](10, 2) NULL,
	[PrecioVenta] [decimal](10, 2) NULL,
	[FechaRegistro] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRepuesto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [varchar](6) NOT NULL,
	[Descripción] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[NombreUsuario] [varchar](20) NULL,
	[Contraseña] [varchar](50) NULL,
	[IdEmpleado] [varchar](6) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [varchar](6) NOT NULL,
	[IdEmpleado] [varchar](6) NULL,
	[TipoDocumento] [varchar](20) NULL,
	[NumeroDocumento] [varchar](50) NULL,
	[IdCliente] [varchar](6) NULL,
	[MontoPago] [decimal](10, 2) NULL,
	[MontoCambio] [decimal](10, 2) NULL,
	[MontoTotal] [decimal](10, 2) NULL,
	[FechaIngreso] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Categoría] ([IdCategoría], [Descripción], [FechaRegistro]) VALUES (N'C00001', N'Pantalla', CAST(N'2024-07-23' AS Date))
INSERT [dbo].[Categoría] ([IdCategoría], [Descripción], [FechaRegistro]) VALUES (N'C00002', N'Bateria', CAST(N'2024-07-23' AS Date))
INSERT [dbo].[Categoría] ([IdCategoría], [Descripción], [FechaRegistro]) VALUES (N'C00003', N'Flex de Carga', CAST(N'2024-07-23' AS Date))
INSERT [dbo].[Categoría] ([IdCategoría], [Descripción], [FechaRegistro]) VALUES (N'C00004', N'Tapa', CAST(N'2024-07-23' AS Date))
INSERT [dbo].[Categoría] ([IdCategoría], [Descripción], [FechaRegistro]) VALUES (N'C00005', N'Lente de camara', CAST(N'2024-07-23' AS Date))
GO
INSERT [dbo].[Empleado] ([IdEmpleado], [Nombre], [DNI], [Correo], [Teléfono], [IdRol], [NombreUsuario], [Contraseña], [FechaRegistro]) VALUES (N'E00002', N'Loco Pérez', N'20202020', N'juan.pepito@example.com', N'555-1234', N'R00001', N'admin', N'!#/)zW¥§C‰JJ€Ã', CAST(N'2024-07-19' AS Date))
INSERT [dbo].[Empleado] ([IdEmpleado], [Nombre], [DNI], [Correo], [Teléfono], [IdRol], [NombreUsuario], [Contraseña], [FechaRegistro]) VALUES (N'E00003', N'Loco Pérez', N'12345678', N'juan.pepito@gmail.com', N'555-1234', N'R00001', N'admin1', N'admin1', CAST(N'2024-07-19' AS Date))
GO
INSERT [dbo].[Marca] ([IdMarca], [Nombre]) VALUES (N'M00001', N'Samsung')
INSERT [dbo].[Marca] ([IdMarca], [Nombre]) VALUES (N'M00002', N'Huawei')
INSERT [dbo].[Marca] ([IdMarca], [Nombre]) VALUES (N'M00003', N'Xiaomi')
INSERT [dbo].[Marca] ([IdMarca], [Nombre]) VALUES (N'M00004', N'Motorola')
GO
INSERT [dbo].[Rol] ([IdRol], [Descripción]) VALUES (N'R00001', N'Este es el empleado')
GO
INSERT [dbo].[Usuario] ([NombreUsuario], [Contraseña], [IdEmpleado]) VALUES (N'admin', N'!#/)zW¥§C‰JJ€Ã', N'E00002')
INSERT [dbo].[Usuario] ([NombreUsuario], [Contraseña], [IdEmpleado]) VALUES (N'admin1', N'admin1', N'E00003')
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[Detalle_Compra]  WITH CHECK ADD FOREIGN KEY([IdCompra])
REFERENCES [dbo].[Compra] ([IdCompra])
GO
ALTER TABLE [dbo].[Detalle_Compra]  WITH CHECK ADD FOREIGN KEY([IdRepuesto])
REFERENCES [dbo].[Repuesto] ([IdRepuesto])
GO
ALTER TABLE [dbo].[Detalle_Venta]  WITH CHECK ADD FOREIGN KEY([IdRepuesto])
REFERENCES [dbo].[Repuesto] ([IdRepuesto])
GO
ALTER TABLE [dbo].[Detalle_Venta]  WITH CHECK ADD FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Repuesto]  WITH CHECK ADD FOREIGN KEY([IdCategoría])
REFERENCES [dbo].[Categoría] ([IdCategoría])
GO
ALTER TABLE [dbo].[Repuesto]  WITH CHECK ADD FOREIGN KEY([IdMarca])
REFERENCES [dbo].[Marca] ([IdMarca])
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
/****** Object:  StoredProcedure [dbo].[InsertarEmpleado]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarEmpleado]
    @IdEmpleado VARCHAR(6),
    @Nombre VARCHAR(64),
    @DNI VARCHAR(8),
    @Correo VARCHAR(255),
    @Teléfono VARCHAR(20),
    @IdRol VARCHAR(6),
    @NombreUsuario VARCHAR(255),
    @Contraseña VARCHAR(50),
    @FechaRegistro DATE
AS
BEGIN
    DECLARE @Count INT;

    -- Verifica si el empleado ya existe por IdEmpleado, DNI o Correo
    SELECT @Count = COUNT(*)
    FROM Empleado
    WHERE IdEmpleado = @IdEmpleado
       OR DNI = @DNI
       OR Correo = @Correo;

    IF @Count = 0
    BEGIN
        -- Si no existe, inserta el nuevo empleado
        INSERT INTO Empleado (IdEmpleado, Nombre, DNI, Correo, Teléfono, IdRol,NombreUsuario,Contraseña, FechaRegistro)
        VALUES (@IdEmpleado, @Nombre, @DNI, @Correo, @Teléfono, @IdRol,@NombreUsuario,@Contraseña, @FechaRegistro);

        -- Inserta en la tabla Credenciales
        INSERT INTO Usuario(NombreUsuario, Contraseña, IdEmpleado)
        VALUES (@NombreUsuario,@Contraseña, @IdEmpleado);

        -- Retorna mensaje de éxito
        select CodError=0,Mensaje= 'Registro correcto';
    END
    ELSE
    BEGIN
        -- Si ya existe, retorna mensaje de error
        select CodError=1,Mensaje= 'Error en almacenar';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[uspListarCategorias]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspListarCategorias]
AS
BEGIN
    SELECT IdCategoría, Descripción, FechaRegistro FROM Categoría;
END
GO
/****** Object:  StoredProcedure [dbo].[ValidarUsuarioContrasena]    Script Date: 23/07/2024 02:28:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ValidarUsuarioContrasena]
    @NombreUsuario VARCHAR(20),
    @Contrasena VARCHAR(50)
AS
BEGIN
    DECLARE @Count INT;

    -- Contar cuántos usuarios existen con el IdUsuario y Contraseña dados
    SELECT @Count = COUNT(*)
    FROM Usuario
    WHERE NombreUsuario = @NombreUsuario
      AND Contraseña = @Contrasena;

    -- Devolver el resultado
    IF @Count > 0
    BEGIN
        select CodError=0,Mensaje= 'Bienvenido'; -- El usuario y la contraseña son válidos
    END
    ELSE
    BEGIN
        select CodError=1,Mensaje= 'error en almacenar'; -- El usuario o la contraseña no son válidos
    END
END;
GO
USE [master]
GO
ALTER DATABASE [SERVICELL] SET  READ_WRITE 
GO
