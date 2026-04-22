using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Obrabotki
{
    public class ProfOrderItemDTO
    {
        public int id { get; set; }
        public int idporychkamain { get; set; }
        public int idporychka { get; set; }
        public string unom { get; set; }
        public int idured { get; set; }
        public string nkod { get; set; }
        public int nomer { get; set; }
        public string ured { get; set; }
        public int broi { get; set; }
        public string ime { get; set; }
        public string adres { get; set; }
        public DateTime? plandata { get; set; }
        public DateTime? otchdata { get; set; }
        public int status { get; set; }
        public int status_pf { get; set; }
        public string model { get; set; }
        public string note { get; set; }
        public string status_pfstr { get; set; }
        public int idprofilaktika { get; set; }
        public string dogfirma { get; set; }
        public string namefirma { get; set; }

    }
}
