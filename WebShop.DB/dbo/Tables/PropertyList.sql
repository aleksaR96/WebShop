CREATE TABLE [dbo].[PropertyList] (
    [ID]                INT           IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (30) NULL,
    [GroupID]           INT           NULL,
    [RelatedPropertyID] INT           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([GroupID]) REFERENCES [dbo].[PropertyGroups] ([ID])
);



