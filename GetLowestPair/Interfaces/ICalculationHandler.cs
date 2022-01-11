using GetLowestPair.Models;

namespace GetLowestPair.Interfaces;

public interface ICalculationHandler
{
    DesiredPairResult FindDesiredSum(IReadOnlyList<int> sorted, int desiredSum);
}