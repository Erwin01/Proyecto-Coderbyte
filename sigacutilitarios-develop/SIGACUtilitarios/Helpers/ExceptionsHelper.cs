using SIGACUtilitarios.DTO;
using SIGACUtilitarios.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGACUtilitarios.Helpers
{
    public static class ExceptionsHelper
    {
        /// <summary>
        /// Metodo encargado de guardar le excepcion generada por algun servicio
        /// </summary>
        /// <param name="esquema">Esquema en donde se guardara la excepcion</param>
        /// <param name="nombreServicio">nombre del servicioi que genera la exepcion</param>
        /// <param name="param">parametro que se le evnie al servicio si es el caso</param>
        /// <param name="e">Exception generada por el servicio</param>
        ///  <param name="e">Conexion a la base de datos</param>
        public static async void guardarException(int esquema, string nombreServicio, string param, Exception e, string conexionString)
        {
            ParamsSPDTO parametros = new ParamsSPDTO();
            parametros.parametrosString.Add("P_NOMBRESERVICIO", nombreServicio);
            parametros.parametrosString.Add("P_PARAMETRO", param);
            parametros.parametrosString.Add("P_MENSAJE", e.Message);
            parametros.parametrosString.Add("P_SEGUIMIENTOPILA", e.StackTrace);
            parametros.parametrosInt.Add("P_ESQUEMA", esquema);
            await new DBCommon().SPGenerico<Object>("SIGACPLUS_LOGERROR_INSERT_SP", parametros, conexionString);
        }

    }
}
