using dotnet_version.Models;

namespace Infrastructure.Persistence.AdoNet.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAll();
        Doctor? Get(Guid id);
        Guid Create(Doctor doctor);
        bool Update(Doctor doctor);
        bool Delete(Guid id);
    }
}
