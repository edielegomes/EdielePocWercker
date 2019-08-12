using System;
using System.Collections.Generic;
using Rakuten.TeamService.Api.Models;

namespace Rakuten.TeamService.Api.Repository
{
    public interface ITeamRepository 
    {
	    IEnumerable<Team> List();
		Team Get(Guid id);
		Team Add(Team team);
		Team Update(Team team);		
		Team Delete(Guid id);
	}
}