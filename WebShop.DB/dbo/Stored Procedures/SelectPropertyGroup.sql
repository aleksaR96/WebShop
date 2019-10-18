CREATE PROC SelectPropertyGroup
@ID int
AS
BEGIN
	SELECT *
	FROM PropertyGruops
	WHERE GroupID = @ID
END;