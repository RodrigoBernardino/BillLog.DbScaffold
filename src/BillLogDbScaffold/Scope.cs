using System;
using System.Collections.Generic;

namespace BillLogDbScaffold
{
    public partial class Scope
    {
        public Scope()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatorUserId { get; set; }

        public virtual User CreatorUser { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
