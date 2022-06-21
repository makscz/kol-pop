using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using kol_pop.Services;
using kol_pop.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using kol_pop.DTOs;
using System;

namespace kol_pop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllController : ControllerBase
    {
        IOrgService _service;
        public AllController(IOrgService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            if(!ModelState.IsValid)
                return BadRequest("zle zadanie");
            if(await _service.GetTeamById(id).FirstOrDefaultAsync() is null)
                return NotFound("Nie znalezino zespolu");
            try
            {
                var result = await _service
                    .GetTeamById(id)
                    .Select(e => new TeamDto
                    {
                        OrganizationId = e.OrganizationId,
                        TeamName = e.TeamName,
                        TeamDescription = e.TeamDescription,
                        OrganizationName = e.Organization.OrganizationName,
                        MemberDto = e.Membership.Select(m => new MemberDto
                        {
                            OrganiztionId = m.Member.OrganiztionId,
                            MemberName = m.Member.MemberName,
                            MemberSurname = m.Member.MemberSurname,
                            MemmberNickName = m.Member.MemmberNickName,
                        }).ToList()
                    }).ToListAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                return Problem("Jakis problem!");
            }
        }

    }
}
