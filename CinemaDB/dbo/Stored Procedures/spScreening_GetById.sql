CREATE PROCEDURE [dbo].[spScreening_GetById]
	@id int

AS
begin
	set nocount on;

	select * from Screening
	where Id = @id;
end
