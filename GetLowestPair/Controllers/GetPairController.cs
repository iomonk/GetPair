using GetLowestPair.Constants;
using GetLowestPair.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetLowestPair.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GetPairController : ControllerBase
{
    [HttpPost(Name = "ArrayDesiredSum")]
    public DesiredPairResult ArrayDesiredSum([FromBody] int[] arrayValues, int desiredSum)
    {
        var sortedArray = SortArray(arrayValues);
        return FindDesiredSum(sortedArray, desiredSum);
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
                dpr.Message = $"{Message.DesiredSum} {desiredSum}. {Message.LowestPairFound} {dpr.FirstLowestPair} + {dpr.SecondLowestPair}.";
                return dpr;
            }

            if (dpr.FirstLowestPair == 0 || dpr.SecondLowestPair == 0) dpr.Message = $"{Message.NoPairFound} {desiredSum}";
            
        }

        return dpr;
    }
}