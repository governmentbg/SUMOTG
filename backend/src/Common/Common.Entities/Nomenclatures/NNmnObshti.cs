using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class NNmnObshti
    {
        public int IdKn { get; set; }
        public short Status { get; set; }
        public short Faza { get; set; }
        public string Vypros { get; set; }
        public string KodNmn { get; set; }
        public string KodPozicia { get; set; }
        public string Text { get; set; }
    }
}
