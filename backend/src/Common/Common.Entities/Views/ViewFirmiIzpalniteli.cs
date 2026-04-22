using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Views
{
    public class ViewFirmiIzpalniteli
    {
        public int idFirma { get; set; }
        public string EIK { get; set; }
        public string Ime { get; set; }
        public int IdDog { get; set; }
        public string RegIndex { get; set; }
        public DateTime? DataRegN { get; set; }
        public string StatusDm { get; set; }
        public string StatusUr { get; set; }

    }
}
