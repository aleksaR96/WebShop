CREATE PROC DeleteImageByProductID
@ID int
AS
BEGIN
	DELETE
	FROM Images
	WHERE ProductID = @ID
END;