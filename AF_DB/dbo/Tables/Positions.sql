CREATE TABLE [dbo].[Positions] (
    [PositionId]    INT            NOT NULL IDENTITY(1,1),
    [PositionTitle] NVARCHAR (100) NOT NULL,
    [Section]       INT            NOT NULL,
    [Order]         INT            NOT NULL,
	[EditDate] DATETIME NOT NULL, 
    [EditedBy] INT NOT NULL,
    CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED ([PositionId] ASC),
	CONSTRAINT [FK_Positions_Users] FOREIGN KEY ([EditedBy]) REFERENCES [dbo].[Users] ([UserId]) 

);

