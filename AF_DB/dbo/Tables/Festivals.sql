CREATE TABLE [dbo].[Festivals] (
    [FestivalId]   INT  NOT NULL,
    [Year]         DATE NOT NULL,
    [BeginingDate] DATE NOT NULL,
    [EndDate]      DATE NOT NULL,
    CONSTRAINT [PK_Festivals] PRIMARY KEY CLUSTERED ([FestivalId] ASC)
);

