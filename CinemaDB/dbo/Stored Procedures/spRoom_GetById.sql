CREATE PROCEDURE [dbo].[spRoom_GetById]
	@id int

AS
 begin
	set nocount on;

	select * from Room
	where Id = @id;
 end
