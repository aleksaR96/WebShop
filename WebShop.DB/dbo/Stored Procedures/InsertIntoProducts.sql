CREATE PROC InsertIntoProducts
@Name nvarchar(30),
@Description nvarchar(2000),
@CategoryID INT,
@Price real,
@Quantity int,
@BrandID int,
@Pinned bit,
@Discount int,
@New bit,
@Popular bit
AS
BEGIN
	INSERT INTO Products(Name, Description, CategoryID, Price, Quantity, BrandID, Pinned, Discount, New, Popular)
	VALUES(@Name, @Description, @CategoryID, @Price, @Quantity, @BrandID, @Pinned, @Discount, @New, @Popular)
END;