CREATE PROCEDURE [dbo].[spBooking_FinalizeBooking]
	@screeningId int,
	@ticketId int,
    @firstName nvarchar(50), 
    @lastName nvarchar(50), 
    @emailAddress nvarchar(256),
	@seatsToReserve SeatIdUDTT readonly
AS
	declare @customerId int
	declare @bookingId int

begin try

	begin transaction

		set @customerId = (select Id from Customer
		where EmailAddress = @emailAddress)

		if @customerId is null
		begin
			insert into Customer(FirstName, LastName, EmailAddress)
			values(@firstName, @lastName, @emailAddress);
			set @customerId = SCOPE_IDENTITY();
		end

		insert into Booking(CustomerId, ScreeningId, TicketId)
		values(@customerId, @screeningId, @ticketId);
		set @bookingId = SCOPE_IDENTITY();

		insert into ReservedSeat(BookingId, SeatId) 
		select @bookingId, SeatId from @seatsToReserve;

	commit transaction

end try
begin catch
	rollback
end catch