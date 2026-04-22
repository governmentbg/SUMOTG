using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class LicaDogovorOldUredi
    {
        public int IdOldurediDgl { get; set; }
        public int IdDogL { get; set; }

        public int IdL { get; set; }
        public int IdKt { get; set; }
        public int Broi { get; set; }
        public short StatusDU { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }

        public virtual LicaDogovor IdDogLNavigation { get; set; }
    }
}
