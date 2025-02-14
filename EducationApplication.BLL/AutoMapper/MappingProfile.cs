using AutoMapper;
using EducationApplication.BLL.Dtos.CoursesDtos;
using EducationApplication.BLL.Dtos.EnrollmentsDtos;
using EducationApplication.BLL.Dtos.InstructorDtos;
using EducationApplication.BLL.Dtos.StudentDtos;
using EducationApplication.DAL.Data.Model;

namespace EducationApplication.BLL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Users Mapping
            CreateMap<Student, StudentReadDto>().ReverseMap();
            CreateMap<Student, StudentAddDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();

            CreateMap<Instructor, InstructorReadDto>().ReverseMap();
            CreateMap<Instructor, InstructorAddDto>().ReverseMap();
            CreateMap<Instructor, InstructorUpdateDto>().ReverseMap();

            CreateMap<Attempts, AttemptDetailsDto>();
            /*CreateMap<AnswerDto, Answers>().ReverseMap();
            CreateMap<Quizzes, QuizReadByIdDto>().ReverseMap();*/
            CreateMap<Student, StudentReadDto>().ReverseMap();
            CreateMap<Attempts, StudentAttemptDto>().ReverseMap();

            //Courses Mapping
            CreateMap<Course, CourseReadDto>().ReverseMap();
            CreateMap<Course, CourseAddDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();

            //Enrollment Mapping
            CreateMap<Enrollment, EnrollmentsReadDto>().ReverseMap();
            CreateMap<Enrollment, EnrollmentsAddDto>().ReverseMap();
        }
    }
}
