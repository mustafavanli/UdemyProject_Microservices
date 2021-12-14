using FreeCourse.Services.Basket.Dtos;
using FreeCourse.Services.Basket.Services;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Basket.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BasketController : CustomBaseController
    {
        private readonly IBasketService _basketService;
        private ISharedIdentityService _shardIdentityService;

        public BasketController(IBasketService basketService, ISharedIdentityService shardIdentityService)
        {
            _basketService = basketService;
            _shardIdentityService = shardIdentityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetBasked()
        {
            return CreateActionResultInstance(await _basketService.GetBasket(_shardIdentityService.GetUserId));
        }
        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            basketDto.UserId = _shardIdentityService.GetUserId;
            var response = await _basketService.SaveOrUpdate(basketDto);
            return CreateActionResultInstance(response);

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            return CreateActionResultInstance(await _basketService.Delete(_shardIdentityService.GetUserId));
        }
    }
}
