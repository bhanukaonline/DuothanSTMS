using Dapper;
using Duothan.Server.Model;
using System.Data;
using System.Data.SqlClient;

namespace Duothan.Server.Data
{
    public class VehicleLocationRepository
    {
        private readonly IConfiguration _configuration;

        public VehicleLocationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private IDbConnection Connection => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));

        public async Task<IEnumerable<VehicleLocation>> GetAll()
        {
            using (var dbConnection = Connection)
            {
                string sql = "SELECT * FROM VehicleLocations";
                return await dbConnection.QueryAsync<VehicleLocation>(sql);
            }
        }

        public async Task<VehicleLocation> GetById(int id)
        {
            using (var dbConnection = Connection)
            {
                string sql = "SELECT * FROM VehicleLocations WHERE VehicleID = @Id";
                return await dbConnection.QueryFirstOrDefaultAsync<VehicleLocation>(sql, new { Id = id });
            }
        }

        public async Task<int> Add(VehicleLocation location)
        {
            using (var dbConnection = Connection)
            {
                string sql = @"
                    INSERT INTO VehicleLocations (RouteID, Latitude, Longitude, Timestamp) 
                    VALUES (@RouteID, @Latitude, @Longitude, @Timestamp);
                    SELECT CAST(SCOPE_IDENTITY() as int)";
                return await dbConnection.ExecuteScalarAsync<int>(sql, location);
            }
        }

        public async Task<int> Update(VehicleLocation location)
        {
            using (var dbConnection = Connection)
            {
                string sql = @"
                    UPDATE VehicleLocations 
                    SET RouteID = @RouteID, Latitude = @Latitude, Longitude = @Longitude, Timestamp = @Timestamp 
                    WHERE VehicleID = @VehicleID";
                return await dbConnection.ExecuteAsync(sql, location);
            }
        }

        public async Task<int> Delete(int id)
        {
            using (var dbConnection = Connection)
            {
                string sql = "DELETE FROM VehicleLocations WHERE VehicleID = @Id";
                return await dbConnection.ExecuteAsync(sql, new { Id = id });
            }
        }
    }
}
