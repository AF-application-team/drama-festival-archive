CREATE TABLE [dbo].[Jobs] (
    [JobId]    INT            NOT NULL,
    [JobTitle] NVARCHAR (100) NOT NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
	CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED ([JobId] ASC),
	CONSTRAINT [FK_Jobs_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 
);

