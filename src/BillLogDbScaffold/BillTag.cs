using System;
using System.Collections.Generic;

namespace BillLogDbScaffold
{
    public partial class BillTag
    {
        public BillTag()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
