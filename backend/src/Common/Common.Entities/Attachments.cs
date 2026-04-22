using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class Attachments
    {
        public int Id { get; set; }
        public int IdDog { get; set; }
        public int DocType { get; set; }
        public string DocDescription { get; set; }
        public string FileName { get; set; }
        public string SavedFileName { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }

    }
}
