CREATE PROC UpdateImage
@ID int,
@ProductID int,
@Image nvarchar(50)
AS
BEGIN
	UPDATE Images
	SET
		ProductID = @ProductID,
		Image = @Image
	WHERE
		ImageID = @ID
END;