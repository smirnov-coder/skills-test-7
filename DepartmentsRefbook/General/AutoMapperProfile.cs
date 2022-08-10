using AutoMapper;
using DepartmentsRefbook.Domain.Entities;
using DepartmentsRefbook.Models;

namespace DepartmentsRefbook.General
{
    /// <summary>
    /// Настройки преборазования классов для AutoMapper
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CompanyModel, Company>().ReverseMap();
            CreateMap<DepartmentModel, Department>().ReverseMap();
            CreateMap<BranchModel, Branch>().ReverseMap();
            CreateMap<Company, CompanyViewModel>();
            CreateMap<Department, DepartmentViewModel>()
                .ForMember(d => d.RowVersion, opt => opt.ConvertUsing(new ByteArrayToStringConverter()));
            CreateMap<Branch, BranchViewModel>()
                .ForMember(d => d.RowVersion, opt => opt.ConvertUsing(new ByteArrayToStringConverter()));
        }
    }
}
