CREATE PROC UpdateUsersByID
@ID int,
@FirstName nvarchar(30),
@LastName nvarchar(30),
@Adress nvarchar(50),
@Phone varchar(20),
@City nvarchar(30),
@Email nvarchar(30),
@Username nvarchar(30),
@Password nvarchar(30),
@UserType bit
AS
BEGIN
	
	UPDATE Users
	SET
		FirstName = @FirstName,
		LastName = @LastName,
		Adress = @Adress,
		Phone = @Phone,
		City = @City,
		Email = @Email,
		Username = @Username,
		Password = @Password,
		UserType = @UserType
	WHERE UserID = @ID
END;