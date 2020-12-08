CREATE TABLE [dbo].[Booking]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [ScreeningId] INT NOT NULL, 
    [CustomerId] NVARCHAR(128) NOT NULL, 
    [TicketId] INT NOT NULL, 
    CONSTRAINT [FK_Booking_ToScreening] FOREIGN KEY ([ScreeningId]) REFERENCES [Screening]([Id]), 
    CONSTRAINT [FK_Booking_ToCustomer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]), 
    CONSTRAINT [FK_Booking_ToPriceList] FOREIGN KEY ([TicketId]) REFERENCES [Ticket]([Id]) 
)
