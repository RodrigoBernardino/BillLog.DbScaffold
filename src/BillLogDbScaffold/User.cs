using System;
using System.Collections.Generic;

namespace BillLogDbScaffold
{
    public partial class User
    {
        public User()
        {
            Bills = new HashSet<Bill>();
            Scopes = new HashSet<Scope>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public virtual Revenue Revenue { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual ICollection<Scope> Scopes { get; set; }
    }
}
