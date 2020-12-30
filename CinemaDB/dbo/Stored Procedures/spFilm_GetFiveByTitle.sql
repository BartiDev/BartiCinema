CREATE PROCEDURE [dbo].[spFilm_GetFiveByTitle]
	@phrase nvarchar(128)
AS
begin
	set nocount on;

	select top 5 * from Film
	where Title like '%'+@phrase+'%';
end
