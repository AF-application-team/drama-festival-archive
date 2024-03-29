﻿CREATE TABLE [dbo].[Festivals] (
    [FestivalId]   INT  NOT NULL IDENTITY(1,1),
    [Year]         INT NOT NULL,
    [BeginningDate] DATE NOT NULL,
    [EndDate]      DATE NOT NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
	CONSTRAINT [PK_Festivals] PRIMARY KEY CLUSTERED ([FestivalId] ASC),
	CONSTRAINT [FK_Festivals_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 
);

