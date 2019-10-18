CREATE PROC SelectAllPinnedPopularProducts
AS
BEGIN
	SELECT *
	FROM Products
	WHERE Pinned = 1
		AND Popular = 1
END;