using System.Collections.Generic;

namespace DataFlow.Models
{
    public partial class AspNetRole
    {
        public AspNetRole()
        {
            AspNetUserRoles = new HashSet<AspNetUserRole>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
    }
}
