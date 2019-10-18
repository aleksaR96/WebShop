CREATE PROC SelectAllPinnedNewProducts
AS
BEGIN
	SELECT *
	FROM Products
	WHERE Pinned = 1
		AND New = 1
END;