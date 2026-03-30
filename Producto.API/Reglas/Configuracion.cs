using Microsoft.Extensions.Configuration;
using Abstracciones.Modelos.Servicios;
using Abstracciones.Interfaces.Reglas;

namespace Reglas
{
    public class Configuracion : IConfiguracion
    {
        private IConfiguration _configuration;

        public Configuracion(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ObtenerMetodo(string seccion, string nombre)
        {
            string? UrlBase = ObtenerUrlBase(seccion);

            var Metodo = _configuration.GetSection(seccion).Get<APIEndPoint>
                ().Metodos.Where(m => m.Nombre == nombre).FirstOrDefault().Valor;

            return $"{UrlBase}/{Metodo}";
        }

        public string ObtenerValor(string llave)
        {
            return _configuration.GetSection(llave).Value;
        }

        private string? ObtenerUrlBase(string seccion)
        {
            return _configuration.GetSection(seccion).Get<APIEndPoint>().UrlBase;
        }
    }
}
