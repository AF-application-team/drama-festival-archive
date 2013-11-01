CREATE TABLE [dbo].[RelationPresonPlayRole] (
    [RelationPresonPlayRoleId] INT            NOT NULL,
    [PersonId]               INT            NOT NULL,
    [PlayId]                 INT            NOT NULL,
    [Role]                   NVARCHAR (200) NOT NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_RelationPresonPlayRole] PRIMARY KEY CLUSTERED ([RelationPresonPlayRoleId] ASC),
    CONSTRAINT [FK_RelationPresonPlayRole_People] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]),
    CONSTRAINT [FK_RelationPresonPlayRole_Plays] FOREIGN KEY ([PlayId]) REFERENCES [dbo].[Plays] ([PlayId]),
	CONSTRAINT [FK_RelationPresonPlayRole_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

