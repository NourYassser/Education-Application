using AutoMapper;
using EducationApplication.BLL.Dtos.InstructorDtos;
using EducationApplication.DAL.Data.Model;
using EducationApplication.DAL.Repos.InstructorRpo;

namespace EducationApplication.BLL.Manager.InstructorManager
{
    public class InstructorManager : IinstructorManager
    {
        private readonly IinstructorRpo _repo;
        private readonly IMapper _mapper;

        public InstructorManager(IinstructorRpo rpo, IMapper mapper)
        {
            _repo = rpo;
            _mapper = mapper;
        }

        public IEnumerable<InstructorReadDto> GetAllInstructorsAsync()
        {
            return _mapper.Map<List<InstructorReadDto>>(_repo.GetAllInstructors());
        }

        public InstructorReadDto GetInstructorByIdAsync(int Id)
        {
            var ins = _repo.GetInstructorById(Id);
            if (ins is null)
            {
                return null;
            }
            //Auto-Mapping
            return _mapper.Map<InstructorReadDto>(ins);
        }

        public void AddInstructorAsync(InstructorAddDto dto)
        {
            var ins = _mapper.Map<Instructor>(dto);
            ins.UserType = TypeUser.Instructor.ToString();
            _repo.Add(ins);
            _repo.Savechange();

        }

        public void UpdateInstructorAsync(InstructorUpdateDto dto)
        {
            var ins = _repo.GetInstructorById(dto.Id);
            //Auto-Mapping
            _mapper.Map<InstructorUpdateDto>(ins);
            _repo.Savechange();
        }

        public void DeleteInstructorAsync(int Id)
        {
            var ins = _repo.GetInstructorById(Id);
            if (ins == null)
            {
                throw new Exception("Student not found");
            }

            ins.IsDeleted = true; // Soft delete
            _repo.Savechange();
        }
        public void HardDeleteInstructorAsync(int Id)
        {
            var ins = _repo.GetInstructorById(Id);
            if (ins == null)
            {
                throw new Exception("Student not found");
            }

            _repo.DeleteInstructor(int.Parse(ins.Id));
            _repo.Savechange();
        }
    }
}
