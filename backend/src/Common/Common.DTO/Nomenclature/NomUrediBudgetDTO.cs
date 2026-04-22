using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class NomUredBudgetDTO
    {
        public int id { get; set; }
        public short faza { get; set; }
        public string nkod { get; set; }
        public string nime { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public short status { get; set; }

    }
}
