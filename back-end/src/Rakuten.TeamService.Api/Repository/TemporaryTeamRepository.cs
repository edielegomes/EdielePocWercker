using System;
using System.Collections.Generic;
using Rakuten.TeamService.Api.Models;
using System.Linq;

namespace Rakuten.TeamService.Api.Repository
{
    public class TemporaryTeamRepository : ITeamRepository
    {
        protected static ICollection<Team> teams;

        public TemporaryTeamRepository()
        {
            if (teams == null)
            {
                teams = new List<Team>();
            }
        }

        public TemporaryTeamRepository(ICollection<Team> teams)
        {
            TemporaryTeamRepository.teams = teams;
        }

        public IEnumerable<Team> List()
        {
            return teams;
        }

        public Team Get(Guid id)
        {
            return teams.FirstOrDefault(t => t.ID == id);
        }

        public Team Update(Team t)
        {
            Team team = this.Delete(t.ID);

            if (team != null)
            {
                team = this.Add(t);
            }

            return team;
        }

        public Team Add(Team team)
        {
            teams.Add(team);
            return team;
        }

        public Team Delete(Guid id)
        {
            var q = teams.Where(t => t.ID == id);
            Team team = null;

            if (q.Count() > 0)
            {
                team = q.First();
                teams.Remove(team);
            }

            return team;
        }
    }

}