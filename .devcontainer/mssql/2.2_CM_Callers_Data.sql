USE ApplicationDB
GO

SET IDENTITY_INSERT [dbo].[CM_Callers] ON
GO
INSERT [dbo].[CM_Callers]
	([CallID], [SkolePrefix], [ADTelephoneNumber], [AlternativNumber1], [AlternativNumber2], [Email], [UPN])
VALUES
	(1, N'ALGY', N'+45 12345678', N'+45 87654321', NULL, N'TEST1@test.dk', N'TEST1@test.dk')
GO
INSERT [dbo].[CM_Callers]
	([CallID], [SkolePrefix], [ADTelephoneNumber], [AlternativNumber1], [AlternativNumber2], [Email], [UPN])
VALUES
	(2, N'VF', NULL, NULL, NULL, N'Test2@test.dk', N'Test2@test.dk')
GO
INSERT [dbo].[CM_Callers]
	([CallID], [SkolePrefix], [ADTelephoneNumber], [AlternativNumber1], [AlternativNumber2], [Email], [UPN])
VALUES
	(3, N'ITCE', NULL, NULL, NULL, N'Operator@test.dk', N'Operator@test.dk')
GO
INSERT [dbo].[CM_Callers]
	([CallID], [SkolePrefix], [ADTelephoneNumber], [AlternativNumber1], [AlternativNumber2], [Email], [UPN])
VALUES
	(4, N'ITCE', NULL, NULL, NULL, N'Approver@test.dk', N'Approver@test.dk')
GO
SET IDENTITY_INSERT [dbo].[CM_Callers] OFF
GO