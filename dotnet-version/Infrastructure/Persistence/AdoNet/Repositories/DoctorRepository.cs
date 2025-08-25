using Dapper;
using Microsoft.Data.Sqlite;
using dotnet_version.Models;

namespace Infrastructure.Persistence.AdoNet.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly string _connectionString = "Data Source=database.sqlite";
        private readonly Services.LoggerService _logger = new Services.LoggerService();
        private readonly Services.ExceptionService _exceptionService = new Services.ExceptionService();

        public IEnumerable<Doctor> GetAll()
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                return connection.Query<Doctor>("SELECT * FROM Doctors");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fetching all doctors", ex);
                _exceptionService.LogException(ex, "GetAll Doctors");
                throw;
            }
        }

        public Doctor? Get(Guid id)
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                return connection.QueryFirstOrDefault<Doctor>("SELECT * FROM Doctors WHERE Id = @Id", new { Id = id.ToString() });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching doctor {id}", ex);
                _exceptionService.LogException(ex, $"Get Doctor {id}");
                throw;
            }
        }

        public Guid Create(Doctor doctor)
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                doctor.Id = Guid.NewGuid();
                var sql = "INSERT INTO Doctors (Id, Name, Specialty, Email) VALUES (@Id, @Name, @Specialty, @Email);";
                connection.Execute(sql, doctor);
                return doctor.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating doctor", ex);
                _exceptionService.LogException(ex, "Create Doctor");
                throw;
            }
        }

        public bool Update(Doctor doctor)
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                var sql = "UPDATE Doctors SET Name = @Name, Specialty = @Specialty, Email = @Email WHERE Id = @Id";
                return connection.Execute(sql, doctor) > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating doctor {doctor.Id}", ex);
                _exceptionService.LogException(ex, $"Update Doctor {doctor.Id}");
                throw;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                var sql = "DELETE FROM Doctors WHERE Id = @Id";
                return connection.Execute(sql, new { Id = id.ToString() }) > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting doctor {id}", ex);
                _exceptionService.LogException(ex, $"Delete Doctor {id}");
                throw;
            }
        }
    }
}
