CREATE TABLE [dbo].[OrderProducts] (
    [OrderProductsID] INT  IDENTITY (1, 1) NOT NULL,
    [OrderID]         INT  NULL,
    [ProductID]       INT  NULL,
    [Quantity]        INT  NOT NULL,
    [Price]           REAL NOT NULL,
    PRIMARY KEY CLUSTERED ([OrderProductsID] ASC),
    FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Orders] ([OrderID]),
    FOREIGN KEY ([ProductID]) REFERENCES [dbo].[Products] ([ProductID])
);

