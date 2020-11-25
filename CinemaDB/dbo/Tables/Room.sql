CREATE TABLE [dbo].[Room]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [Name] NVARCHAR(70) NOT NULL, 
    [NoSeats] INT NOT NULL
)
