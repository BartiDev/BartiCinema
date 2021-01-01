CREATE PROCEDURE [dbo].[spDScreening_GetByStartTime]
	@today datetime,
	@tomorrow datetime
AS

begin
	set nocount on;

	select s.Id, f.Title as FilmTitle, s.StartTime, r.[Name] as RoomName from Screening s
	left join Film f on s.FilmId = f.Id
	left join Room r on s.RoomId = r.Id
	where s.StartTime between @today and @tomorrow
	order by s.StartTime 

end
