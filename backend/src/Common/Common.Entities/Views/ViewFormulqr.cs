using Common.Entities.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities
{
    // [Keyless]
    public partial class ViewFormulqr
    {
		public int IdFormulqr { get; set; }
		public int IdL { get; set; }
		public string uNom { get; set; }
		public DateTime? regdate { get; set; }
		public short Faza { get; set; }
		[NotMapped]
		public ViewLica lice { get; set; }
		public LicaFormuliarFirma firma { get; set; }
		public List<LicaFormuliarUredi> uredi { get; set; }
		public List<LicaFormuliarOldUredi> olduredi { get; set; }
		public List<LicaFormuliarKolektiv> systav { get; set; }
		public List<LicaDokumenti> dokumenti { get; set; }
		public int v7 { get; set; }
		public int nv8 { get; set; }
		public int nv9 { get; set; }
		public int nv10 { get; set; }
		public int v11 { get; set; }
		public int v12 { get; set; }
		public decimal v13 { get; set; }
		public decimal v14 { get; set; }
		public decimal v15 { get; set; }
		public int v16 { get; set; }
		public int v17 { get; set; }
		public int nv18 { get; set; }
		public int nv19 { get; set; }
		public int v20 { get; set; }
		public decimal v211 { get; set; }
		public decimal v212 { get; set; }
		public decimal v213 { get; set; }
		public int v22 { get; set; }
		public int v23 { get; set; }
		public int v24 { get; set; }
		public int v25 { get; set; }
		public int v26 { get; set; }
		public int v27 { get; set; }
		public int v28 { get; set; }
		public int nv29 { get; set; }
		public int v30 { get; set; }
		public int v31 { get; set; }
		public int v32 { get; set; }
		public int v33 { get; set; }
		public int v34 { get; set; }
		public int v35 { get; set; }
		public int v36 { get; set; }
		public int v37 { get; set; }
		public int v38 { get; set; }
		public decimal v391 { get; set; }
		public decimal v392 { get; set; }
		public decimal v401 { get; set; }
		public decimal v402 { get; set; }
		public decimal v41 { get; set; }
		public decimal v421 { get; set; }
		public decimal v422 { get; set; }
		public decimal v423 { get; set; }
		public short status { get; set; }
		public short statusF { get; set; }
		public int uNomer { get; set; }
		public short statusDL { get; set; }
		public string comentar { get; set; }
	}
}
