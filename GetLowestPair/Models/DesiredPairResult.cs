namespace GetLowestPair.Models;

public class DesiredPairResult
{
    public int DesiredSum { get; set; }
    public int FirstLowestPair { get; set; }
    public int SecondLowestPair { get; set; }
    public string? Message { get; set; }
}