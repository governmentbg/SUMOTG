using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class NSpisykNmn
    {
        public string KodNmn { get; set; }
        public short Status { get; set; }
        public short Faza { get; set; }
        public string Vypros { get; set; }
        public string TablicaVBazata { get; set; }
        public string Ime { get; set; }
        public string Komentar { get; set; }
    }
}
