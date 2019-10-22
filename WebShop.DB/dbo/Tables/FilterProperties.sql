CREATE TABLE [dbo].[FilterProperties] (
    [ID]         INT IDENTITY (1, 1) NOT NULL,
    [CategoryID] INT NULL,
    [PropertyID] INT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category] ([CategoryID]),
    FOREIGN KEY ([PropertyID]) REFERENCES [dbo].[PropertyList] ([ID])
);

