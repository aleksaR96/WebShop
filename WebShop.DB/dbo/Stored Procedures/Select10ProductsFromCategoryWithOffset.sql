CREATE PROC Select10ProductsFromCategoryWithOffset
@categoryID int,
@offset int
AS
BEGIN
	SELECT *
	FROM Products
	WHERE CategoryID = @categoryID
	ORDER BY ProductID
	OFFSET @offset ROWS
		FETCH NEXT 10 ROWS ONLY
END;