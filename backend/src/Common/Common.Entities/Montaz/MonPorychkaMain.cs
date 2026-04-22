using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Entities.Montaz
{
    public class MonPorychkaMain
    {
        public MonPorychkaMain()
        {
            MonPorychki = new HashSet<MonPorychka>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int IdPorachkaMain { get; set; }
        public short Faza { get; set; }
        public int Nomer { get; set; }
        public DateTime? Data { get; set; }
        public int IdFirma { get; set; }
        public int IdDogovorFirma { get; set; }
        public string ARaion { get; set; }
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }
        public DateTime? StartData { get; set; }
        public DateTime? EndData { get; set; }
        public short StatusPM { get; set; }
        public string Note { get; set; }


        public virtual MonDogovor IdDogFirmaNavigation { get; set; }
        public virtual ICollection<MonPorychka> MonPorychki { get; set; }
        public virtual ICollection<Profilaktika> Profilaktikas { get; set; }

    }
}
