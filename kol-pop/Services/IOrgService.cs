using kol_pop.Models;
using System.Linq;

namespace kol_pop.Services
{
    public interface IOrgService
    {
        public IQueryable<Team> GetTeamById(int id);
    }
}
