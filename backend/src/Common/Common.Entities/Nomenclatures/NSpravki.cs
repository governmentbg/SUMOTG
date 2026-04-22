using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    [Table("n_spravki")]
    public class NSpravki
    {
        public int Id { get; set; }
        public short Status { get; set; }
        public short Faza { get; set; }
        public string Ime { get; set; }
        public string Komentar { get; set; }
        public short Tip { get; set; }
        public decimal nkod { get; set; }
    }
}
