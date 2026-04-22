using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Entities.Views
{
    [Table("vwSpravka14")]

    public class vwSpravka14
    {
        public int IdPorachkaMain { get; set; }
        public int IdDogovorLice { get; set; }
        public string txturedi { get; set; }
        public string txtstatus { get; set; }
        public string txtmondata { get; set; }
        public string txtdemuredi { get; set; }
        public string txtdemstatus { get; set; }
        public string txtdemdata { get; set; }
        public int porychkaD { get; set; }
        public string txtkamina { get; set; }

    }
}
