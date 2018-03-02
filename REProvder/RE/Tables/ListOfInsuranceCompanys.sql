CREATE TABLE [RE].[ListOfInsuranceCompanys] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL,
    [Hide] BIT           CONSTRAINT [DF_ListOfInsuranceCompanys_Hide] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Insurance] PRIMARY KEY CLUSTERED ([ID] ASC)
);

