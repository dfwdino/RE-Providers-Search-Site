CREATE TABLE [RE].[States] (
    [ID]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (40) NOT NULL,
    [Abbrev] NVARCHAR (2)  NOT NULL,
    CONSTRAINT [PK_States] PRIMARY KEY CLUSTERED ([ID] ASC)
);

