CREATE TABLE [dbo].[Images] (
    [ImageID]   INT           IDENTITY (1, 1) NOT NULL,
    [ProductID] INT           NULL,
    [Image]     NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ImageID] ASC)
);

