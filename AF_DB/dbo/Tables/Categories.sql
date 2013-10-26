CREATE TABLE [dbo].[Categories] (
    [CategoryId] INT            NOT NULL,
    [Title]      NVARCHAR (100) NOT NULL,
    [Group]      INT            NOT NULL,
    [Order]      INT            NOT NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
	CONSTRAINT [FK_Categories_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

