CREATE TABLE [RE].[Users] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [LoginName]  NVARCHAR (25) NOT NULL,
    [Password]   NVARCHAR (25) NOT NULL,
    [Disable]    BIT           CONSTRAINT [DF_Users_Disable] DEFAULT ((0)) NOT NULL,
    [UserTypeID] INT           CONSTRAINT [DF_Users_UserTypeID] DEFAULT ((3)) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Users_UserTypes] FOREIGN KEY ([UserTypeID]) REFERENCES [RE].[UserTypes] ([ID])
);



