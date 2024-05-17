using Dapper;
using Duothan.Server.Model;
using System.Data;
using System.Data.SqlClient;

namespace Duothan.Server.Data
{
    public class ParkingInformationRepository
    {
        private readonly IConfiguration _configuration;

        public ParkingInformationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<ParkingInformation>> GetAll()
        {
            using (var dbConnection = Connection)
            {
                string sql = "SELECT * FROM ParkingInformations";
                return await dbConnection.QueryAsync<ParkingInformation>(sql);
            }
        }

        public async Task<ParkingInformation> GetById(int id)
        {
            using (var dbConnection = Connection)
            {
                string sql = "SELECT * FROM ParkingInformations WHERE ParkingID = @Id";
                return await dbConnection.QueryFirstOrDefaultAsync<ParkingInformation>(sql, new { Id = id });
            }
        }

        public async Task<int> Add(ParkingInformation parking)
        {
            using (var dbConnection = Connection)
            {
                string sql = @"
                    INSERT INTO ParkingInformations (Location, Capacity, AvailableSpots) 
                    VALUES (@Location, @Capacity, @AvailableSpots);
                    SELECT CAST(SCOPE_IDENTITY() as int)";
                return await dbConnection.ExecuteScalarAsync<int>(sql, parking);
            }
        }

        public async Task<int> Update(ParkingInformation parking)
        {
            using (var dbConnection = Connection)
            {
                string sql = @"
                    UPDATE ParkingInformations 
                    SET Location = @Location, Capacity = @Capacity, AvailableSpots = @AvailableSpots 
                    WHERE ParkingID = @ParkingID";
                return await dbConnection.ExecuteAsync(sql, parking);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var dbConnection = Connection)
            {
                string sql = "DELETE FROM ParkingInformations WHERE ParkingID = @Id";
                return await dbConnection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
