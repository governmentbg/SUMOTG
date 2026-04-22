using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class FilterDTO
    {
		public string raionid { get; set; }
		public string tipuredi { get; set; }
		public string uredi { get; set; }
		public string olduredi { get; set; }
		public int statusL { get; set; }
		public int statusF { get; set; }
		public int statusDL { get; set; }
		public int statusU { get; set; }
		public int faza { get; set; }
		public int unomer { get; set; }
		public string regnom { get; set; }
		public string adres { get; set; }
		public int vid { get; set; }
		public int firma { get; set; }
		public int dogovor { get; set; }
		public int statusDU { get; set; }
		public int demfirma { get; set; }
		public int demdogovor { get; set; }
		public int statusG { get; set; }
		public int statusM { get; set; }
		public int porychkanom { get; set; }
		public int demporychkanom { get; set; }
		public DateTime grafikdataot { get; set; }
		public DateTime grafikdatado { get; set; }
		public DateTime otchetdataot { get; set; }
		public DateTime otchetdatado { get; set; }
		public string dpregnom { get; set; }
		public int viddpspor { get; set; }
		public int limit { get; set; }

		public int vidformulqr { get; set; }
		public int vidportret { get; set; }

	}
}
