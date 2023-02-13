using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGACUtilitarios.DTO
{
    /// <summary>
    /// Clase que mapea el resultado del SP llamado : SIGACPLUS_USUARIO_BUSCAR_SP
    /// </summary>
    public class ResultUsuSPDTO
    {
        public Int64 PickTipoDocumento { get; set; }
        public Int64 IdUsuario { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaExpedicion { get; set; }
        public string CorreoPersonal { get; set; }
        public string UsuarioExterno { get; set; }
        public string EstadoUsuario { get; set; }
        public decimal IdEscuela { get; set; }
        public string NombreEscuela { get; set; }
        public string Sigla { get; set; }
        public string Cargo { get; set; }
        public string Grado { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreUsuario { get; set; }

    }
}
