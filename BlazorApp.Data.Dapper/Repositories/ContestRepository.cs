using BlazorApp.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Data.Dapper.Repositories
{
    public class ContestRepository : IContestRepository
    {
        private readonly string _connectionString;

        public ContestRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected SqlConnection DbConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public Task<bool> DeleteContest(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contest>> GetAllContests()
        {
            var db = DbConnection();
            var sql = @"SELECT [Name], [Date], [AdditionalInformation] FROM [dbo].[Contests] ";
            return await db.QueryAsync<Contest>(sql, new { });
        }

        public Task<Contest> GetContestDetails(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertContest(Contest contest)
        {
            var db = DbConnection();
            var sql = @"
                INSERT INTO [dbo].[Contests] ([Name], [Date], [AdditionalInformation]) 
                VALUES(@Name, @Date, @AdditionalInformation)";
            var result = await db.ExecuteAsync(sql.ToString(), new { contest.Name, contest.Date, contest.AdditionalInformation });
            return result > 0;
        }

        public Task<bool> UpdateContest(Contest contest)
        {
            throw new NotImplementedException();
        }
    }
}
