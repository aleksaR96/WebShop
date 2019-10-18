CREATE PROC SelectImageByProductID
@ID int
AS
BEGIN
	SELECT *
	FROM Images
	WHERE ProductID = @ID
END;