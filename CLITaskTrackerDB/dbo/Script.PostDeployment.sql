if not exists(select 1 from dbo.Task)
begin
	INSERT INTO Task (Title, IsComplete) 
	VALUES ('Fix login button bug', 0),
	('Update user profile validation', 1),
	('Refactor incident controller', 0),
	('Add search to dashboard', 0),
	('Document API endpoints', 1),
	('Setup Azure deployment pipeline', 0),
	('Create test cases for incident form', 1),
	('Research MSAL authentication', 0),
	('Remove dead CSS from React app', 1),
	('Improve error handling on frontend', 0);
end