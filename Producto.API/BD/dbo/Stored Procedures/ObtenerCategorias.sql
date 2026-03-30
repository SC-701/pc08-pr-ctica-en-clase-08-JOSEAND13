CREATE PROCEDURE [dbo].[ObtenerCategorias]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        Id,
        Nombre
    FROM Categorias
END