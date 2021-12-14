using Dapper;
using FreeCourse.Shared.Dtos;
using Npgsql;
using System.Data;

namespace FreeCourse.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConnection = new NpgsqlConnection("Server=127.0.0.1;Port=5433;Userid=postgres;Password=123456789;Pooling=false;MinPoolSize=1;MaxPoolSize=20;Timeout=15;SslMode=Disable;Database=DiscountDb");
           
        }

        public async Task<Response<NoContent>> Delete(Guid id)
        {
            var status = await _dbConnection.ExecuteAsync("delete * from discount where id=@Id",new {Id=id});
            return status > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Discount not found", 404);
        }

        public async Task<Response<List<Models.Discount>>> GetAll()
        {
            var discount = await _dbConnection.QueryAsync<Models.Discount>("Select * from discount");
            return Response<List<Models.Discount>>.Success(discount.ToList(), 200);


        }

        public async Task<Response<Models.Discount>> GetByCodeAndUserId(string code, Guid userId)
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("Select * from discount where code=@Code and userId=@UserId", new {UserId=userId,Code=code});

            var hashDiscount = discounts.FirstOrDefault();

            return discounts != null ? Response<Models.Discount>.Success(hashDiscount, 200) : Response<Models.Discount>.Fail("Discount not found",204);




        }

        public async Task<Response<Models.Discount>> GetById(Guid id)
        {
            var discounts = (await _dbConnection.QueryAsync<Models.Discount>("Select * from discount where id=@Id",new {Id=id})).SingleOrDefault();
            if (discounts == null)
                return Response<Models.Discount>.Fail("Discount not found",404);
            return Response<Models.Discount>.Success(discounts, 200);

        }

        public async Task<Response<NoContent>> Save(Models.Discount discount)
        {
            discount.CreatedTime = DateTime.UtcNow;
            discount.Id = Guid.NewGuid();
            var status = await _dbConnection.ExecuteAsync("Insert into discount(id,userid,rate,code,createdtime) VALUES(@Id,@UserId,@Rate,@Code,@CreatedTime)",discount);
            if (status > 0)
                return Response<NoContent>.Success(204);
           
           return Response<NoContent>.Fail("an error occurred while adding", 500);

        }

        public async Task<Response<NoContent>> Update(Models.Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("update discount set userid=@UserId, code=@Code, rate=@Rate where id=@Id", new { Id = discount.Id, UserId = discount.UserId, Code = discount.Code, Rate = discount.Rate });

            if (status > 0)
                return Response<NoContent>.Success(204);
            return Response<NoContent>.Fail("Discount not found",404);
        }
    }
}
