CREATE PROCEDURE AgregarProducto
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
		INSERT INTO [dbo].[Producto]
				   ([Id]
				   ,[IdSubCategoria]
				   ,[Nombre]
				   ,[Descripcion]
				   ,[Precio]
				   ,[Stock]
				   ,[CodigoBarras])
		VALUES
			(@id,
			@idsubcategoria,
			@nombre,
			@descripcion,
			@precio,
			@stock,
			@codigoBarras                                            
			)
		SELECT @id
	COMMIT TRANSACTION
END