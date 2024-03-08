namespace SomeAlgorithm;

public static class NumberUtilities
{
    public static (int smallest, int largest) GetSmallestAndLargest(IEnumerable<int> numbers)
    {
        return (numbers.Min(), numbers.Max());
    }

    public static (int smallest, int largest) GetSmallestAndLargestImproved(IEnumerable<int> numbers)
    {
        var smallest = int.MaxValue;
        var largest = int.MinValue;

        (smallest, largest) = numbers.Aggregate((smallest, largest), (tuple, current) =>
        {
            if (tuple.smallest > current)
            {
                tuple.smallest = current;
            }

            if (tuple.largest < current)
            {
                tuple.largest = current;
            }

            return tuple;
        });

        return (smallest, largest);
    }
}