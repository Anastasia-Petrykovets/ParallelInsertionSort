namespace ParallelInsertionSort;

public class InsertionSortDouble
{
    public double[] CreateDoubleArray(int count)
    {
        Random rnd = new Random();
        double[] numbersArray = new double[count];
        
        for (int i = 0; i <= numbersArray.Length - 1; i++)
        {
            numbersArray[i] = rnd.NextDouble();
        }
        return numbersArray;
    }
    public double[] InsertionSort(double[]numbersArray)
    {
        for (int i = 1; i < numbersArray.Length; ++i)
        {
            int j = i - 1;
            var k = numbersArray[i];
            while (j >= 0 && numbersArray[j] > k)
            {
                numbersArray[j + 1] = numbersArray[j];
                j -= 1;
            }

            numbersArray[j + 1] = k;
        }
        return numbersArray;
    }

    public void OutputDoubleSorted(double[] numbersArray, int count)
    {
        foreach (var item in numbersArray)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine($"\nКількість елементів у масиві: {count}");
    }
}