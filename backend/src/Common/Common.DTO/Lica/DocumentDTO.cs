using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class DocumentDTO
    {
        public int id { get; set; }
        public int iddog { get; set; }
        public int doctype { get; set; }
        public string text { get; set; }
        public string filename { get; set; }
        public string savedfilename { get; set; }
        public short statusDD { get; set; }
        public short status { get; set; }
    }
}
