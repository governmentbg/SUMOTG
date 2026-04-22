using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Entities.Views
{
    [Table("vwAdres")]
    public class ViewAdres
    {
        public int? ID_L { get; set; }
        public string U_nom { get; set; }
        public string Adres { get; set; }
        public int UNomer { get; set; }
        public string E_Mail { get; set; }
        public string Telefon { get; set; }
        public string vidimot { get; set; }

    }
}
