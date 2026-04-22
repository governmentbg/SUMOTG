using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Views
{
    public class ViewFirmaDogovorUredi
    {
        public int IdKt { get; set; }
        public string Name { get; set; }
        public int Broi { get; set; }
        public decimal Edcena { get; set; }
        public decimal Total { get; set; }
        public short Status { get; set; }

    }
}
