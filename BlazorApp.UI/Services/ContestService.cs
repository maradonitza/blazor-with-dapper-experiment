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
            return _contestRepository.DeleteContest(id);
        }

        public Task<IEnumerable<Contest>> GetContests()
        {
            return _contestRepository.GetAllContests();
        }

        public Task<Contest> GetContestDetails(int id)
        {
            return _contestRepository.GetContestDetails(id);
        }

        public Task<bool> SaveContest(Contest contest)
        {
            if (contest.Id == 0)
                return _contestRepository.InsertContest(contest);
            else
                return _contestRepository.UpdateContest(contest);
        }
    }
}
