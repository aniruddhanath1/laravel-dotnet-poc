using dotnet_version.Models;

namespace Infrastructure.Persistence.AdoNet.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        Patient? Get(Guid id);
        Guid Create(Patient patient);
        bool Update(Patient patient);
        bool Delete(Guid id);
    }
}
