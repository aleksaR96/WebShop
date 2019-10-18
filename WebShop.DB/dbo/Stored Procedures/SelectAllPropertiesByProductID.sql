CREATE PROC SelectAllPropertiesByProductID
@ProductID int
AS
BEGIN
	SELECT *
	FROM Properties
	WHERE ProductID = @ProductID
END;