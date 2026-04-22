using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Entities.Views
{
    [Table("vwLicaDogovorUredi")]
    public class ViewLicaDogovorUrediVid
    {
        public int IdDogL { get; set; }
        public int idured { get; set; }
        public string Nkod { get; set; }
        public string Nime { get; set; }
        public string Vid { get; set; }
        public int Broi { get; set; }
        public short Status_U { get; set; }        
        public string TipUrIme { get; set; }

    }
}
