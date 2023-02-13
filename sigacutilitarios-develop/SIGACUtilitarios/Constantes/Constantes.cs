using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGACUtilitarios.Constantes
{
    public static class Constantes
    {
        /// <summary>
        /// ****************** Esquemas de la base de datos
        /// </summary>
        public static int EsquemaBasica = 1;
        public static int EsquemaDisCurricular = 2;
        public static int EsquemaDocente = 3;
        public static int EsquemaTesoreria = 4;
        public static int EsquemaGrado = 5;
        public static int EsquemaAcademica = 6;
        public static int EsquemaBeca = 7;
        public static int EsquemaEstudiante = 8;

        public static string EstadoActivo = "S";
        public static string EstadoInactivo = "N";
        public static string keyPsw = "S1G4CV2";

        public static string ErrorInternoServidor = "Ocurrió un error interno en el servidor";

        /// <summary>
        /// ****************** Estados de una notificacion
        /// </summary>
        public static int EstadoEnviado = 82;
        public static int EstadoEntregado = 83;
        public static int EstadoLeido = 84;




        /// <summary>
        /// ****************** PICKTablas
        /// </summary>
        public static int PickTablaNotificacion = 70;

        /// <summary>
        /// ****************** Codigo del parametro escuela por defecto 
        /// </summary>
        public static string ParamEscuelaDefecto = "ESCUELAPORDEFECTO";

        /// <summary>
        /// ****************** Codigo del parametro remitente 
        /// </summary>
        public static string ParamRemitente = "CORREOREMITENTE";

        /// <summary>
        /// ****************** Codigo del parametro mensaje de error 
        /// </summary>
        public static string ParamMensajeError = "MENSAJEERROR";

        /// <summary>
        /// ****************** codigo cuando el servicio RNEC responde exitosamente 
        /// </summary>
        public static int CodigoExitosoRNEC = 4;
    }
}
