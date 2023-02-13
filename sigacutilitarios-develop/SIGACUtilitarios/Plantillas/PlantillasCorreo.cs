using System;
using System.Collections.Generic;
using System.Text;

namespace SIGACUtilitarios.Plantillas
{
    public static class PlantillasCorreo
    {
        // ejemplo de utilizacion imagen adjunta <img style=""width:100%;"" src=""cid:headerLogo"" /> 
        //footer que tenia la plantilla: 
        //    <footer>
        //    <div style = ""font-family: Arial, Helvetica, sans-serif; info-empresa margin-left: 20px;"" >
               
        //        <div>
                    
        //             <div>
        //                 <label style = ""font-weight: bold;"">Escuela de Cadetes General Santander</label><br />
        //                 <label>DIRECCION: Cl. 45a Sur #47a-42, Bogotá</label><br />
        //                 <label>E-mail: SoportePrueba @gmail.com</label><br />
        //                 <label>Pagina Web: https://www.policia.gov.co/escuelas/general-santander </label>
        //               </div>
        //         </div>
                
        //    </div>
            
        //    </footer>
        public static readonly string PlantillaEstandar = @"
    <div style="" width: 100%; height: 70px;"">            
            <div >
               

            </div>

    </div>
            <div style="" text-align: center; margin-top:100px; margin-bottom:70px; "">
                <div style=""text-align:center; "" >
	                <h1 style = ""display: block; font-family:EurostileBold;font-size: 250%; color:#116A80; "">$TITULO1</h1>
	                <div style = "" font-family:Montserrat;font-size: 200%;color:gray; text-align: justify; "" >
		                $Mensaje
                    </div>
                </div>
            </div>
            ";

    }
}
