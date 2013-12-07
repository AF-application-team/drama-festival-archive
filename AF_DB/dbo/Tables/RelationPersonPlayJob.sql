CREATE TABLE [dbo].[RelationPersonPlayJobs] (
    [RelationPersonPlayJobId] INT NOT NULL IDENTITY(1,1),
    [PersonId]                INT NOT NULL,
    [PlayId]                  INT NOT NULL,
    [JobId]                   INT NOT NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_RelationPersonPlayJobs] PRIMARY KEY CLUSTERED ([RelationPersonPlayJobId] ASC),
    CONSTRAINT [FK_RelationPersonPlayJobs_Jobs] FOREIGN KEY ([JobId]) REFERENCES [dbo].[Jobs] ([JobId]),
    CONSTRAINT [FK_RelationPersonPlayJobs_People] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]),
    CONSTRAINT [FK_RelationPersonPlayJobs_Plays] FOREIGN KEY ([PlayId]) REFERENCES [dbo].[Plays] ([PlayId]),
	CONSTRAINT [FK_RelationPersonPlayJobs_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

