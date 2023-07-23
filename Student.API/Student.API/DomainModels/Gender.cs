using System.ComponentModel.DataAnnotations;

namespace Student.API.DomainModels
{
    public class Gender
    {
        [Key]
        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
