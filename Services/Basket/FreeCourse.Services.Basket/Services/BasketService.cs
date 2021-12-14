using FreeCourse.Services.Basket.Dtos;
using FreeCourse.Shared.Dtos;
using FreeCourse.Shared.Services;
using System.Text.Json;

namespace FreeCourse.Services.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete(Guid userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId.ToString());
            return status ? Response<bool>.Success(200) : Response<bool>.Fail("Basket not found ", 404);
        }

        public async Task<Response<BasketDto>> GetBasket(Guid userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId.ToString());
            if (string.IsNullOrEmpty(existBasket))
            {
                return Response<BasketDto>.Fail("Basket not found",404);
            }
            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(existBasket), 200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserId.ToString(),JsonSerializer.Serialize<BasketDto>(basketDto));
            return status ? Response<bool>.Success(200) : Response<bool>.Fail("Basket could not update or save", 500);
        }
    }
}
