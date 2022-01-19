using System;
using System.Collections.Generic;

namespace BillLogDbScaffold
{
    public partial class UsersScope
    {
        public int UserId { get; set; }
        public int ScopeId { get; set; }

        public virtual Scope Scope { get; set; }
        public virtual User User { get; set; }
    }
}
