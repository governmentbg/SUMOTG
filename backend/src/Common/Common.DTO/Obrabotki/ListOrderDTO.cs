using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Obrabotki
{
    public class ListOrderDTO
    {
        public int idporychka { get; set; }
        public int nomer { get; set; }
        public int faza { get; set; }
        public DateTime? data { get; set; }
        public int idfirma { get; set; }
        public string eik { get; set; }
        public string ime { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public string dogovor { get; set; }
        public string statusPM { get; set; }
        public short status { get; set; }
        public string note { get; set; }
        public int spm { get; set; }

    }
}
