using System;
using Microsoft.AspNetCore.Mvc;
using Rakuten.TeamService.Api.Models;
using Rakuten.TeamService.Api.Repository;

namespace Rakuten.TeamService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        ITeamRepository repository;

		public TeamsController(ITeamRepository repo) 
		{
			repository = repo;
		}

		[HttpGet]
        public virtual IActionResult GetAllTeams()
		{
			return this.Ok(repository.List());
		}

		[HttpGet("{id}")]
        public IActionResult GetTeam(Guid id)
		{
			Team team = repository.Get(id);		

			if (team != null) 			  
			{				
				return this.Ok(team);
			} else {
				return this.NotFound();
			}			
		}		

		[HttpPost]
		public virtual IActionResult CreateTeam([FromBody]Team newTeam) 
		{
			repository.Add(newTeam);					
			return this.Created($"/teams/{newTeam.ID}", newTeam);
		}

		[HttpPut("{id}")]
		public virtual IActionResult UpdateTeam([FromBody]Team team, Guid id) 
		{
			team.ID = id;
						
			if(repository.Update(team) == null) {
				return this.NotFound();
			} else {
				return this.Ok(team);
			}
		}

		[HttpDelete("{id}")]
        public virtual IActionResult DeleteTeam(Guid id)
		{
			Team team = repository.Delete(id);

			if (team == null) {
				return this.NotFound();
			} else {				
				return this.Ok(team.ID);
			}
		}
    }
}
