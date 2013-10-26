CREATE TABLE [dbo].[RelationFestivalPersonPosition] (
    [RelationFestivalPersonPositionId] INT NOT NULL,
    [FestivalId]                       INT NOT NULL,
    [PersonId]                         INT NOT NULL,
    [PositionId]                       INT NOT NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_RelationFestivalPersonPosition] PRIMARY KEY CLUSTERED ([RelationFestivalPersonPositionId] ASC),
    CONSTRAINT [FK_RelationFestivalPersonPosition_Festivals1] FOREIGN KEY ([FestivalId]) REFERENCES [dbo].[Festivals] ([FestivalId]),
    CONSTRAINT [FK_RelationFestivalPersonPosition_People1] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]),
    CONSTRAINT [FK_RelationFestivalPersonPosition_Positions1] FOREIGN KEY ([PositionId]) REFERENCES [dbo].[Positions] ([PositionId]),
	CONSTRAINT [FK_RelationFestivalPersonPosiotion_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

