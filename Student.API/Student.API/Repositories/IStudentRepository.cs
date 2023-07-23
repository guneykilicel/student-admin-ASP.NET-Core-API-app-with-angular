using Student.API.DataModels;

namespace Student.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student.API.DataModels.Student>> GetStudentsAsync ();

        Task<Student.API.DataModels.Student> GetStudentAsync(Guid studentId);

        Task<List<Student.API.DataModels.Gender>> GetGendersAsync();
        Task<bool> Exists(Guid studentId);
        Task<DataModels.Student> UpdateStudent(Guid studentId, DataModels.Student student);
        Task<DataModels.Student> DeleteStudent(Guid studentId);
        Task<DataModels.Student> AddStudent(DataModels.Student student);

        Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl);
    }
}
