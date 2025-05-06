using AutoMapper;
using ExpenseManagementSystem.Application.Dtos.Category;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using ExpenseManagementSystem.Application.Dtos.Expense;
using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;
using ExpenseManagementSystem.Application.Dtos.Payment;
using ExpenseManagementSystem.Application.Dtos.User;
using ExpenseManagementSystem.Domain.Entities;
using ExpenseManagementSystem.Domain.Entities.Identity;

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
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))         
                .ForMember(dest => dest.PaymentId, opt => opt.Ignore())          
                .ForMember(dest => dest.Payment, opt => opt.Ignore());

            CreateMap<Expenditure, ExpenditureResponseDto>();
                

            CreateMap<ExpenseRequestDto, Expense>()
                .ForMember(dest => dest.SubmissionDate, opt => opt.Ignore())
                .ForMember(dest => dest.StatusId, opt => opt.Ignore())
                .ForMember(dest => dest.UserId, opt => opt.Ignore());


            CreateMap<Expense, ExpenseResponseDto>()
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Expenditures.Sum(e => e.Amount)))
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => src.Status.Name))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Expenditures, opt => opt.MapFrom(src => src.Expenditures));



            CreateMap<ExpenseStatusRequestDto, ExpenseStatus>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true)); 

            CreateMap<ExpenseStatus, ExpenseStatusResponseDto>();


            CreateMap<PaymentRequestDto, Payment>();

            CreateMap<Payment, PaymentResponseDto>();


            CreateMap<UserProfileRequestDto, AppUser>()
                .ForMember(dest => dest.Iban, opt => opt.MapFrom(src => src.Iban))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<AppUser, UserProfileResponseDto>()
                .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));


        }
    }
}
