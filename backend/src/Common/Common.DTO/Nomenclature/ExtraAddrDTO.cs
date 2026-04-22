using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Nomenclature
{
    public class ExtraAddrDTO
    {
        public int id { get; set; }
        public int tip { get; set; }
        public string admRaion { get; set; }
        public string nasMqsto { get; set; }
        public string kvartal { get; set; }
        public string jk { get; set; }
        public string ulica { get; set; }
        public string nomer { get; set; }
        public string blok { get; set; }
        public string vhod { get; set; }
        public string etaj { get; set; }
        public string apart { get; set; }
        public string postKode { get; set; }
        public short status { get; set; }
    }
}
