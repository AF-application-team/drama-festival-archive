CREATE TABLE [dbo].[RelationPersonAward] (
    [RelationPersonAward] INT NOT NULL,
    [PersonId]            INT NOT NULL,
    [AwardId]             INT NOT NULL,
    CONSTRAINT [PK_RelationPersonAward] PRIMARY KEY CLUSTERED ([RelationPersonAward] ASC),
    CONSTRAINT [FK_RelationPersonAward_Awards1] FOREIGN KEY ([AwardId]) REFERENCES [dbo].[Awards] ([AwardId]),
    CONSTRAINT [FK_RelationPersonAward_People1] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId])
);

