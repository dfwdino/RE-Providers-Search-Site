CREATE TABLE [Provider].[Services] (
    [ID]         INT IDENTITY (1, 1) NOT NULL,
    [ProviderID] INT NOT NULL,
    [ServiceID]  INT NOT NULL,
    [Hide]       BIT CONSTRAINT [DF_Services_bit] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ProviderServices] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ProviderServices_Services] FOREIGN KEY ([ServiceID]) REFERENCES [RE].[ListOfServices] ([ID]),
    CONSTRAINT [FK_Services_Providers] FOREIGN KEY ([ProviderID]) REFERENCES [Provider].[Providers] ([ID])
);



