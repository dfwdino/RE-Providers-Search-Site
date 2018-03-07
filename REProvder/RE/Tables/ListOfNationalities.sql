CREATE TABLE [RE].[ListOfNationalities] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Hide]        BIT           CONSTRAINT [DF_ListOfNationalities_Hide] DEFAULT ((0)) NOT NULL,
    [CreatedDate] DATETIME      CONSTRAINT [DF_ListOfNationalities_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [Nationality] NVARCHAR (25) NOT NULL,
    CONSTRAINT [PK_ListOfNationalities] PRIMARY KEY CLUSTERED ([ID] ASC)
);

