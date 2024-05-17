using Dapper;
using Duothan.Server.Model;
using System.Data;
using System.Data.SqlClient;

namespace Duothan.Server.Data
{
    public class TransportPassRepository
    {
        private readonly IConfiguration _configuration;

        public TransportPassRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<TransportPass>> GetAll()
        {
            using (var dbConnection = Connection)
            {
                string sql = "SELECT * FROM TransportPasses";
                return await dbConnection.QueryAsync<TransportPass>(sql);
            }
        }

        public async Task<TransportPass> GetById(int id)
        {
            using (var dbConnection = Connection)
            {
                string sql = "SELECT * FROM TransportPasses WHERE TransportPassID = @Id";
                return await dbConnection.QueryFirstOrDefaultAsync<TransportPass>(sql, new { Id = id });
            }
        }

        public async Task<int> Add(TransportPass transportPass)
        {
            using (var dbConnection = Connection)
            {
                string sql = @"
                    INSERT INTO TransportPasses (UserID, IssueDate, ExpiryDate, Balance) 
                    VALUES (@UserID, @IssueDate, @ExpiryDate, @Balance);
                    SELECT CAST(SCOPE_IDENTITY() as int)";
                return await dbConnection.ExecuteScalarAsync<int>(sql, transportPass);
            }
        }

        public async Task<int> Update(TransportPass transportPass)
        {
            using (var dbConnection = Connection)
            {
                string sql = @"
                    UPDATE TransportPasses 
                    SET UserID = @UserID, IssueDate = @IssueDate, ExpiryDate = @ExpiryDate, Balance = @Balance 
                    WHERE TransportPassID = @TransportPassID";
                return await dbConnection.ExecuteAsync(sql, transportPass);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var dbConnection = Connection)
            {
                string sql = "DELETE FROM TransportPasses WHERE TransportPassID = @Id";
                return await dbConnection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
