using System;
using System.Collections.Generic;

namespace BillLogDbScaffold
{
    public partial class Bill
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateOnly DateTime { get; set; }
        public int UserId { get; set; }
        public int BillTagId { get; set; }
        public int ScopeId { get; set; }

        public virtual BillTag BillTag { get; set; }
        public virtual Scope Scope { get; set; }
        public virtual User User { get; set; }
    }
}
