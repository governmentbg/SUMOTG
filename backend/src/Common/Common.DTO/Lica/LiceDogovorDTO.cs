using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class LiceDogovorDTO
    {
        public int iddog { get; set; }
        public int idl { get; set; }
        public short faza { get; set; }
        public string regnom { get; set; }

        public DateTime? regnomdata { get; set; }

        public List<UrediDTO> uredi { get; set; }
        public List<UrediDTO> olduredi { get; set; }
        public List<UrediDTO> arhuredi { get; set; }
        public short status_DL { get; set; }
        public short status { get; set; }
        public string comentar { get; set; }
        public string brdopsp { get; set; }
        public List<DopSpDTO> dopsp { get; set; }
        public int vid { get; set; }
        public int SrokDogovor { get; set; }
        public int SrokSobstvenost { get; set; }

    }
}
