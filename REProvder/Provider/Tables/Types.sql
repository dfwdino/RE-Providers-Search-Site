CREATE TABLE [Provider].[Types] (
    [ID]         INT IDENTITY (1, 1) NOT NULL,
    [TypeID]     INT NOT NULL,
    [ProviderID] INT NOT NULL,
    [Hide]       BIT CONSTRAINT [DF_Types_Hide] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Types] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Types_ListOfTypes] FOREIGN KEY ([TypeID]) REFERENCES [RE].[ListOfTypes] ([ID]),
    CONSTRAINT [FK_Types_Providers] FOREIGN KEY ([ProviderID]) REFERENCES [Provider].[Providers] ([ID])
);

