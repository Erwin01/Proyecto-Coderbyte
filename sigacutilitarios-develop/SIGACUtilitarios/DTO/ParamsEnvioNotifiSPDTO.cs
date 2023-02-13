using System;
using System.Collections.Generic;

namespace SIGACUtilitarios.DTO
{
    /// <summary>
    /// Clase uso de parametro del SP llamado : SIGACPLUS_INSERT_ENVIONOTI_SP
    /// </summary>
    public class ParamsEnvioNotifiSPDTO
    {

        public int PickNotifi { get; set; }
        public int? UsuarId { get; set; }
        public int? UsuarPersInteg { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public DateTime? FechaLectura { get; set; }
        public int Estado { get; set; }
        public string IpMaquina { get; set; }
        public string Host { get; set; }
        public long IdNotificacion { get; set; }
        public string Asunto { get; set; }
        public string Cuerpo { get; set; }
        public string Variables { get; set; }
        public string Cierre { get; set; }



        public ParamsEnvioNotifiSPDTO(int pickNotifi, int? usuarId, int? usuarPersInteg, string usuarioCreacion, DateTime fechaEnvio,
            DateTime? fechaEntrega, DateTime? fechaLectura, int estado, string ipMaquina, string host,
            long idNotificacion, string asunto, string cuerpo, string variables, string cierre)
        {
            PickNotifi = pickNotifi;
            UsuarId = usuarId;
            UsuarPersInteg = usuarPersInteg;
            UsuarioCreacion = usuarioCreacion == null ? "" : usuarioCreacion;
            FechaEnvio = fechaEnvio;
            FechaEntrega = fechaEntrega;
            FechaLectura = fechaLectura;
            Estado = estado;
            IpMaquina = ipMaquina == null ? "" : ipMaquina; 
            Host = host == null ? "" : host;
            IdNotificacion = idNotificacion;
            Asunto = asunto == null ? "" : asunto;
            Cuerpo = cuerpo == null ? "" : cuerpo;
            Variables = variables == null ? "" : variables;
            Cierre = cierre == null ? "" : cierre;
        }

        public ParamsEnvioNotifiSPDTO()
        {

        }
    }
}
