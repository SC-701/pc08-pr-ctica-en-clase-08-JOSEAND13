using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos
{
    public class ProductoBase
    {
        [Required(ErrorMessage = "La propiedad nombre es requerida")]
        [StringLength(15, ErrorMessage = "La propiedad nombre debe ser mayor a 15 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La propiedad descripción es requerida")]
        [StringLength(40, ErrorMessage = "La propiedad nombre debe ser mayor a 4 caracteres y menos de 40", MinimumLength = 4)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La propiedad precio es requerida")]
        [Range(0.01, 1000000, ErrorMessage = "El precio debe ser mayor a 0 y no mayor a 1000000")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La propiedad stock es requerida")]
        [Range(0, 10000, ErrorMessage = "El stock no puede ser un número negativo")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La propiedad código de barras es requerida")]
        [RegularExpression(@"^(?:\d{8}|\d{12}|\d{13})$", ErrorMessage = "Debe ser EAN-8 (8), UPC-A (12) o EAN-13 (13) dígitos.")]
        public string CodigoBarras { get; set; }
    }

    public class ProductoRequest : ProductoBase
    {
        public Guid IdSubCategoria { get; set; }
    }

    public class ProductoResponse : ProductoBase
    {
        public Guid Id { get; set; }
        public string? SubCategoria { get; set; }
        public string? Categoria { get; set; }
    }

    public class ProductoDetalle : ProductoResponse
    {
        public decimal PrecioUSD { get; set; }
    }
}
