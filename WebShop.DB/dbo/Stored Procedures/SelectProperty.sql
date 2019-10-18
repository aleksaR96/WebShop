CREATE PROC SelectProperty
@ID int
AS
BEGIN
	SELECT *
	FROM Properties
	WHERE ID = @ID
END;