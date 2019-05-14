package models.math;

import java.util.ArrayList;

public class Algorithms
{
    public static <T extends Comparable<T>> T maxValue(Iterable<T> iterable)
    {
        T maxValue = iterable.iterator().next();

        for (T value : iterable)
        {
            if (value.compareTo(maxValue) == 1)
            {
                maxValue = value;
            }
        }

        return maxValue;
    }
    public static int digitSum(int number)
    {
        int sum = 0;

        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }

        return sum;
    }
    public static Iterable<Integer> transformNumberToDigitSum(Iterable<Integer> iterable)
    {
        ArrayList<Integer> result = new ArrayList<>();
        for (Integer value: iterable)
        {
            result.add(digitSum(value));
        }
        return result;
    }
}
