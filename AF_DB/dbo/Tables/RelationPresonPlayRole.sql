CREATE TABLE [dbo].[RelationPresonPlayRole] (
    [RelationPresonPlayRole] INT            NOT NULL,
    [PersonId]               INT            NOT NULL,
    [PlayId]                 INT            NOT NULL,
    [Role]                   NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_RelationPresonPlayRole] PRIMARY KEY CLUSTERED ([RelationPresonPlayRole] ASC),
    CONSTRAINT [FK_RelationPresonPlayRole_People1] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]),
    CONSTRAINT [FK_RelationPresonPlayRole_Plays] FOREIGN KEY ([PlayId]) REFERENCES [dbo].[Plays] ([PlayId])
);

