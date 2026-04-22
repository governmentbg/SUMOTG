using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Obrabotki
{
    public class OrderDTO
    {
        public int idporychkamain { get; set; }
        public int nomer { get; set; }
        public DateTime? data { get; set; }
        public int idfirma { get; set; }
        public int iddogovorfirma { get; set; }
        public string raion { get; set; }
        public int faza { get; set; }
        public List<MonOrderItemDTO> porychkaitems { get; set; }
        public short status { get; set; }
        public short status_pm { get; set; }
        public DateTime? startdata { get; set; }
        public DateTime? enddata { get; set; }
        public List<UrediDogovorDTO> uredi { get; set; }
        public string note { get; set; }
        public int idmonporychka { get; set; }

    }
}
