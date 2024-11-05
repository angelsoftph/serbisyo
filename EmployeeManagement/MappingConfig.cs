using EmployeeManagement.Dto;
using EmployeeManagement.Models;
using Mapster;

namespace EmployeeManagement
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Employee, ViewEmployeeDto>.NewConfig()
                .Map(dest => dest.FirstName, src => src.User.FirstName)
                .Map(dest => dest.LastName, src => src.User.LastName)
                .Map(dest => dest.Email, src => src.User.Email)
                .Map(dest => dest.Phone, src => src.User.Phone)
                .Map(dest => dest.CategoryName, src => src.Category.Name);

            TypeAdapterConfig<AddEmployeeDto, Employee>.NewConfig()
                .Map(dest => dest.CategoryId, src => src.CategoryId)
                .Ignore(dest => dest.Id)
                .Ignore(dest => dest.UserId);
        }
    }
}
