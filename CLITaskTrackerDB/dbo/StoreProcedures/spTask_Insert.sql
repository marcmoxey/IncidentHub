CREATE PROCEDURE [dbo].[spTask_Insert]
	@Title nvarchar(200),
	@IsComplete Bit
AS
begin 
	insert into dbo.[Task] (Title, IsComplete)
	values (@Title, @IsComplete);
end
