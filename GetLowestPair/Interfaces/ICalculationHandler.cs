using GetLowestPair.Models;

namespace GetLowestPair.Interfaces;

public interface ICalculationHandler
{
    DesiredPairResult FindDesiredSum(IEnumerable<int> arrayValues, int desiredSum);
}