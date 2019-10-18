CREATE PROC InsertIntoUsers
@FirstName nvarchar(30),
@LastName nvarchar(30),
@Address nvarchar(50),
@City nvarchar(30),
@Phone varchar(20),
@Email nvarchar(30),
@Username nvarchar(30),
@Password nvarchar(30),
@UserType bit
AS
BEGIN
	INSERT INTO Users
	(
		FirstName,
		LastName,
		Adress,
		Phone,
		City,
		Email,
		Username,
		Password,
		UserType
	)
	VALUES
	(
		@FirstName,
		@LastName,
		@Address,
		@Phone,
		@City,
		@Email,
		@Username,
		@Password,
		@UserType
	)
END;