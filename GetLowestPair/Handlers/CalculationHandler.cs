using GetLowestPair.Constants;
using GetLowestPair.Interfaces;
using GetLowestPair.Models;

namespace GetLowestPair.Handlers;

public class CalculationHandler : ICalculationHandler
{
    public DesiredPairResult FindDesiredSum(int[] arrayValues, int desiredSum)
    {
        var sorted = arrayValues.Where(av => av != 0).Distinct().OrderBy(av => av).ToArray();

        var dpr = new DesiredPairResult
        {
            DesiredSum = desiredSum
        };

        for (var i = 0; i < sorted.Length; i++)
        {
            for (var j = 0; j < sorted.Length; j++)
            {
                if (i == j) continue;
                if (sorted[i] + sorted[j] != desiredSum) continue;
                dpr.FirstLowestPair = sorted[i];
                dpr.SecondLowestPair = sorted[j];
                dpr.Message = $"{Message.DesiredSum} {dpr.DesiredSum}. {Message.LowestPairFound} {dpr.FirstLowestPair} and {dpr.SecondLowestPair}.";
                return dpr;
            }
        }

        dpr.Message = $"{Message.NoPairFound} {desiredSum}";
        return dpr;
    }
}