using System.Runtime.CompilerServices;

public class ShortestSubarrayWithORatLeastKII{
    
     private static readonly int NOT_POSSIBLE_TO_CREATE_SUBARRAY = -1;
    private static readonly int TOTAL_BITS = 32;
    private readonly int[] bits = new int[TOTAL_BITS];
    private int valueBitwiseOR;

    public int MinimumSubarrayLength(int[] input, int target)
    {
        int left = 0;
        int right = 0;
        int minLengthSubarray = int.MaxValue;

        while (right < input.Length)
        {
            CountBits(input[right]);

            while (left <= right && valueBitwiseOR >= target)
            {
                minLengthSubarray = Math.Min(minLengthSubarray, right - left + 1);
                DiscountBits(input[left]);
                ++left;
            }
            ++right;
        }
        return (minLengthSubarray != int.MaxValue)
            ? minLengthSubarray
            : NOT_POSSIBLE_TO_CREATE_SUBARRAY;
    }

    private void CountBits(int value)
    {   Console.WriteLine(" Count Bits *****************************");
        Console.WriteLine("valueBitwiseOR " +valueBitwiseOR + " value " +value);
        valueBitwiseOR = (valueBitwiseOR | value);
                   
        for (int bitPosition = 0; bitPosition < TOTAL_BITS; ++bitPosition)
        { Console.WriteLine("Bit valueBitwiseOR " +valueBitwiseOR  + " Total Bits "+TOTAL_BITS + "  bits[bitPosition]  "+  bits[bitPosition] );
            bits[bitPosition] += ((value & (1 << bitPosition)) != 0) ? 1 : 0;
        }
    }

    private void DiscountBits(int value)
    { Console.WriteLine("Discount Bits*****************************");
        for (int bitPosition = 0; bitPosition < TOTAL_BITS; ++bitPosition)
        {
            Console.WriteLine("DiscountBits " +bitPosition  + " Total Bits "+TOTAL_BITS +"  bits[bitPosition]  "+  bits[bitPosition] );

            bits[bitPosition] -= ((value & (1 << bitPosition)) != 0) ? 1 : 0;
            if (bits[bitPosition] == 0)
            {
                valueBitwiseOR = (valueBitwiseOR & (~(1 << bitPosition)));
            }
        }
    }
}