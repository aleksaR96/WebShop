CREATE PROC UpdateProductsByID
@ID int,
@Name nvarchar(30),
@Description nvarchar(2000),
@CategoryID int,
@Price real,
@Quantity int,
@BrandID int,
@Pinned bit,
@Discount int,
@New bit,
@Popular bit
AS
BEGIN
	
	UPDATE Products
	SET
		Name = @Name,
		Description = @Description,
		CategoryID = @CategoryID,
		Price = @Price,
		Quantity = @Quantity,
		BrandID = @BrandID,
		Pinned = @Pinned,
		Discount = @Discount,
		New = @New,
		Popular = @Popular
	WHERE 
		ProductID = @ID
END;