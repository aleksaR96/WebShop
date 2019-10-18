CREATE TABLE [dbo].[Orders] (
    [OrderID]       INT  IDENTITY (1, 1) NOT NULL,
    [UserID]        INT  NULL,
    [TotalQuantity] INT  NULL,
    [TotalPrice]    REAL NULL,
    PRIMARY KEY CLUSTERED ([OrderID] ASC),
    FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([UserID])
);

