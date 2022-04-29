using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Api.Modules.TechChallenge;
using TechChallenge.Library.Entities.Response;
using Xunit;

namespace TechChallenge.Test
{
    public class TechChallengeServiceTest
    {
        [Theory]
        [InlineData(2)]
        [InlineData(31)]
        [InlineData(47)]
        [InlineData(71)]
        [InlineData(89)]
        public async Task VerifyIfNumberIsPrime(int number)
        {
            TechChallengeService service = new TechChallengeService();
            var result = await service.IsPrime(number);

            Assert.True(result);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(28)]
        [InlineData(56)]
        [InlineData(77)]
        [InlineData(95)]
        public async Task VerifyIfNumberIsNotPrime(int number)
        {
            TechChallengeService service = new TechChallengeService();
            var result = await service.IsPrime(number);

            Assert.False(result);
        }

        [Fact]

        public async Task GetDivisors()
        {
            TechChallengeService service = new TechChallengeService();

            var divisors = await service.GetDivisors(6);

            var divisorResult = new List<DivisorResponse>()
            {
                new DivisorResponse()
                {
                    IsPrime = false,
                    Number = 1
                },
                new DivisorResponse()
                {
                    IsPrime = true,
                    Number = 2
                },
                new DivisorResponse()
                {
                    IsPrime = true,
                    Number = 3
                },
                new DivisorResponse()
                {
                    IsPrime = false,
                    Number = 6
                }
            };

            Assert.Equal(divisors.Count, divisorResult.Count);
        }
    }
}
