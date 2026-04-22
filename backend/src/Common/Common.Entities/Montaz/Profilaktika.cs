using Common.Entities.Montaz;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities.Montaz
{
    public class Profilaktika
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdPorachkaMain { get; set; }
        public int IdDogovorLice { get; set; }
        public int IdUred { get; set; }
        public DateTime? Data { get; set; }
        public string Note { get; set; }
        public int Status_PF { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }
        public int PNomer { get; set; }
        public int Broi { get; set; }
        public DateTime? OtchetData { get; set; }
        public string Model { get; set; }
        public int IdL { get; set; }
        public int Period { get; set; }
        public int idprofilaktika { get; set; }

        public virtual LicaDogovor IdLNavigation { get; set; }
        public virtual MonPorychkaMain IdMainNavigation { get; set; }
    }
}

