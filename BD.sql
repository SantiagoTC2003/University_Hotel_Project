USE [master]
GO

CREATE DATABASE [HotelProyecto]
GO

USE [HotelProyecto]
GO

CREATE SCHEMA [SCH_CLIENTES]
GO

CREATE SCHEMA [SCH_RESERVACIONES]
GO

CREATE TABLE [SCH_CLIENTES].[CLIENTES](
	[cedula_cliente]		[nvarchar](20) NOT NULL,
	[nombre_cliente]		[nvarchar](50) NOT NULL,
	[apellido1_cliente]		[nvarchar](50) NOT NULL,
	[apellido2_cliente]		[nvarchar](50) NOT NULL,
	[telefono_cliente]		[nvarchar](20) NOT NULL,
	[correo_cliente]		[nvarchar](50) NOT NULL,

	CONSTRAINT [PK_CLIENTES] PRIMARY KEY CLUSTERED
	(
		[cedula_cliente] ASC 	
	)
)
GO

CREATE TABLE [SCH_RESERVACIONES].[HABITACIONES](
	[cod_habitacion]		[smallint] NOT NULL,
	[tipo_habitacion]		[nvarchar](30) NOT NULL,
	[capacidad_habitacion]	[smallint] NOT NULL,
	[estado_habitacion]		[nvarchar](30) NOT NULL,
	
	CONSTRAINT [PK_HABITACIONES] PRIMARY KEY CLUSTERED
	(
		[cod_habitacion] ASC 	
	)
)
GO

CREATE TABLE [SCH_RESERVACIONES].[USUARIOS](
	[ID_USUARIO]			[int] NOT NULL,
	[EMAIL]					[nvarchar](150) NOT NULL,
	[PASS]					[nvarchar](50) NOT NULL,
	[NOMBRE]				[nvarchar](50) NOT NULL,
	[APELLIDOS]				[nvarchar](50) NULL,
	[TIPO]					[nvarchar](15) NULL,
	
	CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED
	(
		[ID_USUARIO] ASC
	)
)
GO

CREATE TABLE [SCH_RESERVACIONES].[RESERVACIONES](
	[id_reserva]			[smallint] NOT NULL,
	[cod_reserva]			[nvarchar](50) NOT NULL,
	[fecha_entrada]			[datetime] NOT NULL,
	[fecha_salida]			[datetime] NOT NULL,
	[cantidad_adultos]		[smallint] NOT NULL,
	[cantidad_ninos]		[smallint] NOT NULL,
	[cedula_cliente]		[nvarchar](20) NOT NULL,
	[cod_habitacion]		[smallint] NOT NULL,
	[precio_habitacion]		[smallmoney] NOT NULL,
	[ID_USUARIO]			[int] NULL,
	
	CONSTRAINT [PK_RESERVACIONES] PRIMARY KEY CLUSTERED
	(
		[id_reserva] ASC 	
	)
)
GO

ALTER TABLE [SCH_RESERVACIONES].[RESERVACIONES] WITH NOCHECK
	ADD CONSTRAINT [FK_RESERVACIONES_HABITACIONES] FOREIGN KEY ([cod_habitacion])
	REFERENCES [SCH_RESERVACIONES].[HABITACIONES]([cod_habitacion])
GO

ALTER TABLE [SCH_RESERVACIONES].[RESERVACIONES] WITH NOCHECK
	ADD CONSTRAINT [FK_RESERVACIONES_CLIENTES] FOREIGN KEY ([cedula_cliente])
	REFERENCES [SCH_CLIENTES].[CLIENTES]([cedula_cliente])
GO



-- STORED PROCEDURES

CREATE PROCEDURE [SCH_RESERVACIONES].[SP_AGREGARUSUARIO]
	@IDUsuario		int,
	@Email			nvarchar(150),
	@Pass			nvarchar(50),
	@Nombre			nvarchar(50),
	@Apellidos		nvarchar(50),
	@Tipo			nvarchar(15)
AS
BEGIN
	INSERT INTO [SCH_RESERVACIONES].[USUARIOS]
		([ID_USUARIO], 
		[EMAIL], 
		[PASS], 
		[NOMBRE], 
		[APELLIDOS], 
		[TIPO])
	VALUES
		(@IDUsuario,
		@Email,
		@Pass,
		@Nombre, 
		@Apellidos,
		@Tipo)
END