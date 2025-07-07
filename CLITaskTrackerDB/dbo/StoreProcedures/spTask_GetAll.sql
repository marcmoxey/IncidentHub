CREATE PROCEDURE [dbo].[spTask_GetAll]

AS
begin
	select Id, Title, IsComplete, CreatedAt
	from dbo.[Task];
end
