using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Spravki
{
    public class Spravka70DTO
    {
        public string raion { get; set; }
        public string unom { get; set; }
        public string ime { get; set; }
        public string adres { get; set; }
        public string ured { get; set; }
        public int srok { get; set; }
        public DateTime? data { get; set; }
        public int idporychka { get; set; }
        public string dogfirma { get; set; }
    }
}
