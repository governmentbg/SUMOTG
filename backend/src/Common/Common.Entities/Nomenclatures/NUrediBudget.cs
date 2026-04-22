using System;
using System.Collections.Generic;



namespace Common.Entities
{
    public partial class NUrediBudget
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public short Status { get; set; }
        public virtual NUredi IdMainNavigation { get; set; }
    }
}
