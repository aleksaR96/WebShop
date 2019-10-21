CREATE PROC SelectPropertyByPropertyID
@PropertyID int
AS
BEGIN
	SELECT *
	FROM PropertyList
	WHERE
		ID = @PropertyID
END;