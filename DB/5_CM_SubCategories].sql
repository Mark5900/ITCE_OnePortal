CREATE TABLE [dbo].[CM_SubCategories](
	[SubCatID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CatID] [int] NOT NULL,
	PRIMARY KEY ([SubCatID]),
	FOREIGN KEY ([CatID]) REFERENCES [dbo].[CM_Categories] ([CatID])
)