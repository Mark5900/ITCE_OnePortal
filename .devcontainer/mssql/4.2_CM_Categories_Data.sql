USE ApplicationDB
GO

SET IDENTITY_INSERT [dbo].[CM_Categories] ON
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(1, N'Backup og gendannelse (G)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(2, N'Brugerkonti (G)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(3, N'Deployment af software (G)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(4, N'ESDH System (T)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(5, N'Hosting af applikationer (T)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(6, N'IT - Udstyr elev (G)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(7, N'IT - Udstyr medarbejdere (G)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(8, N'Lokal Support')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(9, N'Netværk (GT)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(10, N'Netværks filer (G)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(11, N'Office 365 tjenester (GT)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(12, N'Overvågning og sikkerhed (G)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(13, N'Print (G)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(14, N'Serverdrift (GT)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(15, N'Sikker mail (T)')
GO
INSERT [dbo].[CM_Categories]
	([CatID], [Category])
VALUES
	(16, N'Andet')
GO
SET IDENTITY_INSERT [dbo].[CM_Categories] OFF
GO