CREATE TABLE [dbo].[Users] (
    [UserID]    INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (30) NOT NULL,
    [LastName]  NVARCHAR (30) NOT NULL,
    [Adress]    NVARCHAR (50) NULL,
    [Phone]     VARCHAR (20)  NULL,
    [City]      NVARCHAR (30) NULL,
    [Email]     NVARCHAR (30) NOT NULL,
    [Username]  NVARCHAR (30) NOT NULL,
    [Password]  NVARCHAR (30) NOT NULL,
    [UserType]  BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

