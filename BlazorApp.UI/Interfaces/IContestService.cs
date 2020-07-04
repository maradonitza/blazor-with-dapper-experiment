using BlazorApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.UI.Interfaces
{
    public interface IContestService
    {
        Task<IEnumerable<Contest>> GetContests();
        Task<Contest> GetDetails(int id);
        Task<bool> DeleteContest(int id);
        Task<bool> SaveContest(Contest contest);

    }
}
