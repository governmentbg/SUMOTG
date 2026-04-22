using Common.Entities.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class ViewLiceDogovor
    {
        public int iddog { get; set; }
        public int idl { get; set; }
        public short faza { get; set; }
        public string regnom { get; set; }
        public DateTime? regnomdata { get; set; }
        public List<ViewDogovorUredi> uredi { get; set; }
        public List<ViewDogovorUredi> olduredi { get; set; }
        public List<ViewDogovorUredi> arhuredi { get; set; }
        public short status_DL { get; set; }
        public short status { get; set; }
        public string Comentar { get; set; }
        public string BrDopSp { get; set; }
        public List<LicaDopSporazumeniq> dopsp { get; set; }
        public int vid { get; set; }
        public int SrokDogovor { get; set; }
        public int SrokSobstvenost { get; set; }
    }
}
