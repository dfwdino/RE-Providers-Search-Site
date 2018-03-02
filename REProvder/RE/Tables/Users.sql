CREATE TABLE [RE].[Users] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [LoginName] NVARCHAR (25) NOT NULL,
    [Password]  NVARCHAR (25) NOT NULL,
    [Disable]   BIT           CONSTRAINT [DF_Users_Disable] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC)
);

