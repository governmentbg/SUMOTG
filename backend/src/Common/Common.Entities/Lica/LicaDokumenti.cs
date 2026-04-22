using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class LicaDokumenti
    {
        public int IdDok { get; set; }
        public int IdL { get; set; }
        public int DocType { get; set; }
        public string DocDescription { get; set; }
        public string FileName { get; set; }
        public string SavedFileName { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }

        public virtual Lica IdLNavigation { get; set; }
    }
}
