using System;
using System.Collections.Generic;

namespace BillLogDbScaffold
{
    public partial class Revenue
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
