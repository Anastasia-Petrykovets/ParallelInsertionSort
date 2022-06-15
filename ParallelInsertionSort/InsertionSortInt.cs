namespace ParallelInsertionSort;

public class InsertionSortInt
{
    public int[] CreateIntArray(int count)
    {
        Random rnd = new Random();
        int[] numbersArray = new int[count];
        
        for (int i = 0; i <= numbersArray.Length - 1; i++)
        {
            numbersArray[i] = rnd.Next(0, 100000);
        }
        return numbersArray;
    }
    
    public int[] InsertionSort(int[]numbersArray)
    {
        for (int i = 1; i < numbersArray.Length; ++i)
        {
            int j = i - 1;
            int k = numbersArray[i];
            while (j >= 0 && numbersArray[j] > k)
            {
                numbersArray[j + 1] = numbersArray[j];
                j -= 1;
            }

            numbersArray[j + 1] = k;
        }
        return numbersArray;
    }

    public void OutputIntSorted(int[] numbersArray, int count)
    {
        foreach (var item in numbersArray)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine($"\nКількість елементів у масиві: {count}");
    }
}