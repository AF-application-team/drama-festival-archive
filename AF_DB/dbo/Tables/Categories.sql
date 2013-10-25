CREATE TABLE [dbo].[Categories] (
    [CategoryId] INT            NOT NULL,
    [Title]      NVARCHAR (100) NOT NULL,
    [Group]      INT            NOT NULL,
    [Order]      INT            NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

