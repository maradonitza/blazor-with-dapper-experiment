using BlazorApp.Data.Dapper.Repositories;
using BlazorApp.Model;
using BlazorApp.UI.Data;
using BlazorApp.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.UI.Services
{
    public class ContestService : IContestService
    {
        private readonly SqlConfiguration _configuration;
        private IContestRepository _contestRepository;

        public ContestService(SqlConfiguration configuration)
        {
            _configuration = configuration;
            _contestRepository = new ContestRepository(configuration.ConnectionString);
        }

        public Task<bool> DeleteContest(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contest>> GetContests()
        {
            throw new NotImplementedException();
        }

        public Task<Contest> GetContestDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveContest(Contest contest)
        {
            if (contest.Id == 0)
                return _contestRepository.InsertContest(contest);
            else
                return null;
        }
    }
}
