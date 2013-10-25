CREATE TABLE [dbo].[People] (
    [PersonId]  INT            NOT NULL,
    [FirstName] NVARCHAR (50)  NOT NULL,
    [LastName]  NVARCHAR (100) NOT NULL,
    [Sex]       BIT            NOT NULL,
    [Year]      DATE           NOT NULL,
    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([PersonId] ASC)
);

