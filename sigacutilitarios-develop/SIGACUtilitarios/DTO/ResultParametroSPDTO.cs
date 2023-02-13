using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGACUtilitarios.DTO
{
    /// <summary>
    /// Clase que mapea el resultado del SP llamado : SIGACPLUS_PARAMETRO_SP
    /// </summary>
    public class ResultParametroSPDTO
    {
        public Int64 Id { get; set; }
        public Decimal Valor { get; set; }

        public string ValorTexto { get; set; }

    }
}
