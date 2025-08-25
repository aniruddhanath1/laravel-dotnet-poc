using dotnet_version.Models;

namespace Application.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();
        Patient? Get(Guid id);
        Guid Create(Patient patient);
        bool Update(Patient patient);
        bool Delete(Guid id);
    }
}
