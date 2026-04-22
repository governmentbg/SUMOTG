using System;
using System.Collections.Generic;

namespace Common.Entities
{
	//[Keyless]
	public partial class ViewListFormulqr
	{
        public int IdFormulqr { get; set; }
        public string unom { get; set; }
        public string raion { get; set; }
        public int idl { get; set; }
        public string ident { get; set; }
        public string name { get; set; }
        public string telefon { get; set; }
        public int idfirma { get; set; }
        public string firma { get; set; }
        public string bulstat { get; set; }
        public decimal bal { get; set; }
        public int status_L { get; set; }
        public int status_f { get; set; }
        public int iddog { get; set; }
        public int status_dl { get; set; }
        public string stattxt_dl { get; set; }
        public string stattxt_f { get; set; }
        public string stattxt_l { get; set; }
        public int unomer { get; set; }

    }
}
