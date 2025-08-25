using Dapper;
using Microsoft.Data.Sqlite;
using dotnet_version.Models;

namespace Infrastructure.Persistence.AdoNet.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly string _connectionString = "Data Source=database.sqlite";
        private readonly Services.LoggerService _logger = new Services.LoggerService();
        private readonly Services.ExceptionService _exceptionService = new Services.ExceptionService();

        public IEnumerable<Patient> GetAll()
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                return connection.Query<Patient>("SELECT * FROM Patients");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error fetching all patients", ex);
                _exceptionService.LogException(ex, "GetAll Patients");
                throw;
            }
        }

        public Patient? Get(Guid id)
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                return connection.QueryFirstOrDefault<Patient>("SELECT * FROM Patients WHERE Id = @Id", new { Id = id.ToString() });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching patient {id}", ex);
                _exceptionService.LogException(ex, $"Get Patient {id}");
                throw;
            }
        }

        public Guid Create(Patient patient)
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                patient.Id = Guid.NewGuid();
                var sql = "INSERT INTO Patients (Id, Name, Email, DateOfBirth) VALUES (@Id, @Name, @Email, @DateOfBirth);";
                connection.Execute(sql, patient);
                return patient.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating patient", ex);
                _exceptionService.LogException(ex, "Create Patient");
                throw;
            }
        }

        public bool Update(Patient patient)
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                var sql = "UPDATE Patients SET Name = @Name, Email = @Email, DateOfBirth = @DateOfBirth WHERE Id = @Id";
                return connection.Execute(sql, patient) > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating patient {patient.Id}", ex);
                _exceptionService.LogException(ex, $"Update Patient {patient.Id}");
                throw;
            }
        }

        public bool Delete(Guid id)
        {
            try
            {
                using var connection = new SqliteConnection(_connectionString);
                var sql = "DELETE FROM Patients WHERE Id = @Id";
                return connection.Execute(sql, new { Id = id.ToString() }) > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting patient {id}", ex);
                _exceptionService.LogException(ex, $"Delete Patient {id}");
                throw;
            }
        }
    }
}
