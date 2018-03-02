CREATE TABLE [Provider].[Insurances] (
    [ID]           INT IDENTITY (1, 1) NOT NULL,
    [InsureanceID] INT NOT NULL,
    [ProviderID]   INT NOT NULL,
    [Hide]         BIT NOT NULL,
    CONSTRAINT [PK_Insurances] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Insurances_Insurances1] FOREIGN KEY ([InsureanceID]) REFERENCES [RE].[ListOfInsuranceCompanys] ([ID]),
    CONSTRAINT [FK_Insurances_Providers] FOREIGN KEY ([ProviderID]) REFERENCES [Provider].[Providers] ([ID])
);

