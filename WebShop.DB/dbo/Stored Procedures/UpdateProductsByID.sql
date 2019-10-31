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
@Popular bit,
@EAN int
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
		Popular = @Popular,
		EAN = @EAN
	WHERE 
		ProductID = @ID
END;