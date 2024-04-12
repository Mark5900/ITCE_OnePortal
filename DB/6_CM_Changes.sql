CREATE TABLE [dbo].[CM_Changes](
	[ChanID] [int] IDENTITY(1,1) NOT NULL,
	[CallID] [int] NOT NULL,
	[BriefDescription] [varchar](150) NOT NULL,
	[SubCatID] [int] NOT NULL,
	[Description] [text] NULL,
	[StartTime] [datetime] NOT NULL,
	[ImplementedTime] [datetime] NOT NULL,
	[Status] [varchar](50) NOT NULL,
	[ApprovedByApprover] [bit] NULL,
	[OpID] [int] NOT NULL,
	[IsTemplate] [bit] NULL,
	[NeedApproval] [bit] NULL,
	PRIMARY KEY ([ChanID]),
	FOREIGN KEY ([CallID]) REFERENCES [dbo].[CM_Callers] ([CallID]),
	FOREIGN KEY ([SubCatID]) REFERENCES [dbo].[CM_SubCategories] ([SubCatID]),
	FOREIGN KEY ([OpID]) REFERENCES [dbo].[CM_Operators] ([OpID])
)