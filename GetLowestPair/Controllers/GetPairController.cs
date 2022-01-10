using GetLowestPair.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetLowestPair.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GetPairController : ControllerBase
{
    private const string DesiredSumMsg = "Your desired sum was:";
    private const string LowestPairFoundMsg = "The lowest summed pair found was:";
    private const string NoPairFoundMsg = "No pair was found that can resolve to the desired sum of:";

    [HttpPost(Name = "PostArrayAndDesiredSum")]
    public DesiredPairResult PostUserArrayAndDesiredSum([FromBody] int[] arrayValues, int desiredSum)
    {
        var sorted = SortArray(arrayValues);
        return FindDesiredSum(sorted, desiredSum);
    }

    private static int[] SortArray(IEnumerable<int> arrayValues)
    {
        return arrayValues.Where(av => av != 0).Distinct().OrderBy(av => av).ToArray();
    }

    private static DesiredPairResult FindDesiredSum(IReadOnlyList<int> sorted, int desiredSum)
    {
        var dpr = new DesiredPairResult
        {
            DesiredSum = desiredSum
        };

        for (var i = 0; i < sorted.Count; i++)
        {
            for (var j = 0; j < sorted.Count; j++)
            {
                if (i == j) continue;
                if (sorted[i] + sorted[j] != desiredSum) continue;
                dpr.FirstLowestPair = sorted[i];
                dpr.SecondLowestPair = sorted[j];
                dpr.Message = $"{DesiredSumMsg} {desiredSum}. {LowestPairFoundMsg} {dpr.FirstLowestPair} + {dpr.SecondLowestPair}.";
                return dpr;
            }

            if (dpr.FirstLowestPair == 0 || dpr.SecondLowestPair == 0)
            {
                dpr.Message = $"{NoPairFoundMsg} {desiredSum}";
            }
        }

        return dpr;
    }
}