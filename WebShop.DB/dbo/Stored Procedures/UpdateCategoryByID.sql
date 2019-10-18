CREATE PROC UpdateCategoryByID
@ID int,
@CategoryID int,
@Name nvarchar(30),
@Image nvarchar(50),
@Icon varchar(20)
AS
BEGIN
	
	UPDATE Category
	SET
		CategoryID = @CategoryID,
		Name = @Name,
		Image = @Image,
		Icon = @Icon
	WHERE CategoryID = @ID
END;