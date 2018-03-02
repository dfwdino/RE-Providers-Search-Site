CREATE TABLE [RE].[ListOfServices] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (255) NULL,
    [Hide] BIT            CONSTRAINT [DF_ListOfServices_Hide] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Services] PRIMARY KEY CLUSTERED ([ID] ASC)
);

