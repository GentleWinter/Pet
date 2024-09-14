using System.ComponentModel.DataAnnotations;

namespace Pet.Domain.Entities
{
    public class PetEntity
    {
        [Key]
        public int Id { get; set; }
        public int TutorId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Description { get; set; }
        public string? PetBreed { get; set; }
    }
}
