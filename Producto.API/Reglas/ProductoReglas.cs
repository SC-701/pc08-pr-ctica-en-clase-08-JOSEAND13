using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;

namespace Reglas
{
    public class ProductoReglas : IProductoReglas
    {
        private readonly ITipoCambioServicio _tipoCambioServicio;
        private readonly IConfiguracion _configuracion;

        public ProductoReglas(ITipoCambioServicio tipoCambioServicio, IConfiguracion configuracion)
        {
            _tipoCambioServicio = tipoCambioServicio;
            _configuracion = configuracion;
        }

        public async Task<decimal> CalcularPrecioUsd (decimal precioCrc)
        {
            var resultadoTipoCambio = await _tipoCambioServicio.Obtener(DateTime.Now);

            if (resultadoTipoCambio == null || resultadoTipoCambio.Valor <= 0)
                throw new Exception("No se pudo obtener el tipo de cambio.");

            var precioUsd = precioCrc / resultadoTipoCambio.Valor;

            return Math.Round(precioUsd, 2, MidpointRounding.AwayFromZero);
        }
    }
}
