CREATE PROC InsertBrand
@Name nvarchar(20)
AS
BEGIN
	INSERT INTO Brands(Name)
	VALUES(@Name);

	SELECT *
	FROM Brands
	WHERE Name = @Name;
END;