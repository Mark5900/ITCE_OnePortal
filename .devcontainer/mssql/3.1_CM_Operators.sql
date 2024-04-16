USE ApplicationDB
GO

CREATE TABLE [dbo].[CM_Operators](
	[OpID] [int] IDENTITY(1,1) NOT NULL,
	[ChangeApprover] [bit] NULL,
	[CallID] [int] NOT NULL,
	PRIMARY KEY ([OpID]),
	FOREIGN KEY ([CallID]) REFERENCES [dbo].[CM_Callers] ([CallID])
)