using System;
using System.Collections.Generic;

#nullable disable

namespace SIGACUtilitarios.Models
{
    public partial class SigacplusArchivoadjunto
    {
        public int AradjId { get; set; }
        public string AradjNombre { get; set; }
        public string AradjDescripcion { get; set; }
        public string AradjRuta { get; set; }
        public int AradjPicbaIdTabla { get; set; }
        public decimal AradjIdobjeto { get; set; }
        public string AradjEstado { get; set; }
        public string AradjUsuariocreacion { get; set; }
        public string AradjUsuariomodificacion { get; set; }
        public DateTime AradjFechacreacion { get; set; }
        public DateTime? AradjFechamodificacion { get; set; }
        public string AradjIpmaquina { get; set; }
        public string AradjHost { get; set; }
    }
}
