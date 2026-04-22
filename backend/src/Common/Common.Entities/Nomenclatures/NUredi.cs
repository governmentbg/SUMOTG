using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class NUredi
    {
        public int Id { get; set; }
        public short Faza { get; set; }
        public string Nkod { get; set; }
        public string Nime { get; set; }
        public int MaxBr { get; set; }
        public int DopRad { get; set; }
        public short Status { get; set; }
        public short KolectForm { get; set; }
        public string Vid { get; set; }
        public string Nkod2 { get; set; }
        public string Nime2 { get; set; }
        public int Id2 { get; set; }
        public virtual ICollection<NUrediBudget> NUredisBudget { get; set; }

    }
}
