using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Spravki
{
    public class Spravka14DTO
    {
        public int idl { get; set; }
        public int idformulqr { get; set; }
        public string dognomer { get; set; }
        public string dogdate { get; set; }
        public string unom { get; set; }
        public string ime { get; set; }
        public string raion { get; set; }
        public string adres { get; set; }
        public string txturedi { get; set; }
        public string statusM { get; set; }
        public string dataM { get; set; }
        public string porychkaM { get; set; }
        public string izpalnitel { get; set; }
        public string izpdogovor { get; set; }
        public string txtolduredi { get; set; }
        public string txtkamina { get; set; }

        public string statusD { get; set; }
        public string dataD { get; set; }
        public string porychkaD { get; set; }
        public string statusDl { get; set; }
    }
}
