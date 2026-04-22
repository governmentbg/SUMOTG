using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Firmi
{
    public class FirmaIzpalnitelDTO
    {
        public int idfirma { get; set; }
        public string eik { get; set; }
        public string ime { get; set; }
        public int iddog { get; set; }
        public string regnomer { get; set; }
        public DateTime? dataregnom { get; set; }
        public string statusdm { get; set; }
        public string statusur { get; set; }
    }
}
