using System.Collections.Generic;

namespace kol_pop.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public int OrganiztionId { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string? MemmberNickName { get; set; }
        public virtual Organization Organiztion { get; set; }
        public virtual ICollection<Membership> Membership { get; set; }
    }
}
