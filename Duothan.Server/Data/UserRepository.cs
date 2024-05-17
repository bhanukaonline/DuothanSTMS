using Dapper;
using Duothan.Server.Model;
using System.Data;
using System.Data.SqlClient;

namespace Duothan.Server.Data
{
    public class UserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<User>> GetAll()
        {
            using (var dbConnection = Connection)
            {
                string sql = "SELECT * FROM Users";
                return await dbConnection.QueryAsync<User>(sql);
            }
        }

        public async Task<User> GetById(int id)
        {
            using (var dbConnection = Connection)
            {
                string sql = "SELECT * FROM Users WHERE UserID = @Id";
                return await dbConnection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
            }
        }

        public async Task<int> Add(User user)
        {
            using (var dbConnection = Connection)
            {
                string sql = @"
                    INSERT INTO Users (Username, PasswordHash, Email, FullName, CreatedDate) 
                    VALUES (@Username, @PasswordHash, @Email, @FullName, @CreatedDate);
                    SELECT CAST(SCOPE_IDENTITY() as int)";
                return await dbConnection.ExecuteScalarAsync<int>(sql, user);
            }
        }

        public async Task<int> Update(User user)
        {
            using (var dbConnection = Connection)
            {
                string sql = @"
                    UPDATE Users 
                    SET Username = @Username, PasswordHash = @PasswordHash, Email = @Email, FullName = @FullName 
                    WHERE UserID = @UserID";
                return await dbConnection.ExecuteAsync(sql, user);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var dbConnection = Connection)
            {
                string sql = "DELETE FROM Users WHERE UserID = @Id";
                return await dbConnection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
