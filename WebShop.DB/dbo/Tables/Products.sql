CREATE TABLE [dbo].[Products] (
    [ProductID]   INT             IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (30)   NOT NULL,
    [Description] NVARCHAR (2000) NOT NULL,
    [CategoryID]  INT             NOT NULL,
    [Price]       REAL            NOT NULL,
    [Quantity]    INT             NOT NULL,
    [BrandID]     INT             NULL,
    [Pinned]      BIT             NULL,
    [Discount]    INT             NULL,
    [New]         BIT             NULL,
    [Popular]     BIT             NULL,
    PRIMARY KEY CLUSTERED ([ProductID] ASC),
    FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category] ([CategoryID])
);

