CREATE TABLE [dbo].[News] (
    [NewsId] INT            NOT NULL,
    [Text]   NVARCHAR (MAX) NOT NULL,
    [EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED ([NewsId] ASC),
	CONSTRAINT [FK_News_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

