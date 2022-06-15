using System.Diagnostics;
namespace ParallelInsertionSort;

public class Program
{
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
            Console.WriteLine("Оберіть, яким чином та який масив сортувати: Послідовне сортування типу double - напишіть d"+
                              "\nПаралельне сортування типу int - напишіть pi" +
                              "\nПослідовне сортування типу double - напишіть d" +
                              "\nПаралельне сортування типу double - напишіть pd");
            string type = Console.ReadLine();
        
            Console.Write("Введіть кількість елементів масиву: ");
            int count = Convert.ToInt32(Console.ReadLine());
        
            if (type == "i")
            {
                int[] newArray = sortInt.CreateIntArray(count);
                Console.WriteLine("Вхідний масив:");
                foreach (var item in newArray)
                {
                    Console.Write($"{item} ");
                }
                stopWatch.Start();
                int[] outputArray = sortInt.InsertionSort(newArray);
                stopWatch.Stop();
                Console.WriteLine("\nВідсортований масив:");
                sortInt.OutputIntSorted(outputArray, count);
            }
            else if(type == "pi")
            {
                Console.Write("Уведiть кiлькiсть частин (потокiв), на якi буде подiлений вхiдний масив: ");
                int partsCount = Convert.ToInt32(Console.ReadLine());
                int[] newArray = sortInt.CreateIntArray(count);
                Console.WriteLine("Вхідний масив:");
                foreach (var item in newArray)
                {
                    Console.Write($"{item} ");
                }
                stopWatch.Start();
                int[] outputArray = parallelSortInt.InsertionSort(newArray, partsCount);
                stopWatch.Stop();
                Console.WriteLine("\nВідсортований масив:");
                sortInt.OutputIntSorted(outputArray, count);
            }
            else if(type == "d")
            {
                double[] newArray = sortDouble.CreateDoubleArray(count);
                Console.WriteLine("Вхідний масив:");
                foreach (var item in newArray)
                {
                    Console.Write($"{item} ");
                }
                stopWatch.Start();
                double[] outputArray = sortDouble.InsertionSort(newArray);
                stopWatch.Stop();
                Console.WriteLine("\nВідсортований масив:");
                sortDouble.OutputDoubleSorted(outputArray, count);
            }
            else if(type == "pd")
            {
                Console.Write("Уведiть кiлькiсть частин (потокiв), на якi буде подiлений вхiдний масив: ");
                int partsCount = Convert.ToInt32(Console.ReadLine());
                double[] newArray = sortDouble.CreateDoubleArray(count);
                Console.WriteLine("Вхідний масив:");
                foreach (var item in newArray)
                {
                    Console.Write($"{item} ");
                }
                stopWatch.Start();
                double[] outputArray = paralellsortDouble.InsertionSort(newArray, partsCount);
                stopWatch.Stop();
                Console.WriteLine("\nВідсортований масив:");
                sortDouble.OutputDoubleSorted(outputArray, count);
            }
            else
            {
                Console.WriteLine("Спробуйте ще раз.");
            }
        
            Console.WriteLine($"Час виконання алгоритму: {stopWatch.Elapsed.TotalMilliseconds} мс.");
            text = Console.ReadLine();
        }
    }
}