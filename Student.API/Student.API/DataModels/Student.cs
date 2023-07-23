using System.ComponentModel.DataAnnotations.Schema;

namespace Student.API.DataModels
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string? ProfileImageUrl { get; set; }

        [ForeignKey("Gender")]
        public Guid GenderId { get; set; }

        public Gender Gender { get; set; }
        public Address Address { get; set; }

        //public virtual Gender GenderData { get; set; }


    }
}
