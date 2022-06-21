using System.Collections.Generic;

namespace kol_pop.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public int OrganizationId { get; set; }
        public string TeamName { get; set; }
        public string? TeamDescription { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<Membership> Membership { get; set; }
        public virtual ICollection<File> File { get; set; }
    }
}
