CREATE TABLE [RE].[UserTypes] (
    [ID]      INT           IDENTITY (1, 1) NOT NULL,
    [Disable] BIT           CONSTRAINT [DF_UserTypes_Disable] DEFAULT ((0)) NOT NULL,
    [Type]    NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

