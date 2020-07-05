using BlazorApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Data.Dapper.Repositories
{
    public interface IContestRepository
    {
        Task<IEnumerable<Contest>> GetAllContests();
        Task<Contest> GetContestDetails(int id);
        Task<bool> InsertContest(Contest contest);
        Task<bool> UpdateContest(Contest contest);
        Task<bool> DeleteContest(int id);
    }
}
