using AutoMapper;
using EducationApplication.BLL.Dtos.InstructorDtos;
using EducationApplication.BLL.Dtos.StudentDtos;
using EducationApplication.DAL.Data.Model;

namespace EducationApplication.BLL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentReadDto>().ReverseMap();
            CreateMap<Student, StudentAddDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();



            /*CreateMap<InstrurctorUpdateDto, InstructorReadDto>().ReverseMap();*/
            CreateMap<Instructor, InstructorReadDto>().ReverseMap();
            CreateMap<Instructor, InstructorAddDto>().ReverseMap();
            CreateMap<Instructor, InstructorUpdateDto>().ReverseMap();
            /*CreateMap<Instructor, InstructorStatusDto>().ReverseMap()*/

            CreateMap<Attempts, AttemptDetailsDto>();
            /*CreateMap<AnswerDto, Answers>().ReverseMap();
            CreateMap<Quizzes, QuizReadByIdDto>().ReverseMap();*/
            CreateMap<Student, StudentReadDto>().ReverseMap();
            CreateMap<Attempts, StudentAttemptDto>().ReverseMap();

            /*CreateMap<Instructor, UpdateInstructorProfileDto>().ReverseMap();*/
        }
    }
}
