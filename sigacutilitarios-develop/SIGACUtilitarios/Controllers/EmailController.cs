using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SIGACUtilitarios.DTO;
using SIGACUtilitarios.Helpers;
using SIGACUtilitarios.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SIGACUtilitarios.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {       /// <summary>
            ///  Configuracion de servidor y envio de correos
            /// </summary>
        private readonly IConfiguration configuration;


        public EmailController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost("sendAndConfEmail")]
        public async Task<ActionResult> sendAndConfEmail(ParamsCorreo correo)
        {
            try
            {
                new Email(this.configuration).sendAndConfEmail(correo);
                return Ok();
            }
            catch (Exception e)
            {
                ExceptionsHelper.guardarException(1, "sendAndConfEmail", Newtonsoft.Json.JsonConvert.SerializeObject(correo), e, MiConfigDTO.connnectionString);
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}
