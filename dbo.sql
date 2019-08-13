/*
 Navicat Premium Data Transfer

 Source Server         : test
 Source Server Type    : SQL Server
 Source Server Version : 11003128
 Source Host           : DESKTOP-I12PK7K\SERVER:1433
 Source Catalog        : PedidosMetatecnics
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 11003128
 File Encoding         : 65001

 Date: 27/03/2019 11:08:07
*/


-- ----------------------------
-- Table structure for MiniPedido
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[MiniPedido]') AND type IN ('U'))
	DROP TABLE [dbo].[MiniPedido]
GO

CREATE TABLE [dbo].[MiniPedido] (
  [ID_MiniPedido] int  IDENTITY(1,1) NOT NULL,
  [Fecha] datetime  NULL,
  [Referencia] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Objeto] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Direct] bit  NULL,
  [Finalizado] int DEFAULT ((0)) NULL,
  [Modelo] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [ArchivoCliente] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [NumColores] int  NULL,
  [Cantidad] bigint  NULL,
  [FechaActualizacion] varchar(23) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [ArchivoDiseno] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Articulo] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Previsualizacion] varchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [DoneDiseno] bit DEFAULT ((0)) NULL,
  [DoneAlmacen] bit DEFAULT ((0)) NULL,
  [DoneProduccion] bit DEFAULT ((0)) NULL,
  [NumCajas] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Palet] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [FechaEnvioCliente] datetime  NULL,
  [PrePalet] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[MiniPedido] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of MiniPedido
-- ----------------------------
SET IDENTITY_INSERT [dbo].[MiniPedido] ON
GO

INSERT INTO [dbo].[MiniPedido] ([ID_MiniPedido], [Fecha], [Referencia], [Objeto], [Direct], [Finalizado], [Modelo], [ArchivoCliente], [NumColores], [Cantidad], [FechaActualizacion], [ArchivoDiseno], [Articulo], [Previsualizacion], [DoneDiseno], [DoneAlmacen], [DoneProduccion], [NumCajas], [Palet], [FechaEnvioCliente], [PrePalet]) VALUES (N'3316', N'2019-04-01 00:00:00.000', N'97857', NULL, N'1', N'0', N'ECO 18  (10/12/15cl)', N'visuel-eco-18-10-12-15cl-194855.ai', N'1', N'1200', N'2019-03-27 12:42:02.566', NULL, N'Translucide Givré', NULL, N'0', N'0', N'0', NULL, NULL, N'2019-03-27 00:42:02.000', NULL)
GO

INSERT INTO [dbo].[MiniPedido] ([ID_MiniPedido], [Fecha], [Referencia], [Objeto], [Direct], [Finalizado], [Modelo], [ArchivoCliente], [NumColores], [Cantidad], [FechaActualizacion], [ArchivoDiseno], [Articulo], [Previsualizacion], [DoneDiseno], [DoneAlmacen], [DoneProduccion], [NumCajas], [Palet], [FechaEnvioCliente], [PrePalet]) VALUES (N'3317', N'2019-04-01 00:00:00.000', N'97857', NULL, N'1', N'0', N'ECO 18  (10/12/15cl)', N'visuel-eco-18-10-12-15cl-194857.ai', N'1', N'3900', N'2019-03-27 12:42:02.569', NULL, N'Translucide Givré', NULL, N'0', N'0', N'0', NULL, NULL, N'2019-03-27 00:42:02.000', NULL)
GO

INSERT INTO [dbo].[MiniPedido] ([ID_MiniPedido], [Fecha], [Referencia], [Objeto], [Direct], [Finalizado], [Modelo], [ArchivoCliente], [NumColores], [Cantidad], [FechaActualizacion], [ArchivoDiseno], [Articulo], [Previsualizacion], [DoneDiseno], [DoneAlmacen], [DoneProduccion], [NumCajas], [Palet], [FechaEnvioCliente], [PrePalet]) VALUES (N'3318', N'2017-08-07 00:00:00.000', N'ECOCUP67844', NULL, N'1', N'0', N'ECO 30 (25/30cl)', N'visuel-eco-30-25-30cl-126998.ai', N'1', N'500', N'2019-03-27 12:42:02.593', NULL, N'Translucide Givré', NULL, N'0', N'0', N'0', NULL, NULL, N'2019-03-27 00:42:02.000', NULL)
GO

SET IDENTITY_INSERT [dbo].[MiniPedido] OFF
GO


-- ----------------------------
-- Table structure for MiniPedidoColores
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[MiniPedidoColores]') AND type IN ('U'))
	DROP TABLE [dbo].[MiniPedidoColores]
GO

CREATE TABLE [dbo].[MiniPedidoColores] (
  [ID_Colores] int  IDENTITY(1,1) NOT NULL,
  [ID_MiniPedido] int  NULL,
  [Color] varchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [FechaActualizacion] varchar(23) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[MiniPedidoColores] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of MiniPedidoColores
-- ----------------------------
SET IDENTITY_INSERT [dbo].[MiniPedidoColores] ON
GO

INSERT INTO [dbo].[MiniPedidoColores] ([ID_Colores], [ID_MiniPedido], [Color], [FechaActualizacion]) VALUES (N'3378', N'3316', N'P267C', N'2019-03-27 12:42:02.568')
GO

INSERT INTO [dbo].[MiniPedidoColores] ([ID_Colores], [ID_MiniPedido], [Color], [FechaActualizacion]) VALUES (N'3379', N'3317', N'P267C', N'2019-03-27 12:42:02.569')
GO

INSERT INTO [dbo].[MiniPedidoColores] ([ID_Colores], [ID_MiniPedido], [Color], [FechaActualizacion]) VALUES (N'3380', N'3318', N'P349C', N'2019-03-27 12:42:02.595')
GO

SET IDENTITY_INSERT [dbo].[MiniPedidoColores] OFF
GO


-- ----------------------------
-- Primary Key structure for table MiniPedido
-- ----------------------------
ALTER TABLE [dbo].[MiniPedido] ADD CONSTRAINT [PK_MiniPedido] PRIMARY KEY CLUSTERED ([ID_MiniPedido])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table MiniPedidoColores
-- ----------------------------
ALTER TABLE [dbo].[MiniPedidoColores] ADD CONSTRAINT [PK_MiniPedidoColores] PRIMARY KEY CLUSTERED ([ID_Colores])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

