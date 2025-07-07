CREATE PROCEDURE [dbo].[spTask_Update]
	@Id int,
	@Title nvarchar(200),
	@IsComplete Bit
AS
begin 
	update dbo.[Task] 
	set Title = @Title, IsComplete = @IsComplete
	where Id = @Id;
end
