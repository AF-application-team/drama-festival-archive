CREATE TABLE [dbo].[RelationPersonPlayRole] (
    [RelationPersonPlayRoleId] INT            NOT NULL,
    [PersonId]               INT            NOT NULL,
    [PlayId]                 INT            NOT NULL,
    [Role]                   NVARCHAR (200) NOT NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_RelationPersonPlayRole] PRIMARY KEY CLUSTERED ([RelationPersonPlayRoleId] ASC),
    CONSTRAINT [FK_RelationPersonPlayRole_People] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]),
    CONSTRAINT [FK_RelationPersonPlayRole_Plays] FOREIGN KEY ([PlayId]) REFERENCES [dbo].[Plays] ([PlayId]),
	CONSTRAINT [FK_RelationPersonPlayRole_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

