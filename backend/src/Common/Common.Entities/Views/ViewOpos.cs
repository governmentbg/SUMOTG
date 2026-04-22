using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.Entities.Views
{
    [Table("vwOPOS")]
    public class ViewOpos
    {
        public int ID_L { get; set; }
        public int ID_Formuliar { get; set; }
        public short Faza { get; set; }
        public string U_nom { get; set; }
        public string Raion { get; set; }
        public string IME { get; set; }
        public string UrIRad { get; set; }
        public string Broi { get; set; }
        public string KodUrIRad { get; set; }
        public string VidUr { get; set; }
        public string UrBezRad { get; set; }
        public string BrUr { get; set; }
        public string Rad { get; set; }
        public string BrRad { get; set; }
        public string DUrIRad { get; set; }
        public string DBroi { get; set; }
        public string DKodUrIRad { get; set; }
        public string DVidUr { get; set; }
        public string DUrBezRad { get; set; }
        public string DBrUr { get; set; }
        public string DRad { get; set; }
        public string DBrRad { get; set; }
        public string UrDem { get; set; }
        public string BrDem { get; set; }
        public string KodUrDem { get; set; }
        public string DUrDem { get; set; }
        public string DBrDem { get; set; }
        public string DKodUrDem { get; set; }
        public string Adres { get; set; }
        public string E_Mail { get; set; }
        public string Telefon { get; set; }
        public string vidimot { get; set; }
        public string StatF { get; set; }
        public string StatL { get; set; }
        public string StatDL { get; set; }
        public int IdDogL { get; set; }
        public string DogL { get; set; }
        public int UNomer { get; set; }
        public string Vid { get; set; }


    }
}
