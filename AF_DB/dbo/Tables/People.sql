CREATE TABLE [dbo].[People] (
    [PersonId]  INT            NOT NULL,
    [FirstName] NVARCHAR (50)  NOT NULL,
    [LastName]  NVARCHAR (100) NOT NULL,
    [Sex]       BIT            NOT NULL,
    [Year]      INT           NOT NULL,
	[Profile]	CHAR(1)		   NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([PersonId] ASC),
	CONSTRAINT [FK_People_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

