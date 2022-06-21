using System.Collections.Generic;

namespace kol_pop.DTOs
{
    public class TeamDto
    {
        public int OrganizationId { get; set; }
        public string TeamName { get; set; }
        public string? TeamDescription { get; set; }
        public string OrganizationName { get; set; }
        public List<MemberDto> MemberDto { get; set; }

    }
    public class MemberDto
    {
        public int OrganiztionId { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string? MemmberNickName { get; set; }
    }
}
