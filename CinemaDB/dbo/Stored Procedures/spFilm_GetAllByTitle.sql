CREATE PROCEDURE [dbo].[spFilm_GetAllByTitle]
	@phrase nvarchar(128)
AS
begin
	set nocount on;

	select * from Film
	where Title like '%'+@phrase+'%';
end
