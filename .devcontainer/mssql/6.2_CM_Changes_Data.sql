USE ApplicationDB
GO

SET IDENTITY_INSERT [dbo].[CM_Changes] ON
GO
INSERT [dbo].[CM_Changes]
    ([ChanID], [CallID], [BriefDescription], [SubCatID], [Description], [StartTime], [ImplementedTime], [Status], [ApprovedByApprover], [OpID], [IsTemplate], [NeedApproval])
VALUES
    (1, 1, N'Gendannelse af filer (G)', 1, N'Gendannelse af filer (G)', CAST(N'2022-01-01T00:00:00.000' AS DateTime), CAST(N'2022-01-01T00:00:00.000' AS DateTime), N'Godkendt', 1, 1, 0, 0)
GO
INSERT [dbo].[CM_Changes]
    ([ChanID], [CallID], [BriefDescription], [SubCatID], [Description], [StartTime], [ImplementedTime], [Status], [ApprovedByApprover], [OpID], [IsTemplate], [NeedApproval])
VALUES
    (2, 1, N'Gendannelse af systemdata (G)', 1, N'Gendannelse af systemdata (G)', CAST(N'2022-01-01T00:00:00.000' AS DateTime), CAST(N'2022-01-01T00:00:00.000' AS DateTime), N'Godkendt', 1, 1, 0, 0)
GO