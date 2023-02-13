using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGACUtilitarios.DTO
{
    /// <summary>
    /// Clase que mapea el resultado del SP llamado : SIGACPLUS_NOTIFIC_GETBYPICK_SP
    /// </summary>
    public class ResultByNotifiSPDTO
    {
        public Int64 NotifId { get; set; }
        public Int64 NotifDisigac2IdEscuela { get; set; }
        public Int64 NotifPicbaIdNotif { get; set; }
        public string NotifAsunto { get; set; }
        public string NotifCuerpo { get; set; }
        public string NotifVariables { get; set; }
        public string NotifCierre { get; set; }
        public string NotifEstado { get; set; }
        public string NombreEscuela { get; set; }

}
}
