CREATE TABLE [dbo].[Plays] (
    [PlayId]     INT            NOT NULL,
    [Title]      NVARCHAR (MAX) NOT NULL,
    [Author]     NVARCHAR (MAX) NOT NULL,
    [FestivalId] INT            NOT NULL,
    [Day]        INT            NOT NULL,
    [Order]      INT            NOT NULL,
    [PlayedBy]   NVARCHAR (MAX) NULL,
    [Motto]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Plays] PRIMARY KEY CLUSTERED ([PlayId] ASC),
    CONSTRAINT [FK_Plays_Festivals] FOREIGN KEY ([FestivalId]) REFERENCES [dbo].[Festivals] ([FestivalId])
);

