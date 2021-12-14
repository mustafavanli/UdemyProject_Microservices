using FreeCourse.Shared.Dtos;

namespace FreeCourse.Services.Discount.Services
{
    public interface IDiscountService
    {
        Task<Response<List<Models.Discount>>> GetAll();
        Task<Response<Models.Discount>> GetById(Guid id);

        Task<Response<NoContent>> Save(Models.Discount discount);

        Task<Response<NoContent>> Update(Models.Discount discount);

        Task<Response<NoContent>> Delete(Guid id);

        Task<Response<Models.Discount>> GetByCodeAndUserId(string code,Guid userId);

    }
}
