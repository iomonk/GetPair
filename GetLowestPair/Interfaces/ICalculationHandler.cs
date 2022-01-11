using GetLowestPair.Models;

namespace GetLowestPair.Interfaces;

public interface ICalculationHandler
{
    DesiredPairResult FindDesiredSum(int[] arrayValues, int desiredSum);
}