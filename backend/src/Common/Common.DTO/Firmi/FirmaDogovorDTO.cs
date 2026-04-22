using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Firmi
{
    public class FirmaDogovorDTO
    {
        public int iddog { get; set; }
        public short faza { get; set; }
        public string regnom { get; set; }
        public DateTime? regnomdata { get; set; }
        public int nomdgsudso { get; set; }
        public DateTime? nachalnadata { get; set; }
        public int srokgrafic { get; set; }
        public decimal cenabezdds{ get; set; }
        public decimal cenadds { get; set; }
        public List<FirmaUrediDTO> uredi { get; set; }
        public IzpylnitelDTO firma { get; set; }
        public List<FirmaRaioniDTO> raioni { get; set; }
        public short status_DM { get; set; }
        public short status { get; set; }
        public List<FirmaPaymentDTO> payments { get; set; }
    }
}
