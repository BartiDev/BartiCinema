CREATE PROCEDURE [dbo].[spScreening_GetAllReservedSeats]
	@screeningId int
AS

begin
	set nocount on;

	select rs.Id, rs.BookingId, rs.SeatId from Screening s
	left join Booking b on s.Id = b.ScreeningId
	left join ReservedSeat rs on b.Id = rs.BookingId
	where s.id = @screeningId;
end
