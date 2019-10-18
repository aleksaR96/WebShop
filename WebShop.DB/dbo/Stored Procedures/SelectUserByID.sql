CREATE PROC SelectUserByID
@ID int
AS
BEGIN
	Select *
	FROM Users
	WHERE UserID = @ID
END;