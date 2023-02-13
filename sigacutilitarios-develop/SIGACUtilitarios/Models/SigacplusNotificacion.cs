using System;
using System.Collections.Generic;

#nullable disable

namespace SIGACUtilitarios.Models
{
    public partial class SigacplusNotificacion
    {
        public int NotifId { get; set; }
        public int NotifDisigac2IdEscuela { get; set; }
        public int NotifPicbaIdNotif { get; set; }
        public string NotifAsunto { get; set; }
        public string NotifCuerpo { get; set; }
        public string NotifVariables { get; set; }
        public string NotifCierre { get; set; }
        public string NotifEstado { get; set; }
        public string NotifUsuariocreacion { get; set; }
        public string NotifUsuariomodificacion { get; set; }
        public DateTime NotifFechacreacion { get; set; }
        public DateTime? NotifFechamodificacion { get; set; }
        public string NotifIpmaquina { get; set; }
        public string NotifHost { get; set; }
    }
}
