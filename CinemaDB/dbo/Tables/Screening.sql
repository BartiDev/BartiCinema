CREATE TABLE [dbo].[Screening]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [FilmId] INT NOT NULL, 
    [RoomId] INT NOT NULL, 
    [StartTime] DATETIME2 NOT NULL,
    CONSTRAINT [FK_Screening_ToFilm] FOREIGN KEY ([FilmId]) REFERENCES [Film]([Id]), 
    CONSTRAINT [FK_Screening_ToRoom] FOREIGN KEY ([RoomId]) REFERENCES [Room]([Id])
)
