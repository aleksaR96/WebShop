CREATE PROC Select10ProductsWithOffset
@offset int
AS
BEGIN
	SELECT *
	FROM Products
	ORDER BY ProductID
	OFFSET @offset ROWS
		FETCH NEXT 10 ROWS ONLY
END;