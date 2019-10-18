CREATE PROC SelectOneProductFromCategoryWithOffset
@categoryID int,
@offset int
AS
BEGIN
	SELECT *
	FROM Products
	WHERE CategoryID = @categoryID
	ORDER BY ProductID
	OFFSET @offset ROWS
		FETCH NEXT 1 ROWS ONLY
END;