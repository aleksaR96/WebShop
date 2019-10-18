CREATE PROC InsertIntoCategory
@ID int,
@Name nvarchar(30),
@Icon varchar(20)
AS
BEGIN
	INSERT INTO Category(CategoryID, Name, Image, Icon)
	VALUES(@ID, @Name, CAST(@ID as varchar(10)) + '.png', @Icon)
END;