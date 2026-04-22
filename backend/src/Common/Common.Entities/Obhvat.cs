
using System.Collections.Generic;

namespace Common.Entities
{
    public class Obhvat : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<UserObhvat> UserObhvat { get; set; }
    }
}
