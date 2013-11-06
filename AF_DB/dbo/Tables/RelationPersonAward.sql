CREATE TABLE [dbo].[RelationPersonAward] (
    [RelationPersonAwardId] INT NOT NULL IDENTITY(1,1),
    [PersonId]            INT NOT NULL,
    [AwardId]             INT NOT NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_RelationPersonAward] PRIMARY KEY CLUSTERED ([RelationPersonAwardId] ASC),
    CONSTRAINT [FK_RelationPersonAward_Awards] FOREIGN KEY ([AwardId]) REFERENCES [dbo].[Awards] ([AwardId]),
    CONSTRAINT [FK_RelationPersonAward_People] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]),
	CONSTRAINT [FK_RelationPersonAward_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

