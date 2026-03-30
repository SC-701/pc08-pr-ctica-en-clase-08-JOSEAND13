using Abstracciones.Modelos.Servicios.TipodeCambio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Servicios
{
    public interface ITipoCambioServicio
    {
        Task<TipoCambio> Obtener (DateTime fecha);
    }

}
