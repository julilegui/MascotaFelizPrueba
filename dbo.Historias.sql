CREATE TABLE [dbo].[Historias] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [FechaInicial] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_Historias] PRIMARY KEY CLUSTERED ([Id] ASC)
);

