CREATE TABLE [dbo].[Plays] (
    [PlayId]     INT            NOT NULL IDENTITY(1,1),
    [Title]      NVARCHAR (MAX) NOT NULL,
    [Author]     NVARCHAR (MAX) NOT NULL,
    [FestivalId] INT            NOT NULL,
    [Day]        INT            NOT NULL,
    [Order]      INT            NOT NULL,
    [PlayedBy]   NVARCHAR (MAX) NOT NULL,
    [Motto]      NVARCHAR (MAX) NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_Plays] PRIMARY KEY CLUSTERED ([PlayId] ASC),
    CONSTRAINT [FK_Plays_Festivals] FOREIGN KEY ([FestivalId]) REFERENCES [dbo].[Festivals] ([FestivalId]),
	CONSTRAINT [FK_Plays_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

