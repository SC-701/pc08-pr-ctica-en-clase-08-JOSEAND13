CREATE PROCEDURE ObtenerProducto
	-- Add the parameters for the stored procedure here	
	@id uniqueidentifier

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
SELECT Producto.Id, Producto.IdSubCategoria, Producto.Nombre, Producto.Descripcion, Producto.Precio, Producto.Stock, Producto.CodigoBarras, Categorias.Nombre AS categoria, SubCategorias.Nombre AS subCategoria
FROM     Producto INNER JOIN
                  SubCategorias ON Producto.IdSubCategoria = SubCategorias.Id INNER JOIN
                  Categorias ON SubCategorias.IdCategoria = Categorias.Id 
WHERE  (Producto.Id = @id)
END