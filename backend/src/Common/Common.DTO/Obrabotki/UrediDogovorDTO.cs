using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Obrabotki
{
    public class UrediDogovorDTO
    {
        public int idspdost { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public decimal edcena { get; set; }
        public int broi { get; set; }
        public int maxbroi { get; set; }
        public int broiporychani { get; set; }
        public string vidured { get; set; }


    }
}
