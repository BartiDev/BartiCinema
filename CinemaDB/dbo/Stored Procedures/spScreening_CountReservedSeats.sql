﻿CREATE PROCEDURE [dbo].[spScreening_CountReservedSeats]
	@id int

AS
begin
	set nocount on;

	select count(rs.Id) from ReservedSeat rs
	left join Booking b on rs.BookingId = b.Id
	left join Screening s on b.ScreeningId = s.Id
	where s.Id = @id;
end
