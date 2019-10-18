CREATE PROC Select24ProductsWithOffset
@offset int
AS
BEGIN
	SELECT *
	FROM Products
	ORDER BY ProductID
	OFFSET @offset ROWS
		FETCH NEXT 24 ROWS ONLY
END;