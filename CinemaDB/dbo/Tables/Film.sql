CREATE TABLE [dbo].[Film]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [Title] NVARCHAR(128) NOT NULL, 
    [Director] NVARCHAR(100) NOT NULL, 
    [Genres] NVARCHAR(128) NOT NULL, 
    [ReleaseDate] DATETIME2 NOT NULL, 
    [LenghtMin] INT NOT NULL,
    [Description] NVARCHAR(2048),
    [Storyline] NVARCHAR(MAX)
)
