using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicios.TipodeCambio;
using System.Text.Json;

namespace Servicios
{
    public class TipoCambioServicio : ITipoCambioServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public TipoCambioServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<TipoCambio> Obtener(DateTime fecha)
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsTipoCambio", "ObtenerTipoCambio");

            var servicioTipoCambio = _httpClient.CreateClient("ServicioTipoCambio");

            var token = _configuracion.ObtenerValor("BancoCentralCR:BearerToken");
            servicioTipoCambio.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var respuesta = await servicioTipoCambio.GetAsync(string.Format(endPoint, fecha.ToString("yyyy/MM/dd")));

            respuesta.EnsureSuccessStatusCode();

            var resultado = await respuesta.Content.ReadAsStringAsync();

            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var root = JsonSerializer.Deserialize<BccrRoot>(resultado, opciones);

            var serie = root?.datos?
                .FirstOrDefault()?
                .indicadores?.FirstOrDefault()?
                .series?.FirstOrDefault();

            if (serie == null)
                throw new Exception("El BCCR no devolvió tipo de cambio para la fecha solicitada.");

            DateTime fechaSerie;
            if (!DateTime.TryParse(serie.fecha, out fechaSerie))
                fechaSerie = fecha.Date;

            return new TipoCambio
            {
                Fecha = DateTime.Parse(serie.fecha),
                Valor = Convert.ToDecimal(serie.valorDatoPorPeriodo)
            };
        }       
    }
}

