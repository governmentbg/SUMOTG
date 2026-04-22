using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class Lica
    {
        public Lica()
        {
            LicaDogovors = new HashSet<LicaDogovor>();
            LicaDokumentis = new HashSet<LicaDokumenti>();
            LicaFormuliars = new HashSet<LicaFormuliar>();
            LicaFormuliarFirma = new HashSet<LicaFormuliarFirma>();
            LicaFormuliarKolektiv = new HashSet<LicaFormuliarKolektiv>();
            LicaFormuliarUredis = new HashSet<LicaFormuliarUredi>();
            LicaFormuliarOldUredis = new HashSet<LicaFormuliarOldUredi>();
            LicaDopSporazumeniq = new HashSet<LicaDopSporazumeniq>();

        }

        public int IdL { get; set; }
        public short Faza { get; set; }
        public int VLice { get; set; } 
        public short Status { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }
        public short Tochki1 { get; set; }
        public short Tochki2 { get; set; }
        public short Tochki3 { get; set; }
        public short Tochki4 { get; set; }
        public short Tochki5 { get; set; }
        public short Tochki6 { get; set; }
        public short Tochki7 { get; set; }
        public short Total { get; set; }

        public virtual ICollection<LicaDogovor> LicaDogovors { get; set; }
        public virtual ICollection<LicaDokumenti> LicaDokumentis { get; set; }
        public virtual ICollection<LicaFormuliar> LicaFormuliars { get; set; }
        public virtual ICollection<LicaFormuliarFirma> LicaFormuliarFirma { get; set; }
        public virtual ICollection<LicaFormuliarKolektiv> LicaFormuliarKolektiv { get; set; }
        public virtual ICollection<LicaFormuliarUredi> LicaFormuliarUredis { get; set; }
        public virtual ICollection<LicaFormuliarOldUredi> LicaFormuliarOldUredis { get; set; }
        public virtual ICollection<LicaDopSporazumeniq> LicaDopSporazumeniq { get; set; }

    }
}
