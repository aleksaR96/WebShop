CREATE PROC SelectBrands
@id int
AS
BEGIN
	SELECT *FROM Brands
	WHERE ID = @id
END;