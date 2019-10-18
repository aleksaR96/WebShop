CREATE TABLE [dbo].[Category] (
    [CategoryID] INT           NOT NULL,
    [Name]       NVARCHAR (30) NOT NULL,
    [Image]      NVARCHAR (50) NULL,
    [Icon]       VARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([CategoryID] ASC)
);

