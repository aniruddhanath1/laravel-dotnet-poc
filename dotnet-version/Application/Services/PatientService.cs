using dotnet_version.Models;
using dotnet_version.Repositories;

namespace Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;
        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Patient> GetAll() => _repo.GetAll();
        public Patient? Get(Guid id) => _repo.Get(id);
        public Guid Create(Patient patient) => _repo.Create(patient);
        public bool Update(Patient patient) => _repo.Update(patient);
        public bool Delete(Guid id) => _repo.Delete(id);
    }
}
