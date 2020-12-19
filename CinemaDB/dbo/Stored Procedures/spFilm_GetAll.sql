CREATE PROCEDURE [dbo].[spFilm_GetAll]
AS

begin
	set nocount on;

	Select * from dbo.Film;
end
