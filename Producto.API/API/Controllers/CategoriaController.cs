using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos;
using Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase, ICategoriaController
    {
        private ICategoriaFlujo _categoriaFlujo;
        private ILogger<ProductoController> _logger;

        public CategoriaController(ICategoriaFlujo categoriaFlujo, ILogger<ProductoController> logger)
        {
            _categoriaFlujo = categoriaFlujo;
            _logger = logger;
        }

        #region Operaciones

        [HttpGet]
        public async Task<IActionResult> Obtener()
        {
            var resultado = await _categoriaFlujo.Obtener();

            if (!resultado.Any())
            {
                return NoContent();
            }

            return Ok(resultado);
        }
      
        #endregion
    }
}
