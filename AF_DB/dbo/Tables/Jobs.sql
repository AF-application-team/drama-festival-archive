CREATE TABLE [dbo].[Jobs] (
    [JobId]    INT            NOT NULL,
    [JobTitle] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED ([JobId] ASC)
);

