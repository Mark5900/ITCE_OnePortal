USE ApplicationDB
GO

CREATE TABLE [dbo].[CM_Categories](
	[CatID] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](200) NOT NULL,
	PRIMARY KEY ([CatID])
)