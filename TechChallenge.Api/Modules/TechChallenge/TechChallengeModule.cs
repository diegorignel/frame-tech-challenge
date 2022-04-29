using Microsoft.AspNetCore.Mvc;
using TechChallenge.Api.Abstractions;
using TechChallenge.Library.Entities.Response;

namespace TechChallenge.Api.Modules.TechChallenge
{
    public class TechChallengeModule : IModule
    {
        public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<TechChallengeService>();

            return builder;
        }

        public IEndpointRouteBuilder MapEndpoint(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/get-divisors", GetDivisors);

            return endpoints;
        }

        private async Task<IResult> GetDivisors([FromQuery] int number, [FromServices] TechChallengeService service)
        {
            List<DivisorResponse> response = new List<DivisorResponse>();

            try
            {
                response = await service.GetDivisors(number);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

            return response.Any() ? Results.Ok(response) : Results.NoContent();
        }
    }
}
