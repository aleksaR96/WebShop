CREATE PROC UpdateBrand
@ID int,
@Name nvarchar(20)
AS
BEGIN
	UPDATE Brands 
	SET Name = @Name
	WHERE ID = @ID;

	SELECT *
	FROM Brands
	WHERE ID = @ID;
END;