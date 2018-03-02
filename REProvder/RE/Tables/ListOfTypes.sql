CREATE TABLE [RE].[ListOfTypes] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Type] NVARCHAR (255) NOT NULL,
    [Hide] BIT            CONSTRAINT [DF_ListOfTypes_Hide] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ListOfTypes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

