CREATE PROC SelectAllPinnedDiscountProducts
AS
BEGIN
	SELECT *
	FROM Products
	WHERE Pinned = 1
		AND Discount > 0
END;