using GetLowestPair.Interfaces;
using GetLowestPair.Models;
using Microsoft.AspNetCore.Mvc;

namespace GetLowestPair.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GetPairController : ControllerBase
{
    private readonly ICalculationHandler _calcHandler;

    public GetPairController(ICalculationHandler calcHandler)
    {
        _calcHandler = calcHandler;
    }

    [HttpPost(Name = "ArrayDesiredSum")]
    public DesiredPairResult ArrayDesiredSum([FromBody] int[] arrayValues, int desiredSum)
    {
        var sortedArray = SortArray(arrayValues);
        return _calcHandler.FindDesiredSum(sortedArray, desiredSum);
    }

    private static int[] SortArray(IEnumerable<int> arrayValues)
    {
        return arrayValues.Where(av => av != 0).Distinct().OrderBy(av => av).ToArray();
    }
}