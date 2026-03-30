CREATE PROCEDURE [dbo].[ObtenerSubCategorias]
    @IdCategoria UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        SubCategorias.Id,
        SubCategorias.IdCategoria,
        SubCategorias.Nombre
    FROM SubCategorias
    WHERE SubCategorias.IdCategoria = @IdCategoria
END