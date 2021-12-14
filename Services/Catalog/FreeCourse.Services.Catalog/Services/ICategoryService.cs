using FreeCourse.Services.API.Dtos;
using FreeCourse.Services.API.Models;
using FreeCourse.Shared.Dtos;

namespace FreeCourse.Services.API.Services
{
    public interface ICategoryService
    {
        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> GetByIdAsync(Guid id);
    }
}
