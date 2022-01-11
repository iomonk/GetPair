using GetLowestPair.Constants;
using GetLowestPair.Interfaces;
using GetLowestPair.Models;

namespace GetLowestPair.Handlers;

public class CalculationHandler : ICalculationHandler
{
    public DesiredPairResult FindDesiredSum(IReadOnlyList<int> sorted, int desiredSum)
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
                dpr.Message = $"{Message.DesiredSum} {dpr.DesiredSum}. {Message.LowestPairFound} {dpr.FirstLowestPair} and {dpr.SecondLowestPair}.";
                return dpr;
            }
        }

        dpr.Message = $"{Message.NoPairFound} {desiredSum}";
        return dpr;
    }
}