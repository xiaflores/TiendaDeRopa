USE [master]
GO
/****** Object:  Database [Tienda_de_Ropa]    Script Date: 10/12/2018 7:00:40 ******/
CREATE DATABASE [Tienda_de_Ropa]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Tienda_de_Ropa', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Tienda_de_Ropa.mdf' , SIZE = 22528KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Tienda_de_Ropa_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Tienda_de_Ropa_log.ldf' , SIZE = 63424KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Tienda_de_Ropa] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Tienda_de_Ropa].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Tienda_de_Ropa] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET ARITHABORT OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Tienda_de_Ropa] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Tienda_de_Ropa] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Tienda_de_Ropa] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Tienda_de_Ropa] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Tienda_de_Ropa] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET RECOVERY FULL 
GO
ALTER DATABASE [Tienda_de_Ropa] SET  MULTI_USER 
GO
ALTER DATABASE [Tienda_de_Ropa] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Tienda_de_Ropa] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Tienda_de_Ropa] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Tienda_de_Ropa] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Tienda_de_Ropa]
GO
/****** Object:  StoredProcedure [dbo].[reporte_factura]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[reporte_factura]
@idvena int
as
select v.idventa,(t.apellidos+' '+t.nombre) as Trabajador,
(c.apellidos+' '+c.nombre) as Cliente,
c.documento_cliente,v.fecha,v.factura,p.nombre,p.marca,p.talla,p.descripcion,dv.precio_venta,dv.cantidad,(dv.cantidad*dv.precio_venta) as Total
from detalle_venta dv inner join detalle_ingreso di
on dv.iddetalle_ingreso=di.iddetalle_ingreso inner join
prenda p on p.idprenda=di.idprenda inner join venta v
on v.idventa=dv.idventa
inner join cliente c
on v.idcliente=c.idcliente
inner join trabajador t
on t.idtrabajador=v.idtrabajador
where v.idventa=@idvena
GO
/****** Object:  StoredProcedure [dbo].[spbuscar__proveedor_num_documento]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscar__proveedor_num_documento]
@textobuscar varchar(50)
as
select * from proveedor
where documento_proveedor like @textobuscar+'%'

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_cliente_num]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscar_cliente_num]
@textobuscar varchar(20)
as
select *from cliente
where documento_cliente like @textobuscar+'%'

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_prenda]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscar_prenda]
@textobuscar varchar(50)
as
select *
from prenda
where prenda.nombre like @textobuscar + '%'
order by idprenda

GO
/****** Object:  StoredProcedure [dbo].[spbuscar_trabajador_num]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscar_trabajador_num]
@textobuscar varchar(50)
as 
select * from trabajador
where documento_trabajador like +'%'
order by apellidos asc

GO
/****** Object:  StoredProcedure [dbo].[spbuscarprenda_venta_nombre]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spbuscarprenda_venta_nombre]
@textobuscar varchar(50)
as
select d.iddetalle_ingreso,p.nombre,p.marca,
d.stock_actual,d.precio_compra,d.precio_venta
from prenda p inner join detalle_ingreso d on
p.idprenda=d.idprenda inner join  ingreso i
on d.idingreso=i.idingreso
where p.nombre like @textobuscar+'%' and d.stock_actual>0

GO
/****** Object:  StoredProcedure [dbo].[spdisminuir_stock]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spdisminuir_stock]
@iddetalle_ingreso int,
@cantidad int
as
update detalle_ingreso set stock_actual=stock_actual-@cantidad
where iddetalle_ingreso=@iddetalle_ingreso

GO
/****** Object:  StoredProcedure [dbo].[speditar_cliente]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speditar_cliente]
@idcliente int output,
@documento_cliente varchar(15),
@nombre varchar(20),
@apellidos varchar(50),
@sexo varchar(1)
as
update cliente set documento_cliente=@documento_cliente,nombre=@nombre,apellidos=@apellidos,sexo=@sexo
where idcliente=@idcliente

GO
/****** Object:  StoredProcedure [dbo].[speditar_prenda]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speditar_prenda]
@idprenda int,
@nombre varchar(50),
@marca varchar(20),
@talla varchar(5),
@descripcion varchar(50),
@imagen image
as
update prenda set nombre=@nombre,marca=@marca,talla=@talla,descripcion=@descripcion,imagen=@imagen
where idprenda=@idprenda

GO
/****** Object:  StoredProcedure [dbo].[speditar_proveedor]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speditar_proveedor]
@idproveedor int,
@documento_proveedor varchar(15),
@nombre varchar(50),
@direccion varchar(100),
@telefono varchar(15),
@email varchar(50)
as
update proveedor set documento_proveedor=@documento_proveedor,nombre=@nombre,direccion=@direccion,telefono=@telefono,email=@email
where idproveedor=@idproveedor
GO
/****** Object:  StoredProcedure [dbo].[speditar_trabajador]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speditar_trabajador]
@idtrabajador int,
@documento_trabajador varchar(15),
@nombre varchar(20),
@apellidos varchar(50),
@direccion varchar(200),
@sexo varchar(1),
@fecha_nacimiento date,
@telefono varchar(15),
@email varchar(50),
@acceso varchar(50),
@usuario varchar(50),
@password varchar(50),
@fotografia image
as
update trabajador set documento_trabajador=@documento_trabajador, nombre=@nombre,apellidos=@apellidos,direccion=@direccion,sexo=@sexo,fecha_nacimiento=@fecha_nacimiento,telefono=@telefono,email=@email,acceso=@acceso,usuario=@usuario,password=@password,fotografia=@fotografia
where idtrabajador=@idtrabajador

GO
/****** Object:  StoredProcedure [dbo].[speliminar_cliente]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speliminar_cliente]

@idcliente int
as
delete from cliente
where idcliente=@idcliente

GO
/****** Object:  StoredProcedure [dbo].[speliminar_prenda]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speliminar_prenda]
@idprenda int
as
delete from prenda
where idprenda=@idprenda

GO
/****** Object:  StoredProcedure [dbo].[speliminar_proveedor]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speliminar_proveedor]
@idproveedor varchar(15)
as
delete from proveedor
where idproveedor=@idproveedor

GO
/****** Object:  StoredProcedure [dbo].[speliminar_trabajador]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speliminar_trabajador]
@idtrabajador int 
as
delete from trabajador
where idtrabajador=@idtrabajador

GO
/****** Object:  StoredProcedure [dbo].[speliminar_venta]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[speliminar_venta]
@idventa int 
as delete from venta
where idventa=@idventa

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_cliente]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_cliente]
@idcliente int output,
@documento_cliente varchar(15),
@nombre varchar(20),
@apellidos varchar(50),
@sexo varchar(1)
as
insert into cliente(documento_cliente,nombre,apellidos,sexo)
values (@documento_cliente,@nombre,@apellidos,@sexo)

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_detalle_ingreso]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_detalle_ingreso]
@iddetalle_ingreso int output,
@idingreso int,
@idprenda int,
@precio_compra money,
@precio_venta money,
@stock_inicial int,
@stock_actual int
as 
insert into detalle_ingreso(idingreso,idprenda,precio_compra,precio_venta,stock_inicial,stock_actual)
values (@idingreso,@idprenda,@precio_compra,@precio_venta,@stock_inicial,@stock_actual)

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_detalle_venta]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_detalle_venta]
@iddetalle_venta int output,
@idventa int,
@iddetalle_ingreso int,
@cantidad int,
@precio_venta money
as
insert into detalle_venta(idventa,iddetalle_ingreso,cantidad,precio_venta)
values (@idventa,@iddetalle_ingreso,@cantidad,@precio_venta)

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_ingreso]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_ingreso]
@idingreso int=null output,
@idtrabajador int,
@idproveedor int,
@tipo_comprobante varchar(20),
@num_comprobante varchar(15)
as
insert into ingreso(idproveedor,idtrabajador,tipo_comprobante,num_comprobante)
values (@idproveedor,@idtrabajador,@tipo_comprobante,@num_comprobante)
set @idingreso=@@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_prenda]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_prenda]
@idprenda int output,
@nombre varchar(50),
@marca varchar(20),
@talla varchar(5),
@descripcion varchar(50),
@imagen image
as
insert into prenda(nombre,marca,talla,descripcion,imagen)
values (@nombre,@marca,@talla,@descripcion,@imagen)

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_proveedor]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_proveedor]
@idproveedor int output,
@documento_proveedor varchar(15),
@nombre varchar(50),
@direccion varchar(100),
@telefono varchar(15),
@email varchar(50)
as
insert into proveedor(documento_proveedor,nombre,direccion,telefono,email)
values (@documento_proveedor,@nombre,@direccion,@telefono,@email)

GO
/****** Object:  StoredProcedure [dbo].[spinsertar_venta]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsertar_venta]
@idventa int =null output,
@idcliente int,
@idtrabajador int,
@fecha date,
@factura varchar(15)
as
insert into venta (idcliente,idtrabajador,fecha,factura)
values (@idcliente,@idtrabajador,@fecha,@factura)
set @idventa=@@IDENTITY

GO
/****** Object:  StoredProcedure [dbo].[spinsetar_trabajador]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spinsetar_trabajador]
@idtrabajador int output,
@documento_trabajador varchar(15),
@nombre varchar(20),
@apellidos varchar(50),
@direccion varchar(200),
@sexo varchar(1),
@fecha_nacimiento date,
@telefono varchar(15),
@email varchar(50),
@acceso varchar(50),
@usuario varchar(50),
@password varchar(50),
@fotografia image
as
insert into trabajador(documento_trabajador,nombre,apellidos,direccion,sexo,fecha_nacimiento,telefono,email,acceso,usuario,password,fotografia)
values (@documento_trabajador,@nombre,@apellidos,@direccion,@sexo,@fecha_nacimiento,@telefono,@email,@acceso,@usuario,@password,@fotografia)
GO
/****** Object:  StoredProcedure [dbo].[splogin]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[splogin]
@usuario varchar (50),
@password varchar(50)
as
select idtrabajador,apellidos,nombre,acceso,fotografia
from trabajador
where usuario=@usuario and password=@password
GO
/****** Object:  StoredProcedure [dbo].[spmostar_detalle_ingreso]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostar_detalle_ingreso]
@textobuscar int
as
select d.idprenda,p.nombre as Prenda,d.precio_compra,
d.precio_venta,d.stock_inicial,(d.stock_inicial*d.precio_compra) as Subtotal
from detalle_ingreso d inner join prenda p
on d.idprenda=p.idprenda
where d.idingreso=@textobuscar

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_cliente]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_cliente]
as 
select * from cliente
order by apellidos asc

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_detalle_venta]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_detalle_venta]
@textobuscar int 
as
select d.iddetalle_ingreso,p.nombre as prenda,
d.cantidad,d.precio_venta,(d.precio_venta*d.cantidad) as Subtital
from detalle_venta d inner join detalle_ingreso di 
on d.iddetalle_ingreso=di.iddetalle_ingreso inner join
 prenda p on p.idprenda=di.idprenda
 where d.idventa=@textobuscar

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_ingreso]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_ingreso]
as
select i.idingreso,(t.apellidos+' '+t.nombre) as trabajdor,
p.nombre as proveedor,i.tipo_comprobante,i.num_comprobante,sum(d.precio_compra*d.stock_inicial) as Total
from detalle_ingreso d inner join ingreso i on d.idingreso=i.idingreso inner join proveedor p on i.idproveedor=p.idproveedor inner join trabajador t on i.idtrabajador=t.idtrabajador
group by i.idingreso,t.apellidos+' '+t.nombre,
p.nombre,i.tipo_comprobante,i.num_comprobante
order by i.idingreso desc

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_prenda]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--mostrar
CREATE proc [dbo].[spmostrar_prenda]
as
select *
from prenda
order by idprenda

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_proveedor]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_proveedor]
as
select * from proveedor
order by nombre asc

GO
/****** Object:  StoredProcedure [dbo].[spmostrar_trabajador]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--MSOTARR
CREATE proc [dbo].[spmostrar_trabajador]
as
select * from trabajador


GO
/****** Object:  StoredProcedure [dbo].[spmostrar_venta]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[spmostrar_venta]
as
select top 100 v.idventa,
(t.apellidos+' '+t.nombre) as trabajador,
(c.apellidos+' '+ c.nombre) as cliente,
v.fecha,v.factura,
sum (d.cantidad*d.precio_venta) as total
from detalle_venta d inner join venta v on d.idventa=v.idventa
inner join cliente c on v.idcliente=c.idcliente inner join trabajador t 
on v.idtrabajador=t.idtrabajador
group by v.idventa,(t.apellidos+' '+t.nombre),(c.apellidos+' '+ c.nombre),v.fecha,factura
order by v.idventa desc
GO
/****** Object:  StoredProcedure [dbo].[SpmostrarPrendas]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SpmostrarPrendas]
as
SELECT  dbo.prenda.idprenda,dbo.prenda.nombre, dbo.prenda.marca, dbo.prenda.descripcion, dbo.prenda.talla,
 Sum(dbo.detalle_ingreso.stock_inicial) as Cantidad_Ingresos,
 Sum( dbo.detalle_ingreso.stock_actual) as Cantidad_Disponible,
 (Sum(dbo.detalle_ingreso.stock_inicial)-
 Sum( dbo.detalle_ingreso.stock_actual)) as Cantidad_Vendido
FROM            dbo.detalle_ingreso INNER JOIN
                         dbo.ingreso ON dbo.detalle_ingreso.idingreso = dbo.ingreso.idingreso INNER JOIN
                         dbo.prenda ON dbo.detalle_ingreso.idprenda = dbo.prenda.idprenda
group by dbo.prenda.idprenda,dbo.prenda.nombre, dbo.prenda.marca, dbo.prenda.descripcion, dbo.prenda.talla

GO
/****** Object:  StoredProcedure [dbo].[spRecuperar_Contasenia]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spRecuperar_Contasenia]
@documento_trabajdor int
as
select * 
from trabajador
where documento_trabajador=@documento_trabajdor
GO
/****** Object:  StoredProcedure [dbo].[spRecuperar_Contrasenia]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spRecuperar_Contrasenia]
@documento_trabajdor int
as
select * 
from trabajador
where documento_trabajador=@documento_trabajdor
GO
/****** Object:  Table [dbo].[cliente]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cliente](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[Documento_Cliente] [varchar](15) NOT NULL,
	[Nombre] [varchar](20) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Sexo] [varchar](1) NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detalle_ingreso]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_ingreso](
	[iddetalle_ingreso] [int] IDENTITY(1,1) NOT NULL,
	[idingreso] [int] NOT NULL,
	[idprenda] [int] NOT NULL,
	[precio_compra] [money] NOT NULL,
	[precio_venta] [money] NULL,
	[stock_inicial] [int] NULL,
	[stock_actual] [int] NULL,
 CONSTRAINT [PK_detalle_ingreso] PRIMARY KEY CLUSTERED 
(
	[iddetalle_ingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[detalle_venta]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalle_venta](
	[iddetalle_venta] [int] IDENTITY(1,1) NOT NULL,
	[idventa] [int] NOT NULL,
	[iddetalle_ingreso] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[precio_venta] [money] NOT NULL,
 CONSTRAINT [PK_detalle_venta] PRIMARY KEY CLUSTERED 
(
	[iddetalle_venta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ingreso]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ingreso](
	[idingreso] [int] IDENTITY(1,1) NOT NULL,
	[idproveedor] [int] NULL,
	[idtrabajador] [int] NOT NULL,
	[tipo_comprobante] [varchar](20) NOT NULL,
	[num_comprobante] [varchar](15) NOT NULL,
 CONSTRAINT [PK_ingreso] PRIMARY KEY CLUSTERED 
(
	[idingreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[prenda]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[prenda](
	[idprenda] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[marca] [varchar](20) NULL,
	[talla] [varchar](5) NULL,
	[descripcion] [varchar](50) NULL,
	[imagen] [image] NULL,
 CONSTRAINT [PK_prenda] PRIMARY KEY CLUSTERED 
(
	[idprenda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[proveedor]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[proveedor](
	[idproveedor] [int] IDENTITY(1,1) NOT NULL,
	[documento_proveedor] [varchar](15) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](15) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_proveedor] PRIMARY KEY CLUSTERED 
(
	[idproveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[trabajador]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[trabajador](
	[idtrabajador] [int] IDENTITY(1,1) NOT NULL,
	[documento_trabajador] [varchar](15) NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[apellidos] [varchar](30) NOT NULL,
	[direccion] [varchar](100) NOT NULL,
	[sexo] [varchar](1) NULL,
	[fecha_nacimiento] [date] NULL,
	[telefono] [varchar](15) NULL,
	[email] [varchar](30) NULL,
	[acceso] [varchar](50) NOT NULL,
	[usuario] [varchar](15) NOT NULL,
	[password] [varchar](20) NOT NULL,
	[fotografia] [image] NULL,
 CONSTRAINT [PK_trabajdor] PRIMARY KEY CLUSTERED 
(
	[idtrabajador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[venta]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[venta](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[idcliente] [int] NOT NULL,
	[idtrabajador] [int] NOT NULL,
	[fecha] [date] NOT NULL,
	[factura] [varchar](50) NOT NULL,
 CONSTRAINT [PK_venta] PRIMARY KEY CLUSTERED 
(
	[idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[View_1]    Script Date: 10/12/2018 7:00:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_1]
AS
SELECT        dbo.prenda.nombre, dbo.detalle_ingreso.stock_inicial, dbo.prenda.marca, dbo.prenda.idprenda, dbo.prenda.color, dbo.prenda.talla, dbo.detalle_ingreso.stock_actual
FROM            dbo.detalle_ingreso INNER JOIN
                         dbo.ingreso ON dbo.detalle_ingreso.idingreso = dbo.ingreso.idingreso INNER JOIN
                         dbo.prenda ON dbo.detalle_ingreso.idprenda = dbo.prenda.idprenda

GO
ALTER TABLE [dbo].[detalle_ingreso]  WITH CHECK ADD  CONSTRAINT [FK_detalle_ingreso_ingreso] FOREIGN KEY([idingreso])
REFERENCES [dbo].[ingreso] ([idingreso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_ingreso] CHECK CONSTRAINT [FK_detalle_ingreso_ingreso]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_detalle_ingreso] FOREIGN KEY([iddetalle_ingreso])
REFERENCES [dbo].[detalle_ingreso] ([iddetalle_ingreso])
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_detalle_ingreso]
GO
ALTER TABLE [dbo].[detalle_venta]  WITH CHECK ADD  CONSTRAINT [FK_detalle_venta_venta] FOREIGN KEY([idventa])
REFERENCES [dbo].[venta] ([idventa])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[detalle_venta] CHECK CONSTRAINT [FK_detalle_venta_venta]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_proveedor] FOREIGN KEY([idproveedor])
REFERENCES [dbo].[proveedor] ([idproveedor])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_proveedor]
GO
ALTER TABLE [dbo].[ingreso]  WITH CHECK ADD  CONSTRAINT [FK_ingreso_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[ingreso] CHECK CONSTRAINT [FK_ingreso_trabajador]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[cliente] ([idcliente])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_cliente]
GO
ALTER TABLE [dbo].[venta]  WITH CHECK ADD  CONSTRAINT [FK_venta_trabajador] FOREIGN KEY([idtrabajador])
REFERENCES [dbo].[trabajador] ([idtrabajador])
GO
ALTER TABLE [dbo].[venta] CHECK CONSTRAINT [FK_venta_trabajador]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "detalle_ingreso"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 177
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "ingreso"
            Begin Extent = 
               Top = 39
               Left = 289
               Bottom = 169
               Right = 498
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "prenda"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 400
               Right = 247
            End
            DisplayFlags = 280
            TopColumn = 2
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_1'
GO
USE [master]
GO
ALTER DATABASE [Tienda_de_Ropa] SET  READ_WRITE 
GO
