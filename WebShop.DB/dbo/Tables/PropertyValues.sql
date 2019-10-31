CREATE TABLE [dbo].[PropertyValues] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [PropertyID] INT           NULL,
    [Value]      NVARCHAR (30) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([PropertyID]) REFERENCES [dbo].[PropertyList] ([ID])
);

