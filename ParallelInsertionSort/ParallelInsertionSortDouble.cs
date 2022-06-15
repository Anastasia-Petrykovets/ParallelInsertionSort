namespace ParallelInsertionSort;

public class ParallelInsertionSortDouble
{
    public double[] InsertionSort(double[] array, int partsCount)
    {
        List<double[]> arrays = Divide(array, partsCount);

        Parallel.For(0, partsCount, indexArr =>
        {
            for (int i = 1; i < arrays[indexArr].Length; ++i)
            {
                int j = i - 1;
                var k = arrays[indexArr][i];
                while (j >= 0 && arrays[indexArr][j] > k)
                {
                    arrays[indexArr][j + 1] = arrays[indexArr][j];
                    j -= 1;
                }

                arrays[indexArr][j + 1] = k;
            }
        });

        double[] resultArray;
        resultArray = MergeSortDouble.MergeArraysFromList(arrays);
        return resultArray;
    }

    public static List<double[]> Divide(double[] array, int partsCount)
    {
        List<double[]> arrays = new List<double[]>();

        int elementsPerPart = array.Length / partsCount;
        int counter = 0;

        for (int i = 0; i < partsCount; i++)
        {
            if (i < partsCount - 1)
            {
                arrays.Add(new Double[elementsPerPart]);
            }
            else
            {
                arrays.Add(new Double[array.Length - counter]);
            }

            for (int j = 0; j < arrays[i].Length; j++)
            {
                arrays[i][j] = array[counter];
                counter++;
            }
        }

        return arrays;
    }
}


class MergeSortDouble
{
    public static double[] MergeArraysFromList(List<double[]> arrays)
    {
        double[] array = arrays[0];
        for (int i = 1; i < arrays.Count; i++)
        {
            array = MergeParts(array, arrays[i]);
        }

        return array;
    }

    private static double[] MergeParts(double[] left, double[] right)
    {
        double[] result = new Double[left.Length + right.Length];

        int firstCount = 0;
        int secondCount = 0;
        for (int i = 0; i < result.Length; i++)
        {
            if (left[firstCount] < right[secondCount])
            {
                result[i] = left[firstCount];
                firstCount++;
            }
            else
            {
                result[i] = right[secondCount];
                secondCount++;
            }

            if (firstCount == left.Length)
            {
                i++;
                return FinishMerge(result, right, i, secondCount);
            }

            if (secondCount == right.Length)
            {
                i++;
                return FinishMerge(result, left, i, firstCount);
            }
        }

        return result;
    }

    private static double[] FinishMerge(double[] mainArr, double[] edit, int index, int editIndex)
    {
        while (index < mainArr.Length)
        {
            mainArr[index] = edit[editIndex];
            index++;
            editIndex++;
        }

        return mainArr;
    }
}