SET IDENTITY_INSERT [dbo].[CM_Operators] ON
GO
INSERT [dbo].[CM_Operators]
	([OpID], [ChangeApprover], [CallID])
VALUES
	(1, NULL, 3)
GO
INSERT [dbo].[CM_Operators]
	([OpID], [ChangeApprover], [CallID])
VALUES
	(2, 1, 4)
GO
SET IDENTITY_INSERT [dbo].[CM_Operators] OFF
GO