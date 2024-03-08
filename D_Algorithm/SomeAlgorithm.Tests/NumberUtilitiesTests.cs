using Shouldly;
using Xunit.Abstractions;

namespace SomeAlgorithm.Tests;

public class NumberUtilitiesTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void GetSmallestAndLargest_WhenGivenArray_ThenFindMinMax()
    {
        int[] array = [1, 2, 3, 4, 5];

        var (smallest, largest) = NumberUtilities.GetSmallestAndLargest(array);
        
        smallest.ShouldBe(1);
        largest.ShouldBe(5);
        
        outputHelper.WriteLine($"Found {smallest} and {largest}");
    }
    
    [Fact]
    public void GetSmallestAndLargest_WhenGivenArrayInReverse_ThenFindMinMax()
    {
        int[] array = [5, 4, 3, 2, 1];

        var (smallest, largest) = NumberUtilities.GetSmallestAndLargest(array);
        
        smallest.ShouldBe(1);
        largest.ShouldBe(5);
        
        outputHelper.WriteLine($"Found {smallest} and {largest}");
    }
}