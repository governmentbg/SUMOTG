using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Views.Spravki
{
    public class ViewSpravka50
    {
        public int idured { get; set; }
        public string ured { get; set; }
        public int broi { get; set; }
        public decimal price { get; set; }
        public decimal budget { get; set; }
        public decimal calcbudget { get; set; }
        public decimal procbudget { get; set; }
    }
}
