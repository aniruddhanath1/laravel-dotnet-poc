using dotnet_version.Models;
using dotnet_version.Repositories;

namespace Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;
        public DoctorService(IDoctorRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Doctor> GetAll() => _repo.GetAll();
        public Doctor? Get(Guid id) => _repo.Get(id);
        public Guid Create(Doctor doctor) => _repo.Create(doctor);
        public bool Update(Doctor doctor) => _repo.Update(doctor);
        public bool Delete(Guid id) => _repo.Delete(id);
    }
}
