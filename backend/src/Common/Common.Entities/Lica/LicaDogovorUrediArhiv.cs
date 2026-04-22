using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class LicaDogovorUrediArhiv
    {
        public int IdUredDg { get; set; }
        public int IdDogL { get; set; }
        public int IdL { get; set; }
        public int IdKt { get; set; }
        public int Broi { get; set; }
        public short StatusU { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }
        public int Porychani { get; set; }

        public virtual LicaDogovor IdDogLNavigation { get; set; }
    }
}
