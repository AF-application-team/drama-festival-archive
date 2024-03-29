﻿CREATE TABLE [dbo].[Users] (
    [UserId]    INT            NOT NULL IDENTITY(1,1),
    [Login]     NVARCHAR (50)  NOT NULL,
    [Password]	NVARCHAR (100) NOT NULL,
	[Salt]		NVARCHAR (60)  NOT NULL,
	[FirstName] NVARCHAR (50)  NOT NULL,
    [LastName]  NVARCHAR (100) NOT NULL,
    [Email]     NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

