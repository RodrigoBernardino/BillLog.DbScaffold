using System;
using System.Collections.Generic;

namespace BillLogDbScaffold
{
    public partial class UsersRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
