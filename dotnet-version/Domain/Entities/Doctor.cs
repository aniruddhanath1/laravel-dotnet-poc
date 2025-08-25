namespace Domain.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Email { get; set; }
    }
}
