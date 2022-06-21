using kol_pop.Context;
using kol_pop.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace kol_pop.Services
    
{
    public class OrgService : IOrgService
    {
        private readonly OrganiztionContext _context;
        public OrgService(OrganiztionContext context)
        {
            _context = context;
        }
        public IQueryable<Team> GetTeamById(int id)
        {
            var resutl = _context.Team.Where(e => e.TeamId == id).Include(e => e.Organization).Include(e => e.Membership).ThenInclude(e => e.Member);
            return resutl;
        }
    }
}
