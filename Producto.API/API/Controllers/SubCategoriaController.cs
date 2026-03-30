using Abstracciones.Interfaces.API;
using Abstracciones.Interfaces.Flujo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase,ISubCategoriaController
    {
        private ISubCategoriaFlujo _subCategoriaFlujo;
        private ILogger<ProductoController> _logger;

        public SubCategoriaController(ISubCategoriaFlujo subCategoriaFlujo, ILogger<ProductoController> logger)
        {
            _subCategoriaFlujo = subCategoriaFlujo;
            _logger = logger;
        }

        #region Operaciones

        [HttpGet("{IdCategoria}")]
        public async Task<IActionResult> Obtener([FromRoute] Guid IdCategoria)
        {
            var resultado = await _subCategoriaFlujo.Obtener(IdCategoria);
            return Ok(resultado);
        }

        #endregion       
    }
}
