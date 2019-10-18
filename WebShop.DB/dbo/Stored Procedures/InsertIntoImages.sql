CREATE PROC InsertIntoImages
@ProductID int,
@Image nvarchar(50)
AS
BEGIN
	INSERT INTO Images
	(
		ProductID,
		Image
	)
	VALUES
	(
		@ProductID,
		@Image
	)
END;