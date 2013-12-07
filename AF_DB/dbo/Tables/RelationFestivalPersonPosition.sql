CREATE TABLE [dbo].[RelationFestivalPersonPositions] (
    [RelationFestivalPersonPositionId] INT NOT NULL IDENTITY(1,1),
    [FestivalId]                       INT NOT NULL,
    [PersonId]                         INT NOT NULL,
    [PositionId]                       INT NOT NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_RelationFestivalPersonPositions] PRIMARY KEY CLUSTERED ([RelationFestivalPersonPositionId] ASC),
    CONSTRAINT [FK_RelationFestivalPersonPositions_Festivals] FOREIGN KEY ([FestivalId]) REFERENCES [dbo].[Festivals] ([FestivalId]),
    CONSTRAINT [FK_RelationFestivalPersonPositions_People1] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]),
    CONSTRAINT [FK_RelationFestivalPersonPositions_Positions] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Positions] ([PositionId]),
	CONSTRAINT [FK_RelationFestivalPersonPositions_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

