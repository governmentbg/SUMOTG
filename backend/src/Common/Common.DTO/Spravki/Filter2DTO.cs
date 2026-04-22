using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO.Spravki
{
	public class Filter2DTO
	{
		public string raionid { get; set; }
		public string uredi { get; set; }
		public string olduredi { get; set; }
		public int status { get; set; }
		public int faza { get; set; }
		public int unomer { get; set; }
		public string regnom { get; set; }
		public int type { get; set; }
	}
}
