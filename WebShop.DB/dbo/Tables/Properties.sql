CREATE TABLE [dbo].[Properties] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [ProductID]  INT           NULL,
    [PropertyID] INT           NULL,
    [Value]      NVARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID]),
    FOREIGN KEY ([PropertyID]) REFERENCES [dbo].[PropertyList] ([ID])
);

