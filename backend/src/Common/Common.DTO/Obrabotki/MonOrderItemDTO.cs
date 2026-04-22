using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Obrabotki
{
    public class MonOrderItemDTO
    {
        public int idporychkabody { get; set; }
        public int idl { get; set; }
        public string unom { get; set; }

        public int iddogovorlice { get; set; }
        public int idured { get; set; }
        public string model { get; set; }
        public int broi { get; set; }
        public DateTime? dodata { get; set; }
        public string otchas { get; set; }
        public string dochas { get; set; }
        public string note { get; set; }
        public DateTime? mondata { get; set; }
        public string protnomer { get; set; }
        public DateTime? protdata { get; set; }
        public string fabrnomer { get; set; }
        public string garkarta { get; set; }
        public DateTime? gardata { get; set; }
        public int status_g { get; set; }
        public int status_m { get; set; }
        public int status { get; set; }
        public string uredname { get; set; }
        public string ident { get; set; }
        public string ime { get; set; }
        public string vidimot { get; set; }
        public string adres { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public string snimka { get; set; }
        public string safeurl { get; set; }
        public string vidured { get; set; }
        public string raion { get; set; }
        public string note2 { get; set; }
        public string note3 { get; set; }
    }
}
