using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities.Views
{
    public class ViewLicaDocumenti
    {
        public int IdDok { get; set; }
        public int IdL { get; set; }
        public int DocType { get; set; }
        public string DocName { get; set; }
        public string DocDescription { get; set; }
        public string Status { get; set; }
        public string FileName { get; set; }
    }
}
