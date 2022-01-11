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
        return _calcHandler.FindDesiredSum(arrayValues, desiredSum);
    }
}