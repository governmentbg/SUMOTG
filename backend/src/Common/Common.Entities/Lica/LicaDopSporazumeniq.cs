using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class LicaDopSporazumeniq
    {
        public int Id { get; set; }
        public int IdL { get; set; }
        public int IdDopSp { get; set; }
        public string RegNomer { get; set; }
        public string Komentar { get; set; }
        public string User { get; set; }
        public DateTime? Koga { get; set; }

        public virtual Lica IdLNavigation { get; set; }
    }
}
