CREATE PROC SelectPropertyByProductIDAndPropertyID
@ProductID int,
@PropertyID int
AS
BEGIN
	SELECT *
	FROM Properties
	WHERE
		ProductID = @ProductID
		AND
		PropertyID = @PropertyID
END;