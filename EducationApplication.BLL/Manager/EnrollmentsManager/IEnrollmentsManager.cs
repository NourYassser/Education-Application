using AutoMapper;
using EducationApplication.BLL.Dtos.EnrollmentsDtos;
using EducationApplication.DAL.Data.Model;
using EducationApplication.DAL.Repos.EnrollmentRpo;

namespace EducationApplication.BLL.Manager.EnrollmentsManager
{
    public interface IEnrollmentsManager
    {
        public IEnumerable<EnrollmentsReadDto> GetAllEnrollmentsAsync();
        public void AddEnrollmentsAsync(EnrollmentsAddDto dto);
        public void DeleteEnrollmentsAsync(int Id);
        public void HardDeleteEnrollmentsAsync(int Id);
    }
    public class EnrollmentsManager : IEnrollmentsManager
    {
        private readonly IEnrollmentRepo _repo;
        private readonly IMapper _mapper;

        public EnrollmentsManager(IEnrollmentRepo rpo, IMapper mapper)
        {
            _repo = rpo;
            _mapper = mapper;
        }

        public IEnumerable<EnrollmentsReadDto> GetAllEnrollmentsAsync()
        {
            return _mapper.Map<List<EnrollmentsReadDto>>(_repo.GetAllEnrollments());
        }

        public void AddEnrollmentsAsync(EnrollmentsAddDto dto)
        {
            var en = _mapper.Map<Enrollment>(dto);
            _repo.Add(en);
            _repo.Savechange();

        }
        public void DeleteEnrollmentsAsync(int Id)
        {
            var en = _repo.GetEnrollmentById(Id);
            if (en == null)
            {
                throw new Exception("Enrollment not found");
            }

            en.IsDeleted = true; // Soft delete
            _repo.Savechange();
        }
        public void HardDeleteEnrollmentsAsync(int Id)
        {
            var en = _repo.GetEnrollmentById(Id);
            if (en == null)
            {
                throw new Exception("Course not found");
            }

            _repo.DeleteEnrollment(en.Id);
            _repo.Savechange();
        }
    }
}
