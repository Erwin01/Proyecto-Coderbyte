
using Microsoft.Extensions.Configuration;
using SIGACUtilitarios.DTO;
using SIGACUtilitarios.Helpers;
using SIGACUtilitarios.StoredProcedures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIGACUtilitarios
{
    public class EmailDto
    {
        #region Public Properties
        /// <summary>
        /// Correo de quien envía el email
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Para quien va dirigido el correo
        /// </summary>
        public List<string> To { get; set; }

        /// <summary>
        /// Para quien va dirigida la copia del correo
        /// </summary>
        public List<string> Copy { get; set; }

        /// <summary>
        /// Para quien va dirigida la copia oculta del correo
        /// </summary>
        public List<string> BlindCopy { get; set; }

        /// <summary>
        /// Titulo del texto del correo
        /// </summary>
        public string TitleEmail { get; set; }

        /// <summary>
        /// Asunto del correo
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Cuerpo del correo
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Adjuntos del correo
        /// </summary>
        public List<Attachment> Attachments = new List<Attachment>();

        /// <summary>
        /// Lista para guardar los nombres de los adjuntos agregados para el envío de correo
        /// </summary>
        public List<string> FileNameAttachments { get; set; }

        /// <summary>
        /// Usuario de autenticación con el WebService de Exchange
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Password usuario de autenticación con el WebService de Exchange
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Dominios del usuario utilizado para la autenticación con el WebService de Exchange
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// Versión del exchange
        /// </summary>
        public string ExchangeVersion { get; set; }

        /// <summary>
        /// Email de aplicacion
        /// </summary>
        public string EmailApplication { get; set; }



        /// <summary>
        /// Password del email de aplicación
        /// </summary>
        public string PassEmailApplication { get; set; }


        /// <summary>
         // Verifica si maneja host
        /// </summary>
        public bool EnviarCorreo { get; set; }


        /// <summary>
        /// correo smtp dominio
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// correo smtp dominio
        /// </summary>
        public int Port { get; set; }
        #endregion

        /// <summary>
        /// Path archivo adjunto
        /// </summary>
        public string PathAttachmentFile { get; set; }
    }

    public class Email
    {

        /// <summary>
        /// Finalidad: contiene la cadena de conexion 
        /// </summary>
        public string conectionString;

        /// <summary>
        /// Finalidad: contiene la ruta estandar donde se encuentran las imagenes para el correo
        /// </summary>
        public readonly string pathImagenes = "wwwroot\\Imagenes\\";

        /// <summary>
        /// Finalidad: contiene el nombre del archivo que va en el header parte superior izquierda
        /// </summary>
        public readonly string nameFileHeaderLogo = "escudo.PNG";


        /// <summary>
        /// Finalidad: contiene el nombre del archivo que va en el header parte superior derecha
        /// </summary>
        public readonly string nameFileHeaderLogoDer = "jobchecking-logotipo-navegacion.png";

        /// <summary>
        /// Finalidad: contiene el nombre del archivo que va en el fondo del email
        /// </summary>
        public readonly string backgroundEmail = "jobchecking-check-fondo.png";

        /// <summary>
        /// Finalidad: contiene el nombre del archivo que va en el fondo del email
        /// </summary>
        public readonly string logoJobChecking = "logo-jobchecking.png";

        /// <summary>
        /// Finalidad: contiene el nombre de la imagen de la empresa propetaria
        /// </summary>
        public string nameImageCompanyDefault = "Empresa-img";

        /// <summary>
        /// Finalidad: contiene el nombre del tipo png 
        /// </summary>
        public readonly string pngType = "png";

        /// <summary>
        /// Finalidad: contiene el nombre del tipo jpeg
        /// </summary>
        public readonly string jpegType = "jpeg";

        /// <summary>
        ///  Configuracion de servidor y envio de correos
        /// </summary>
        private readonly string sEmailAplication = "soporteredesis2017@gmail.com";
        private readonly string sPassEmailApplication = "Redesis2017";
        private readonly string shost = "smtp.gmail.com";
        private readonly int iPort = 587;

        /// <summary>
        ///  Configuracion de servidor y envio de correos
        /// </summary>
        private readonly IConfiguration configuration;


        public Email()
        {

        }
        public Email(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #region Methods
        /// <summary>
        /// Método para el envio de un correo electrónico por Smtp
        /// </summary>
        /// <param name="emailMessage">Entidad con todas las propiedades para el envio de correo electrónico</param>
        public string SendBySmtp(EmailDto emailMessage)
        {

            //Resultado
            string sresult = string.Empty;

            // Asigna inf. a objeto MailMessage
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.From = new System.Net.Mail.MailAddress(emailMessage.EmailApplication);
            // To
            if (emailMessage.To != null)
            {
                foreach (string to in emailMessage.To)
                    message.To.Add(to.Trim());
            }
            // Copy
            if (emailMessage.Copy != null)
            {
                foreach (string copy in emailMessage.Copy)
                    message.CC.Add(copy.Trim());
            }
            // BlindCopy
            if (emailMessage.BlindCopy != null)
            {
                foreach (string blindCopy in emailMessage.BlindCopy)
                    message.Bcc.Add(blindCopy.Trim());
            }
            message.Subject = emailMessage.Subject;
            message.IsBodyHtml = true;
            message.Priority = System.Net.Mail.MailPriority.Normal;

            // se agregan las imagenes para utilizarlas en el correo
            message.AlternateViews.Add(GetEmbeddedImage(nameFileHeaderLogo, "headerLogo", emailMessage.Body));


            message.Body = emailMessage.Body;

            if (emailMessage.Attachments != null)
            {
                for (int i = 0; i < emailMessage.Attachments.Count; i++)
                    message.Attachments.Add(emailMessage.Attachments[i]);
            }

            // Envía correo electrónico
            sresult = SendBySmtp(message, emailMessage.EnviarCorreo, emailMessage.Host, emailMessage.Port, emailMessage.EmailApplication, emailMessage.PassEmailApplication);
            message.AlternateViews.Dispose();
            return sresult;
        }


        /// <summary>
        /// Envia un correo electrónico con la inf. suministrada
        /// </summary>
        /// <param name="message">Inf. del correo electrónico</param>
        private string SendBySmtp(System.Net.Mail.MailMessage message, bool bEmailWithHost, string sHost, int iPort, string sEmailApplication, string sPassEmailApplication)
        {
            try
            {
                // Verifica si maneja host
                bool emailWithHost = bEmailWithHost;
                using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient())
                {
                    try
                    {
                        if (emailWithHost)
                            // correo smtp dominio
                            smtp.Host = sHost;
                        else
                        {

                            smtp.Credentials = new System.Net.NetworkCredential(sEmailApplication, sPassEmailApplication);
                            smtp.Host = sHost;

                            //correo smtp gmail
                            smtp.Port = this.iPort;
                            smtp.EnableSsl = true;
                        }
                        smtp.Send(message);
                    }
                    catch (Exception e)
                    {

                        ExceptionsHelper.guardarException(Constantes.Constantes.EsquemaBasica,
                                "SIGACUtilitarios.Email.SendBySmtp",
                                Newtonsoft.Json.JsonConvert.SerializeObject(null),
                                e, conectionString == null || conectionString == "" ? MiConfigDTO.connnectionString : conectionString);
                    }

                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                // LogExcepcion.registrarException(LogExcepcion.enumEsquema.Venta, ex.Message, ex.StackTrace, 0);
                return ex.Message;
            }
        }



        /// <summary>
        /// Finalidad: enviar correo dependiendo de una plantilla estandar del sistema
        /// </summary>
        /// <param name="paramsCorreo"></param>
        public async void sendAndConfEmail(ParamsCorreo paramsCorreo)
        {
            // inicializacion de de variables necesarias para el envio de correos
            SIGACUtilitarios.EmailDto lEmail = new SIGACUtilitarios.EmailDto();
            SIGACUtilitarios.DTO.ParamsPlantillaDTO param = new SIGACUtilitarios.DTO.ParamsPlantillaDTO();
            ResultByNotifiSPDTO notificacion = new ResultByNotifiSPDTO();
            var seccionVariables = "";
            try
            {
                var idEscuela = paramsCorreo.IdEscuela;
                if (idEscuela == null || idEscuela == 0)
                {
                    var parametro = await this.getParametroBd(Constantes.Constantes.ParamEscuelaDefecto);
                    idEscuela = (int)parametro[0].Valor;
                }
                // se consulta la parametrizacion de notificacion que se utilizara para el envio de la notificacion
                var item = await this.getNotificacionesByPickId(paramsCorreo.IdNotificacion, idEscuela);
                notificacion = item[0];
                var variables = notificacion.NotifVariables.Split("}");
                Regex regex = new Regex(@"\{([^\}]+)\}");
                // escritura de parametros o variables de la notificacion
                var index = 0;
                if (paramsCorreo.variables != null)
                {
                    foreach (var itemParam in paramsCorreo.variables)
                    {
                        seccionVariables = seccionVariables + regex.Replace(variables[index] + "}", itemParam) + "<br>";
                        index = index + 1;
                    }
                }

            }
            catch (Exception e)
            {

                ExceptionsHelper.guardarException(Constantes.Constantes.EsquemaBasica,
                    "SIGACUtilitarios.Email.sendAndConfEmail",
                    Newtonsoft.Json.JsonConvert.SerializeObject(paramsCorreo),
                    e, conectionString == null || conectionString == "" ? MiConfigDTO.connnectionString : conectionString);
            }

            string smessage = string.Empty;
            string smessageBody = string.Empty;

            // se parametriza las propiedades del email propiamente
            bool bEnviarCorreo = false;
            lEmail.EmailApplication = sEmailAplication;
            lEmail.EnviarCorreo = bEnviarCorreo;
            lEmail.PassEmailApplication = sPassEmailApplication;
            lEmail.Host = shost;
            lEmail.Port = iPort;
            lEmail.To = paramsCorreo.ToCorreos;
            lEmail.Subject = notificacion.NotifAsunto;
            lEmail.TitleEmail = notificacion.NotifAsunto;

            // se parametriza todo lo relacionado con el cuerpo del email
            param.Titulo = lEmail.TitleEmail;
            param.Mensaje = notificacion.NotifCuerpo + " <br><br>" + seccionVariables + " <br><br>" + notificacion.NotifCierre + " <br><br>";
            param.PaginaWeb = "https://www.policia.gov.co/escuelas/general-santander";
            param.Email = sEmailAplication;
            param.Direccion = "Cl. 45a Sur #47a-42, Bogotá";
            param.Plantilla = Plantillas.PlantillasCorreo.PlantillaEstandar;
            lEmail.Body = new SIGACUtilitarios.Email().writeParamsPlantilla(param);

            // Se obtiene todos los adjuntos parametrizados en la notificacion
            var adjuntos = await getAdjuntosPickTablaObjeto((decimal)notificacion.NotifId,
                Constantes.Constantes.PickTablaNotificacion);

            // se adjuntan todos los archivos parametrizados para la notificacion
            foreach (var adjunto in adjuntos)
            {
                var atac = new Attachment(MiConfigDTO.pathAdjuntos + adjunto.Ruta);
                lEmail.Attachments.Add(atac);
            }
            try
            {
                foreach (var item in lEmail.To)
                {
                    // obtener remitente
                    var itemFrom = await this.getParametroBd(Constantes.Constantes.ParamRemitente);
                    ParamsSPDTO paramsSPDTO = new ParamsSPDTO();
                    paramsSPDTO.parametrosString.Add("P_FROM", itemFrom[0].ValorTexto);
                    paramsSPDTO.parametrosString.Add("P_EMPLOYE", item);
                    paramsSPDTO.parametrosString.Add("P_SUBJECT", lEmail.Subject);
                    paramsSPDTO.parametrosString.Add("P_BODY_MAIL", lEmail.Body);
                    paramsSPDTO.parametrosString.Add("P_STATUS", "");
                    paramsSPDTO.parametrosString.Add("P_ERROR", "");
                    paramsSPDTO.cursor = "P_CURSOR";
                    await new DBCommon().SPGenerico<dynamic>("SIGACPLUS_INTEGRAC_EMAIL_SP", paramsSPDTO, conectionString == null || conectionString == "" ? MiConfigDTO.connnectionString : conectionString);
                }
                //new SIGACUtilitarios.Email().SendBySmtp(lEmail);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                throw;
            }
            // Envia correo

            // se consultan los usuarios que se les envio una notificacion
            var enviosUsuarios = await getUsuarioPorCorreo(paramsCorreo.ToCorreos);
            try
            {
                // recorre los usuarios se debe realizar un registro por cada uno 
                foreach (var usuar in enviosUsuarios)
                {
                    // registro en el historial de envios
                    this.guardarHistorialEnvioCorreo(
                        new ParamsEnvioNotifiSPDTO(paramsCorreo.IdNotificacion,
                        usuar.UsuarioExterno == Constantes.Constantes.EstadoActivo ? (int?)usuar.IdUsuario : null,
                         usuar.UsuarioExterno == Constantes.Constantes.EstadoInactivo ? (int?)usuar.IdUsuario : null,
                        paramsCorreo.NombreUsuario, DateTime.Now, null,
                        null, Constantes.Constantes.EstadoEnviado, paramsCorreo.IpMaquina, paramsCorreo.Host,
                        notificacion.NotifId, notificacion.NotifAsunto, notificacion.NotifCuerpo,
                        seccionVariables, notificacion.NotifCierre
                        ));
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }



        /// <summary>
        /// Finalidad: agregar todos los parametros y datos necesarios a la plantilla
        /// </summary>
        /// <param name="plantillaDto"></param>
        /// <returns></returns>
        public string writeParamsPlantilla(DTO.ParamsPlantillaDTO plantillaDto)
        {
            plantillaDto.Plantilla = plantillaDto.Plantilla.Replace("$TITULO1", plantillaDto.Titulo) == null ? "" : plantillaDto.Plantilla.Replace("$TITULO1", plantillaDto.Titulo);
            plantillaDto.Plantilla = plantillaDto.Plantilla.Replace("$Mensaje", plantillaDto.Mensaje) == null ? "" : plantillaDto.Plantilla.Replace("$Mensaje", plantillaDto.Mensaje);
            plantillaDto.Plantilla = plantillaDto.Plantilla.Replace("$paginaWeb", plantillaDto.PaginaWeb) == null ? "" : plantillaDto.Plantilla.Replace("$paginaWeb", plantillaDto.PaginaWeb);
            plantillaDto.Plantilla = plantillaDto.Plantilla.Replace("$email", plantillaDto.Email) == null ? "" : plantillaDto.Plantilla.Replace("$email", plantillaDto.Email);
            plantillaDto.Plantilla = plantillaDto.Plantilla.Replace("$direccion", plantillaDto.Direccion) == null ? "" : plantillaDto.Plantilla.Replace("$direccion", plantillaDto.Direccion);


            return plantillaDto.Plantilla;
        }


        /// <summary>
        /// Finalidad poner las imagenes como recursos del correo para poder llamarlas en la plantilla html
        /// </summary>
        /// <param name="nameFile">nombre de la imagen </param>
        /// <param name="id">id de como se encuentra el cid en el html</param>
        /// <param name="plantilla">plantilla de correo</param>
        /// <returns></returns>
        private AlternateView GetEmbeddedImage(String nameFile, String id, string plantilla)
        {
            string directory = Environment.CurrentDirectory;
            var imagen = Path.Combine(directory, pathImagenes + nameFile);
            LinkedResource res = new LinkedResource(imagen);
            res.ContentId = id;
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(plantilla, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }


        /// <summary>
        /// Finalidad: remover un archivo del wwwroot/imagenes 
        /// </summary>
        /// <param name="fileName"></param>
        private void removeFile(string fileName)
        {
            try
            {
                string directory = Environment.CurrentDirectory;
                var imagen = Path.Combine(directory, pathImagenes + fileName + "." + jpegType);
                var imagenpng = Path.Combine(directory, pathImagenes + fileName + "." + pngType);
                if (File.Exists(imagen))
                {
                    File.Delete(imagen);
                }
                else if (File.Exists(imagenpng))
                {
                    File.Delete(imagenpng);
                }
            }
            catch (Exception e)
            {
                var m = e.Message;
            }

        }


        /// <summary>
        /// Finalidad: Obtener una notificion por el pick notificacion
        /// </summary>
        /// <param name="IdPickNotificacion"></param>
        public async Task<List<ResultByNotifiSPDTO>> getNotificacionesByPickId(int IdPickNotificacion, int? IdEscuela)
        {
            ParamsSPDTO paramsSPDTO = new ParamsSPDTO();
            paramsSPDTO.parametrosInt.Add("P_PICK_NOTIFICACION", IdPickNotificacion);
            paramsSPDTO.parametrosIntNull.Add("P_ESCUELA", IdEscuela);
            paramsSPDTO.cursor = "NOTIF_CURSOR";
            return await new DBCommon().SPGenerico<ResultByNotifiSPDTO>("SIGACPLUS_INTEGRAC_NOTIPIC_SP", paramsSPDTO, conectionString == null || conectionString == "" ? MiConfigDTO.connnectionString : conectionString);
        }

        /// <summary>
        /// Finalidad: Obtener el cualquier parametro por codigo
        /// </summary>
        /// <param name="codigo">codigo para filtrar el parametro</param>
        public async Task<List<ResultParametroSPDTO>> getParametroBd(string codigo)
        {
            ParamsSPDTO paramsSPDTO = new ParamsSPDTO();
            paramsSPDTO.parametrosString.Add("P_CODIGO", codigo);
            paramsSPDTO.cursor = "P_CURSOR";
            return await new DBCommon().SPGenerico<ResultParametroSPDTO>("SIGACPLUS_PARAMETRO_SP", paramsSPDTO, conectionString == null || conectionString == "" ? MiConfigDTO.connnectionString : conectionString);
        }

        /// <summary>
        /// Finalidad: Obtener adjuntos por picktabla y por pickobjeto
        /// </summary>
        /// <param name="idObjeto"></param>
        /// <param name="pickTabla"></param>
        public async Task<List<ResultAdjuntosSPDTO>> getAdjuntosPickTablaObjeto(Decimal idObjeto, int pickTabla)
        {
            try
            {
                ParamsSPDTO paramsSPDTO = new ParamsSPDTO();
                paramsSPDTO.parametrosInt.Add("P_PICK_TABLA", pickTabla);
                paramsSPDTO.parametrosDecimal.Add("P_PICK_OBJETO", idObjeto);
                paramsSPDTO.cursor = "P_CURSOR";
                return await new DBCommon().SPGenerico<ResultAdjuntosSPDTO>("SIGACPLUS_ADJUNTOS_OBJTABLA_SP", paramsSPDTO, conectionString == null || conectionString == "" ? MiConfigDTO.connnectionString : conectionString);
            }
            catch (Exception e)
            {
                var obj = new { idObjeto, pickTabla };
                ExceptionsHelper.guardarException(Constantes.Constantes.EsquemaBasica,
                    "SIGACUtilitarios.Email.getAdjuntosPickTablaObjeto",
                    Newtonsoft.Json.JsonConvert.SerializeObject(obj),
                    e, conectionString == null || conectionString == "" ? MiConfigDTO.connnectionString : conectionString);
                return new List<ResultAdjuntosSPDTO>();
            }
        }
        #endregion

        /// <summary>
        /// Finalidad: usuarios por correo 
        /// </summary>
        /// <param name="correo"></param>
        public async Task<List<ResultUsuSPDTO>> getUsuarioPorCorreo(List<string> correos)
        {
            List<ResultUsuSPDTO> usuarios = new List<ResultUsuSPDTO>();
            try
            {
                foreach (var item in correos)
                {
                    ParamsSPDTO paramsSPDTO = new ParamsSPDTO();
                    paramsSPDTO.parametrosString.Add("P_USUARIO", item);
                    paramsSPDTO.parametrosString.Add("P_NUMERODOCUMENTO", null);
                    paramsSPDTO.parametrosIntNull.Add("P_TIPODOCUMENTO", null);
                    paramsSPDTO.cursor = "USUARIO_CURSOR";
                    var usuario = await new DBCommon().SPGenerico<ResultUsuSPDTO>("SIGACPLUS_USUARIO_BUSCAR_SP", paramsSPDTO, conectionString == null || conectionString == "" ? MiConfigDTO.connnectionString : conectionString);
                    if (usuario != null && usuario.Count != 0)
                    {
                        usuarios.Add(usuario[0]);
                    }
                }
                return usuarios;
            }
            catch (Exception e)
            {
                ExceptionsHelper.guardarException(Constantes.Constantes.EsquemaBasica,
                            "SIGACUtilitarios.Email.getUsuarioPorCorreo",
                            Newtonsoft.Json.JsonConvert.SerializeObject(correos),
                            e, conectionString == null || conectionString == "" ? MiConfigDTO.connnectionString : conectionString);
                return usuarios;
            }
        }

        /// <summary>
        /// Finalidad: usuarios por correo 
        /// </summary>
        /// <param name="correo"></param>
        public async void guardarHistorialEnvioCorreo(ParamsEnvioNotifiSPDTO paramNotific)
        {
            try
            {
                ParamsSPDTO paramsSPDTO = new ParamsSPDTO();
                paramsSPDTO.parametrosString.Add("P_IPMAQUINA", paramNotific.IpMaquina);
                paramsSPDTO.parametrosString.Add("P_HOST", paramNotific.Host);
                paramsSPDTO.parametrosString.Add("P_USUARIO_CREACION", paramNotific.UsuarioCreacion);
                paramsSPDTO.parametrosString.Add("P_ASUNTO", paramNotific.Asunto);
                paramsSPDTO.parametrosString.Add("P_CUERPO", paramNotific.Cuerpo);
                paramsSPDTO.parametrosString.Add("P_VARIABLES", paramNotific.Variables);
                paramsSPDTO.parametrosString.Add("P_CIERRE", paramNotific.Cierre);
                paramsSPDTO.parametrosInt.Add("P_ID_NOTIFI", (int)paramNotific.IdNotificacion);
                paramsSPDTO.parametrosInt.Add("P_ESTADO", paramNotific.Estado);
                paramsSPDTO.parametrosIntNull.Add("P_PERS", paramNotific.UsuarPersInteg);
                paramsSPDTO.parametrosIntNull.Add("P_USUARIO_ID", paramNotific.UsuarId);
                paramsSPDTO.parametrosDate.Add("P_FECHA_ENVIO", paramNotific.FechaEnvio);
                paramsSPDTO.parametrosDateNull.Add("P_FECHA_ENTREGA", paramNotific.FechaEntrega);
                paramsSPDTO.parametrosDateNull.Add("P_FECHA_LECTURA", paramNotific.FechaLectura);


                var usuario = await new DBCommon().SPGenerico<ResultUsuSPDTO>("SIGACPLUS_INSERT_ENVIONOTI_SP", paramsSPDTO, conectionString == null || conectionString == "" ? MiConfigDTO.connnectionString : conectionString);
            }
            catch (Exception e)
            {
                ExceptionsHelper.guardarException(Constantes.Constantes.EsquemaBasica,
                            "SIGACUtilitarios.Email.guardarHistorialEnvioCorreo",
                            Newtonsoft.Json.JsonConvert.SerializeObject(paramNotific),
                            e, conectionString == null || conectionString == "" ? MiConfigDTO.connnectionString : conectionString);
            }
        }
    }
}

