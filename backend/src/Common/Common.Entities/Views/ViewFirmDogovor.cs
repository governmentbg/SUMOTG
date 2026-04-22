using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Views
{
    public class ViewFirmDogovor
    {
        public int IdDog { get; set; }
        public short Faza { get; set; }
        public int IdFirma { get; set; }
        public string RegIndex { get; set; }
        public DateTime? DataRegN { get; set; }
        public int NomDgVSudso { get; set; }
        public DateTime? NachalnaData { get; set; }
        public int ObshtSrokGrf { get; set; }
        public decimal ObshtaCenaBezDds { get; set; }
        public decimal ObshtaCenaSDds { get; set; }
        public short StatusDm { get; set; }
        public short Status { get; set; }
        public List<MonDgvUredi> uredi { get; set; }
        public List<DemDgvOlduredi> olduredi { get; set; }
        public List<MonRajoni> raioni { get; set; }
        public List<MonPayments> payments { get; set; }
        public List<DemPayments> dempayments { get; set; }

        public Firmi firma { get; set; }
    }
}
