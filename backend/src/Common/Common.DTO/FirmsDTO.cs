using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class FirmsDTO
    {
		public int idfirma { get; set; }
		public string unom { get; set; }
		public string ident { get; set; }
		public string ime { get; set; }
		public string raion { get; set; }
		public string statusL { get; set; }
		public string status { get; set; }
		public decimal? bal { get; set; }
		public string statusF { get; set; }
		public int idformulqr { get; set; }
		public int iddogovor { get; set; }
		public string statusDL { get; set; }
		public int vidlice { get; set; }
	}
}
