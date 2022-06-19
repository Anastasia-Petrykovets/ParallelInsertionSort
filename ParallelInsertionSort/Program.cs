using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ParallelInsertionSort;

public class Program
{
    public static string CheckInt(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i - 1] < array[i])
                return "Масив відсортовано правильно";
        }
        return "Масив відсортовано не коректно";
    }
    public static string CheckDouble(double[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i - 1] < array[i])
                return "Масив відсортовано правильно";
        }
        return "Масив відсортовано не коректно";
    }
    [SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH", MessageId = "type: System.Int32[]")]
    [SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH", MessageId = "type: System.Double[]")]
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Stopwatch stopWatch = new Stopwatch();

        InsertionSortInt sortInt = new InsertionSortInt();
        InsertionSortDouble sortDouble = new InsertionSortDouble();

        ParallelInsertionSortInt parallelSortInt = new ParallelInsertionSortInt();
        ParallelInsertionSortDouble paralellsortDouble = new ParallelInsertionSortDouble();

        string text = default;
        while (text != "exit")
        {
            /*Console.WriteLine("Оберіть, яким чином та який масив сортувати: Послідовне сортування типу int - напишіть i"+
                              "\nПаралельне сортування типу int - напишіть pi" +
                              "\nПослідовне сортування типу double - напишіть d" +
                              "\nПаралельне сортування типу double - напишіть pd");*/
            string type = Console.ReadLine();
            
            Console.Write("Введіть кількість елементів масиву: ");
            int count = Convert.ToInt32(Console.ReadLine());
        
            if (type == "i")
            {
                int[] newArray = sortInt.CreateIntArray(count);
                
                /*Console.WriteLine("Вхідний масив:");
                foreach (var item in newArray)
                {
                    Console.Write($"{item} ");
                }*/
                
                stopWatch.Start();
                int[] outputArray = sortInt.InsertionSort(newArray);
                stopWatch.Stop();
                
                Console.WriteLine(CheckInt(outputArray));
            }
            else if(type == "pi")
            {
                Console.Write("Уведiть кiлькiсть частин (потокiв), на якi буде подiлений вхiдний масив: ");
                int partsCount = Convert.ToInt32(Console.ReadLine());
                int[] newArray = sortInt.CreateIntArray(count);

                stopWatch.Start();
                int[] outputArray = parallelSortInt.InsertionSort(newArray, partsCount);
                stopWatch.Stop();
                
                Console.WriteLine(CheckInt(outputArray));
            }
            else if(type == "d")
            {
                double[] newArray = sortDouble.CreateDoubleArray(count);
                
                /*Console.WriteLine("Вхідний масив:");
                foreach (var item in newArray)
                {
                    Console.Write($"{item} ");
                }*/
                
                stopWatch.Start();
                double[] outputArray = sortDouble.InsertionSort(newArray);
                stopWatch.Stop();

                Console.WriteLine(CheckDouble(outputArray));
            }
            else if(type == "pd")
            {
                Console.Write("Уведiть кiлькiсть частин (потокiв), на якi буде подiлений вхiдний масив: ");
                int partsCount = Convert.ToInt32(Console.ReadLine());
                double[] newArray = sortDouble.CreateDoubleArray(count);

                stopWatch.Start();
                double[] outputArray = paralellsortDouble.InsertionSort(newArray, partsCount);
                stopWatch.Stop();

                Console.WriteLine(CheckDouble(outputArray));
            }
            else
            {
                Console.WriteLine("Спробуйте ще раз.");
            }
        
            Console.WriteLine($"Час виконання алгоритму: {stopWatch.ElapsedMilliseconds} мс.");
            text = Console.ReadLine();
        }
    }
}