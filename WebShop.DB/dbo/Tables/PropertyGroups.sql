CREATE TABLE [dbo].[PropertyGroups] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (30) NULL,
    [CategoryID] INT           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);



