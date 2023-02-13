using System.Collections.Generic;

namespace SIGACUtilitarios.DTO
{
    public class ParamsCorreo
    {
        /// <summary>
        /// Correos a los que se les va a enviar la notificacion
        /// </summary>
        public List<string> ToCorreos { get; set; }
        /// <summary>
        /// Variables parametrizadas en la notificacion
        /// </summary>
        public List<string> variables { get; set; }
        /// <summary>
        /// Notificacion base que ya fue parametrizada para el envio de correo
        /// </summary>
        public int IdNotificacion { get; set; }

        /// <summary>
        /// Id de la escuela a la cual se parametrizo la notificacio
        /// </summary>
        public int? IdEscuela { get; set; }

        /// <summary>
        /// Id del usuario de creacion (el que disparo la notificacion)
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Ip de la maquina del usuario que disparon la notificacion
        /// </summary>
        public string IpMaquina { get; set; }

        /// <summary>
        /// Host de la maquina del usuario que disparon la notificacion
        /// </summary>
        public string Host { get; set; }


    }
}
