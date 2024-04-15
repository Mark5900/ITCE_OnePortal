USE ApplicationDB
GO

CREATE TABLE [dbo].[SkoleData](
	[SkolePrefix] [varchar](255) NOT NULL,
	[SkoleNavn] [varchar](255) NOT NULL,
	[TeknikerGruppe] [varchar](255) NOT NULL,
	[CVR] [numeric](10, 0) NULL,
	[EAN] [numeric](15, 0) NULL,
	PRIMARY KEY ([SkolePrefix])
)