CREATE TABLE [dbo].[RelationPersonPlayRoles] (
    [RelationPersonPlayRoleId] INT            NOT NULL IDENTITY(1,1),
    [PersonId]               INT            NOT NULL,
    [PlayId]                 INT            NOT NULL,
    [Role]                   NVARCHAR (200) NOT NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_RelationPersonPlayRoles] PRIMARY KEY CLUSTERED ([RelationPersonPlayRoleId] ASC),
    CONSTRAINT [FK_RelationPersonPlayRoles_People] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]),
    CONSTRAINT [FK_RelationPersonPlayRoles_Plays] FOREIGN KEY ([PlayId]) REFERENCES [dbo].[Plays] ([PlayId]),
	CONSTRAINT [FK_RelationPersonPlayRoles_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

