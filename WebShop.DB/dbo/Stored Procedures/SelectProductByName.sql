CREATE PROC SelectProductByName
@Name nvarchar(30)
AS
BEGIN
	Select *
	FROM Products
	WHERE Name = @Name
END;