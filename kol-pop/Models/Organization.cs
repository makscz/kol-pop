using System.Collections.Generic;

namespace kol_pop.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDomain { get; set; }
        public virtual ICollection<Member> Member { get; set; }
        public virtual ICollection<Team> Team { get; set; }
    }
}
