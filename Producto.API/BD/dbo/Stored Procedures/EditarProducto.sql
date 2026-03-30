CREATE PROCEDURE EditarProducto
	-- Add the parameters for the stored procedure here	
	@id as uniqueidentifier,
	@idsubcategoria as uniqueidentifier,
	@nombre as varchar(max),
	@descripcion varchar(max),
	@precio as decimal (18,0),
	@stock as int,
	@codigoBarras as varchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	BEGIN TRANSACTION
		UPDATE [dbo].[Producto]
			SET [IdSubCategoria] = @idsubcategoria
				,[Nombre] = @nombre
				,[Descripcion] = @descripcion
				,[Precio] = @precio
				,[Stock] = @stock
				,[CodigoBarras] = @codigoBarras
			 WHERE Id = @id
		SELECT @id
 COMMIT TRANSACTION
END