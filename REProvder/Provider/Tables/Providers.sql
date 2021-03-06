﻿CREATE TABLE [Provider].[Providers] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (255) NOT NULL,
    [Street]          NVARCHAR (255) NULL,
    [City]            NVARCHAR (255) NULL,
    [StateID]         INT            NULL,
    [Zip]             FLOAT (53)     NULL,
    [Email]           NVARCHAR (255) NULL,
    [Phone]           NVARCHAR (10)  NULL,
    [Website]         NVARCHAR (255) NULL,
    [SlidingScale]    BIT            NULL,
    [DiscountCashPay] BIT            NULL,
    [Hide]            BIT            CONSTRAINT [DF_Providers_Hide] DEFAULT ((0)) NOT NULL,
    [CreatedDate]     DATETIME       CONSTRAINT [DF_Providers_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [ModifiedDate]    DATETIME       NULL,
    [Notes]           NVARCHAR (MAX) NULL,
    [IMGLocation]     NVARCHAR (255) NULL,
    [Title]           NVARCHAR (50)  NULL,
    [GenderID]        INT            NULL,
    [NationalityID]   INT            NULL,
    [REVerified]      BIT            CONSTRAINT [DF_Providers_REVerified] DEFAULT ((0)) NOT NULL,
    [OwnerID]         INT            NULL,
    CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Providers_ListOfGender] FOREIGN KEY ([GenderID]) REFERENCES [RE].[ListOfGender] ([ID]),
    CONSTRAINT [FK_Providers_ListOfNationalities] FOREIGN KEY ([NationalityID]) REFERENCES [RE].[ListOfNationalities] ([ID]),
    CONSTRAINT [FK_Providers_States] FOREIGN KEY ([StateID]) REFERENCES [RE].[States] ([ID]),
    CONSTRAINT [FK_Providers_Users] FOREIGN KEY ([OwnerID]) REFERENCES [RE].[Users] ([ID])
);





