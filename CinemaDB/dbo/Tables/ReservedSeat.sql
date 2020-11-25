CREATE TABLE [dbo].[ReservedSeat]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [BookingId] INT NOT NULL, 
    [SeatId] INT NOT NULL, 
    CONSTRAINT [FK_ReservedSeat_ToBooking] FOREIGN KEY ([BookingId]) REFERENCES [Booking]([Id])
)
