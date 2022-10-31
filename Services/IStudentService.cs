using EFcore.DTOs;

namespace EFcore.Services
{
    public interface IStudentService
    {
        IEnumerable<GetStudentResponse> GetAll();
        GetStudentResponse? GetById(int id);
        AddStudentResponse? Create(AddStudentRequest createModel);
        UpdateStudentResponse? Update(int id, UpdateStudentRequest updateModel);
        bool Delete(int id);
    }
}