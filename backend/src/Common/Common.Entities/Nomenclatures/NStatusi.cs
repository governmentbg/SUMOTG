using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class NStatusi
    {
        public int IdSt { get; set; }
        public short Faza { get; set; }
        public string TableName { get; set; }
        public string StatusName { get; set; }
        public short StatusCode { get; set; }
        public string Text { get; set; }
        public short Status { get; set; }
        public string Komentar { get; set; }
        public string KodNmn { get; set; }
    }
}
