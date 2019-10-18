CREATE PROC Select24ProductsFromCategoryWithOffset
@categoryID int,
@offset int
AS
BEGIN
	SELECT *
	FROM Products
	WHERE CategoryID = @categoryID
	ORDER BY ProductID
	OFFSET @offset ROWS
		FETCH NEXT 24 ROWS ONLY
END;