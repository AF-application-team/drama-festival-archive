CREATE TABLE [dbo].[RelationPersonPlayJob] (
    [RelationPersonPlayJobId] INT NOT NULL,
    [PersonId]                INT NOT NULL,
    [PlayId]                  INT NOT NULL,
    [JobId]                   INT NOT NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_RelationPersonPlayJob] PRIMARY KEY CLUSTERED ([RelationPersonPlayJobId] ASC),
    CONSTRAINT [FK_RelationPersonPlayJob_Jobs] FOREIGN KEY ([JobId]) REFERENCES [dbo].[Jobs] ([JobId]),
    CONSTRAINT [FK_RelationPersonPlayJob_People] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]),
    CONSTRAINT [FK_RelationPersonPlayJob_Plays1] FOREIGN KEY ([PlayId]) REFERENCES [dbo].[Plays] ([PlayId]),
	CONSTRAINT [FK_RelationPersonPlayJob_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

