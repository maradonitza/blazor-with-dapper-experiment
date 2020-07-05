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
        public async Task<bool> DeleteContest(int id)
        {
            var db = DbConnection();
            var sql = @"
                DELETE FROM [dbo].[Contests]
                WHERE Id = @Id";
            var result = await db.ExecuteAsync(sql.ToString(), new { Id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Contest>> GetAllContests()
        {
            var db = DbConnection();
            var sql = @"SELECT [Id], [Name], [Date], [AdditionalInformation] FROM [dbo].[Contests] ";
            return await db.QueryAsync<Contest>(sql, new { });
        }

        public async Task<Contest> GetContestDetails(int id)
        {
            var db = DbConnection();
            var sql = @"SELECT [Id], [Name], [Date], [AdditionalInformation] FROM [dbo].[Contests] where [Id] = @id";
            return await db.QueryFirstOrDefaultAsync<Contest>(sql.ToString(), new { Id = id });
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

        public async Task<bool> UpdateContest(Contest contest)
        {
            var db = DbConnection();
            var sql = @"
                UPDATE [dbo].[Contests] 
                SET [Name]=@Name, [Date]=@Date, [AdditionalInformation]=@AdditionalInfo
                WHERE [Id]=@Id";
            var result = await db.ExecuteAsync(sql.ToString(), new { contest.Name, contest.Date, AdditionalInfo = contest.AdditionalInformation, Id = contest.Id });
            return result > 0;
        }
    }
}
