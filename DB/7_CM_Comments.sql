CREATE TABLE [dbo].[CM_Comments](
	[ComID] [int] IDENTITY(1,1) NOT NULL,
	[ChanID] [int] NOT NULL,
	[OpID] [int] NOT NULL,
	[Comment] [text] NOT NULL,
	PRIMARY KEY ([ComID]),
	FOREIGN KEY ([ChanID]) REFERENCES [dbo].[CM_Changes] ([ChanID]),
	FOREIGN KEY ([OpID]) REFERENCES [dbo].[CM_Operators] ([OpID])
)