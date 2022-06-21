using System;

namespace kol_pop.Models
{
    public class Membership
    {
        public int MemberId { get; set; }
        public int TeamId { get; set; }
        public DateTime MembershipDate { get; set; }
        public virtual Team Team { get; set; }
        public virtual Member Member { get; set; }
    }
}
