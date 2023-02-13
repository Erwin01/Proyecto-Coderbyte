using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGACUtilitarios.DTO
{
    /// <summary>
    /// Clase que mapea el resultado del SP llamado : SIGACPLUS_ADJUNTOS_OBJTABLA_SP
    /// </summary>
    public class ResultAdjuntosSPDTO
    {

        public Int64 IdAdjunto { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string Host { get; set; }
        public decimal IdObjeto { get; set; }
        public string IdMaquina { get; set; }
        public string Nombre { get; set; }
        public Int64 PickTabla { get; set; }
        public string Ruta { get; set; }

        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
