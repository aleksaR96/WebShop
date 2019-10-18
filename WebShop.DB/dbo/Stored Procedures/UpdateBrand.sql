CREATE PROC UpdateBrand
@ID int,
@Name nvarchar(20)
AS
BEGIN
	UPDATE Brands 
	SET Name = @Name
END;