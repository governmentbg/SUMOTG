using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class MonDgvUredi
    {
        public int IdSpDost { get; set; }
        public short Faza { get; set; }
        public int? IdFirmaMn { get; set; }
        public int IdKn { get; set; }
        public string Model { get; set; }
        public decimal EdCena { get; set; }
        public int Broi { get; set; }
        public short StatusDs { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }
        public int Garancia { get; set; }
        public int Profilaktika { get; set; }

        public virtual MonDogovor IdFirmaMnNavigation { get; set; }
    }
}
