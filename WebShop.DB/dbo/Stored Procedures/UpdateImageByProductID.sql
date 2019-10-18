CREATE PROC UpdateImageByProductID
@ID int,
@ProductID int,
@Image nvarchar(50)
AS
BEGIN
	UPDATE Images
	SET
		Image = @Image
	WHERE
		ImageID = @ID
		AND
		ProductID = @ProductID
END;