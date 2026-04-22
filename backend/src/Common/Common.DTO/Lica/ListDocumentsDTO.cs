using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Lica
{
    public class ListDocumentsDTO
    {
        public int iddoc { get; set; }
        public int idL { get; set; }
        public string id { get; set; }
        public string nime { get; set; }
        public string description { get; set; }
        public short status { get; set; }
        public string filename { get; set; }
    }
}
