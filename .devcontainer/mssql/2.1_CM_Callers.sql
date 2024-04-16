USE ApplicationDB
GO

CREATE TABLE [dbo].[CM_Callers](
	[CallID] [int] IDENTITY(1,1) NOT NULL,
	[SkolePrefix] [varchar](255) NOT NULL,
	[ADTelephoneNumber] [varchar](50) NULL,
	[AlternativNumber1] [varchar](50) NULL,
	[AlternativNumber2] [varchar](50) NULL,
	[Email] [varchar](150) NOT NULL,
	[UPN] [varchar](150) NOT NULL,
	PRIMARY KEY ([CallID]),
	FOREIGN KEY ([SkolePrefix]) REFERENCES [dbo].[SkoleData] ([SkolePrefix])
)