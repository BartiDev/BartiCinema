CREATE TABLE [dbo].[Seat]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [Row] INT NOT NULL, 
    [Number] INT NOT NULL, 
    [RoomId] INT NOT NULL, 
    CONSTRAINT [FK_Seat_ToRoom] FOREIGN KEY ([RoomId]) REFERENCES [Room]([Id])
)
