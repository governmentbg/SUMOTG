using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Obrabotki
{
    public class FakturaDTO
    {
        public int idfactura { get; set; }
        public int vidfirma { get; set; }
        public string facnomer { get; set; }
        public DateTime? facdata { get; set; }
        public int idfirma { get; set; }
        public int iddogovorfirma { get; set; }
        public List<FakturaItemDTO> fakturaitems { get; set; }
        public short status { get; set; }
        public decimal suma { get; set; }
        public decimal dds { get; set; }
        public decimal total { get; set; }
        public short broifiles { get; set; }
        public string vidpayment { get; set; }
        public string forperiod { get; set; }
    }
}
