/* Beers Table */
CREATE TABLE [dbo].[Beers] (
    [Id]    INT             IDENTITY (1, 1) NOT NULL,
    [Name]  NVARCHAR (MAX)  NULL,
    [Size]  NVARCHAR (MAX)  NULL,
    [Price] DECIMAL (18, 2) NOT NULL
);
