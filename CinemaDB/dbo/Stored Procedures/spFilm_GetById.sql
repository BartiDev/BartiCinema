CREATE PROCEDURE [dbo].[spFilm_GetById]
	@id int
AS

begin
	set nocount on;

	select * from Film
	where Id = @id;
end
