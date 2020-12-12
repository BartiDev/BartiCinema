CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(256) NOT NULL
)
