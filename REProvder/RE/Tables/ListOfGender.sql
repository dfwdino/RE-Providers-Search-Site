CREATE TABLE [RE].[ListOfGender] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Hide]        BIT           CONSTRAINT [DF_ListOfGender_Hide] DEFAULT ((0)) NOT NULL,
    [CreatedDate] DATETIME      CONSTRAINT [DF_ListOfGender_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [Gender]      NVARCHAR (25) NOT NULL,
    CONSTRAINT [PK_ListOfGender] PRIMARY KEY CLUSTERED ([ID] ASC)
);

