CREATE TABLE [dbo].[News] (
    [NewsId] INT            NOT NULL,
    [Text]   NVARCHAR (MAX) NOT NULL,
    [UserId] INT            NOT NULL,
    [Edited] DATETIME       NOT NULL,
    CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED ([NewsId] ASC),
    CONSTRAINT [FK_News_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

