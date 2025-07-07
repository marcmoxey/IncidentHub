CREATE PROCEDURE [dbo].[spTask_Get]
	@Id int

AS
begin
	select Id, Title, IsComplete, CreatedAt
	from dbo.[Task]
	where Id = @Id;

end
