using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Spravki
{
    public class Spravka50DTO
    {
        public int idured { get; set; }
        public string ured { get; set; }
        public decimal price { get; set; }
        public int broi { get; set; }
        public decimal budget { get; set; }
        public decimal calcbudget { get; set; }
        public decimal procbudget { get; set; }
    }
}
