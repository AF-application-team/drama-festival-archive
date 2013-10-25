CREATE TABLE [dbo].[Positions] (
    [PositionId]    INT            NOT NULL,
    [PositionTItle] NVARCHAR (100) NOT NULL,
    [Section]       INT            NOT NULL,
    [Order]         INT            NOT NULL,
    CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED ([PositionId] ASC)
);

