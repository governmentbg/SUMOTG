using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class ListAttachmentsDTO
    {
        public int id { get; set; }
        public int iddog { get; set; }
        public string description { get; set; }
        public string filename { get; set; }
        public short status { get; set; }
    }

}
