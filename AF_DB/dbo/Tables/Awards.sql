CREATE TABLE [dbo].[Awards] (
    [AwardId]    INT NOT NULL IDENTITY(1,1),
    [CategoryId] INT NOT NULL,
    [FestivalId] INT NOT NULL,
    [PlayId]     INT NOT NULL,
    [EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_Awards] PRIMARY KEY CLUSTERED ([AwardId] ASC),
    CONSTRAINT [FK_Awards_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([CategoryId]),
    CONSTRAINT [FK_Awards_Festivals] FOREIGN KEY ([FestivalId]) REFERENCES [dbo].[Festivals] ([FestivalId]),
    CONSTRAINT [FK_Awards_Plays] FOREIGN KEY ([PlayId]) REFERENCES [dbo].[Plays] ([PlayId]),
	CONSTRAINT [FK_Awards_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 


);

