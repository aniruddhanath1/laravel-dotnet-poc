using dotnet_version.Models;

namespace Application.Services
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAll();
        Doctor? Get(Guid id);
        Guid Create(Doctor doctor);
        bool Update(Doctor doctor);
        bool Delete(Guid id);
    }
}
