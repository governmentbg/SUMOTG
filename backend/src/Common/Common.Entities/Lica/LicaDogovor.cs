using Common.Entities.Montaz;
using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class LicaDogovor
    {
        public LicaDogovor()
        {
            LicaDogovorUredis = new HashSet<LicaDogovorUredi>();
            LicaDogovorOldUredis = new HashSet<LicaDogovorOldUredi>();
            MonPorychkas = new HashSet<MonPorychka>();
            DemPorychkas = new HashSet<DemPorychka>();
        }

        public int IdDogL { get; set; }
        public int IdL { get; set; }
        public short Faza { get; set; }
        public string RegN { get; set; }
        public DateTime? DataRegN { get; set; }
        public short StatusDl { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }
        public string Comentar { get; set; }
        public string BrDopSp { get; set; }
        public int SrokDogovor { get; set; }
        public int SrokSobstvenost { get; set; }
        public int isexpired { get; set; }

        public virtual Lica IdLNavigation { get; set; }
        public virtual ICollection<LicaDogovorUredi> LicaDogovorUredis { get; set; }
        public virtual ICollection<LicaDogovorUrediArhiv> LicaDogovorUredisArhiv { get; set; }
        public virtual ICollection<LicaDogovorOldUredi> LicaDogovorOldUredis { get; set; }
        public virtual ICollection<MonPorychka> MonPorychkas { get; set; }
        public virtual ICollection<DemPorychka> DemPorychkas { get; set; }

        public virtual ICollection<Profilaktika> Profilaktika { get; set; }

    }
}
