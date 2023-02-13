using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGACUtilitarios.DTO
{
    public static class MiConfigDTO
    {
        /// <summary>
        /// Conexion a base de datos contenida en el appsettings
        /// </summary>
        public static string connnectionString { get; set; }
        /// <summary>
        /// Esquema de la base de datos contenida en el appsettings
        /// </summary>
        public static string Esquema { get; set; }
        /// <summary>
        ///  Definir si  es ambiente de redesis
        /// </summary>
        public static string EsAmbienteRedesis { get; set; }
        /// <summary>
        /// Primera anotacion que debera ser configurada en el dbcontext
        /// </summary>
        public static string HasAnnotation { get; set; }
        /// <summary>
        /// Segunda anotacion que debera ser configurada en el dbcontext
        /// </summary>
        public static string HasAnnotationTwo { get; set; }
        /// <summary>
        /// runta donde se encuentra el wwwroot de basica para acceso de adjuntos la ruta esta en el appsetting
        /// </summary>
        public static string pathAdjuntos { get; set; }
    }
}
