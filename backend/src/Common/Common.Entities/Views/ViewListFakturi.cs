using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Views
{
    public class ViewListFakturi
    {
        public int idfaktura { get; set; }
        public string faknomer { get; set; }
        public string fakdata { get; set; }
        public int idfirma { get; set; }
        public string eik { get; set; }
        public string ime { get; set; }
        public decimal total { get; set; }
    }
}
