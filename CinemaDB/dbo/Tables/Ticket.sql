CREATE TABLE [dbo].[Ticket]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [Name] NVARCHAR(50) NOT NULL, 
    [Price] DECIMAL NOT NULL
)
