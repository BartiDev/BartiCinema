CREATE PROCEDURE [dbo].[spTicket_GetAll]

AS
begin
	set nocount on;

	select * from Ticket;
end