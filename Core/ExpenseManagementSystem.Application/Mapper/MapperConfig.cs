using AutoMapper;
using ExpenseManagementSystem.Application.Dtos.Category;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using ExpenseManagementSystem.Application.Dtos.Expense;
using ExpenseManagementSystem.Domain.Entities;


namespace ExpenseManagementSystem.Application.Mapper
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CategoryRequestDto, Category>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<Category, CategoryResponseDto>();


            CreateMap<ExpenditureRequestDto, Expenditure>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));

            CreateMap<Expenditure, ExpenditureResponseDto>();


            CreateMap<ExpenseRequestDto, Expense>()
                .ForMember(dest => dest.SubmissionDate, opt => opt.Ignore())
                .ForMember(dest => dest.StatusId, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());

            CreateMap<Expense, ExpenseResponseDto>()
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name));
        }
    }
}
