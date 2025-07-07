CREATE PROCEDURE [dbo].[spTask_Delete]
	@Id int
	
AS
begin 
	delete 
	from dbo.[Task]
	where Id = @Id;
end
