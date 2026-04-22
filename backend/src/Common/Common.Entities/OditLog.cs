using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class OditLog
    {
        public int Id { get; set; }
        public DateTime Koga { get; set; }
        public string User { get; set; }
        public int Kod { get; set; }
        public string Text { get; set; }

    }
}
