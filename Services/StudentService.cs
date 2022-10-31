using EFcore.DTOs;
using EFcore.Models;
using EFcore.Repositories;

namespace EFcore.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public AddStudentResponse? Create(AddStudentRequest createModel)
        {
            var newStudent = new Student
            {
                FirstName = createModel.FirstName,
                LastName = createModel.LastName,
                City = createModel.City,
                State = createModel.State
            };

            var createdStudent = _studentRepository.Create(newStudent);

            _studentRepository.SaveChanges();

            return new AddStudentResponse
            {
                Id = createdStudent.Id,
                FirstName = createdStudent.FirstName,
                LastName = createdStudent.LastName
            };
        }

        public bool Delete(int id)
        {
            var deleteStudent = _studentRepository.Get(student => student.Id == id);

            if (deleteStudent == null) return false;

            bool isSucceeded = _studentRepository.Delete(deleteStudent);

            _studentRepository.SaveChanges();

            return isSucceeded;
        }

        public IEnumerable<GetStudentResponse> GetAll()
        {
            return _studentRepository
                .GetAll(student => true)
                .Select(student => new GetStudentResponse
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    City = student.City,
                    State = student.State
                });
        }

        public GetStudentResponse? GetById(int id)
        {
            var student = _studentRepository.Get(student => student.Id == id);

            return student == null
                ? null
                : new GetStudentResponse
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    City = student.City,
                    State = student.State
                };
        }

        public UpdateStudentResponse? Update(int id, UpdateStudentRequest updateModel)
        {
            var student = _studentRepository.Get(student => student.Id == id);

            if (student == null) return null;

            student.FirstName = updateModel.FirstName;
            student.LastName = updateModel.LastName;
            student.City = updateModel.City;
            student.State = updateModel.State;

            var updatedStudent = _studentRepository.Update(student);
            
            _studentRepository.SaveChanges();

            return new UpdateStudentResponse
            {
                FirstName = updatedStudent.FirstName,
                LastName = updatedStudent.LastName,
                City = updatedStudent.City,
                State = updatedStudent.State
            };
        }
    }
}