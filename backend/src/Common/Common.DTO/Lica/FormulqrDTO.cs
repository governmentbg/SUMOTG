using Common.DTO.Lica;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
	public class FormulqrDTO
	{
		public int idformulqr { get; set; }
		public string unom { get; set; }
		public short faza { get; set; }
		public DateTime? regdate { get; set; }
		public LiceDTO lice { get; set; }
		public FirmaDTO firma { get; set; }
		public List<UrediDTO> uredi { get; set; }
		public List<UrediDTO> olduredi { get; set; }
		public List<LiceDTO> systav { get; set; }
		public List<ListDocumentsDTO> dokumenti { get; set; }
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
		public int unomer { get; set; }
		public short statusDL { get; set; }
		public string comentar { get; set; }

	}
}
