CREATE PROC SelectPropertyValuesByPropertyID
@PropertyID int
AS
BEGIN
	SELECT *
	FROM PropertyValues
	WHERE PropertyID = @PropertyID
END;