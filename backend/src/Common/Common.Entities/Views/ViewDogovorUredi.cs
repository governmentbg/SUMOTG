using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Views
{
    public class ViewDogovorUredi
    {
        public int IdL { get; set; }
        public int IdKt { get; set; }
        public int Broi { get; set; }
        public short StatusU { get; set; }
        public short Status { get; set; }
        public DateTime? Koga { get; set; }
        public string User { get; set; }

    }
}
