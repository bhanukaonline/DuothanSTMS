using Dapper;
using Duothan.Server.Model;
using System.Data;
using System.Data.SqlClient;

namespace Duothan.Server.Data
{
    public class PublicTransportScheduleRepository
    {
        private readonly IConfiguration _configuration;

        public PublicTransportScheduleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<PublicTransportSchedule>> GetAll()
        {
            using (var dbConnection = Connection)
            {
                string sql = "SELECT * FROM PublicTransportSchedules";
                return await dbConnection.QueryAsync<PublicTransportSchedule>(sql);
            }
        }

        public async Task<PublicTransportSchedule> GetById(int id)
        {
            using (var dbConnection = Connection)
            {
                string sql = "SELECT * FROM PublicTransportSchedules WHERE ScheduleID = @Id";
                return await dbConnection.QueryFirstOrDefaultAsync<PublicTransportSchedule>(sql, new { Id = id });
            }
        }

        public async Task<int> Add(PublicTransportSchedule schedule)
        {
            using (var dbConnection = Connection)
            {
                string sql = @"
                    INSERT INTO PublicTransportSchedules (RouteID, DepartureTime, ArrivalTime) 
                    VALUES (@RouteID, @DepartureTime, @ArrivalTime);
                    SELECT CAST(SCOPE_IDENTITY() as int)";
                return await dbConnection.ExecuteScalarAsync<int>(sql, schedule);
            }
        }

        public async Task<int> Update(PublicTransportSchedule schedule)
        {
            using (var dbConnection = Connection)
            {
                string sql = @"
                    UPDATE PublicTransportSchedules 
                    SET RouteID = @RouteID, DepartureTime = @DepartureTime, ArrivalTime = @ArrivalTime 
                    WHERE ScheduleID = @ScheduleID";
                return await dbConnection.ExecuteAsync(sql, schedule);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var dbConnection = Connection)
            {
                string sql = "DELETE FROM PublicTransportSchedules WHERE ScheduleID = @Id";
                return await dbConnection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
