CREATE PROCEDURE [dbo].[spDScreening_GetByFilmId]
	@filmId int = 0,
	@dateNow datetime2
AS

begin
	set nocount on;

	select f.Title as FilmTitle, s.StartTime, r.[Name] as RoomName from Screening s
	left join Film f on s.FilmId = f.Id
	left join Room r on s.RoomId = r.Id
	where s.FilmId = @filmId
	and s.StartTime >= @dateNow
	order by s.StartTime 

end
