using TechChallenge.Library.Entities.Response;

namespace TechChallenge.Api.Modules.TechChallenge
{
    public class TechChallengeService
    {
        public async Task<bool> IsPrime(int number)
        {
            bool isPrime = true;

            await Task.Run(() => {

                if (number == 1)
                    isPrime = false;
                else
                {
                    var possibleFactors = Math.Sqrt(number);

                    for (var factor = 2; factor <= possibleFactors; factor++)
                    {
                        if (number % factor == 0)
                        {
                            isPrime = false;
                        }
                    }
                }
            });

            return isPrime;
        }

        public async Task<List<DivisorResponse>> GetDivisors(int number)
        {
            List<DivisorResponse> divisors = new List<DivisorResponse>();

            await Task.Run(async () =>  {
                for (int divisor = 1; divisor <= number; divisor++)
                {
                    if ((number % divisor) == 0)
                    {
                        var isPrime = await IsPrime(divisor);

                        var divisorResponse = new DivisorResponse()
                        {
                            Number = divisor,
                            IsPrime = isPrime
                        };

                        divisors.Add(divisorResponse);
                    }
                }
            });

            return divisors;
        }
    }
}
