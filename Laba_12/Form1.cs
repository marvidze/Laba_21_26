using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_12
{
    public partial class Form1 : Form
    {
        String[] arraySortNames = new String[] { "Простое 2ф", "Простое 1ф", "Естественное 2ф", "Естественное 1ф", "Поглощение" };
        bool[] arraySortChecked = new bool[] { true, true, false, false, false };
        const int ROWS_COUNT = 5;
        int arraySize;
        int[] array;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = ROWS_COUNT;
            for (int i = 0; i < ROWS_COUNT; i++)
            {
                dataGridView1.Rows[i].Cells[1].Value = arraySortNames[i];
                dataGridView1.Rows[i].Cells[0].Value = arraySortChecked[i];
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            int sortedCell = 5;
            int timeCell = 4;
            int assigmentCell = 3;
            int comparisonsCell = 2;

            Random rnd = new Random();
            arraySize = (int)numericUpDown_arraySize.Value;
            array = new int[arraySize];
            for (int i = 0; i < array.Length; i++) array[i] = rnd.Next(1, arraySize);

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells[timeCell].Value = "";
                dataGridView1.Rows[i].Cells[assigmentCell].Value = "";
                dataGridView1.Rows[i].Cells[comparisonsCell].Value = "";
                dataGridView1.Rows[i].Cells[sortedCell].Value = "";
            }


            for (int i = 0; i < ROWS_COUNT; i++)
            {
                arraySortChecked[i] = (bool)dataGridView1.Rows[i].Cells[0].Value;
            }

            // Проверка состояния checked и вызов определённой функции
            if (arraySortChecked[0])
            {
                InfoSort sortTwoPhaseMerge = TwoPhaseMergeSort(array);
                dataGridView1.Rows[0].Cells[timeCell].Value = sortTwoPhaseMerge.Time;
                dataGridView1.Rows[0].Cells[assigmentCell].Value = sortTwoPhaseMerge.Assigments;
                dataGridView1.Rows[0].Cells[comparisonsCell].Value = sortTwoPhaseMerge.Comparisons;
                dataGridView1.Rows[0].Cells[sortedCell].Value = sortTwoPhaseMerge.Sorted;
            }
            if (arraySortChecked[1])
            {
                InfoSort sortOnePhaseMerge = SinglePhaseMergeSort(array);
                dataGridView1.Rows[1].Cells[timeCell].Value = sortOnePhaseMerge.Time;
                dataGridView1.Rows[1].Cells[assigmentCell].Value = sortOnePhaseMerge.Assigments;
                dataGridView1.Rows[1].Cells[comparisonsCell].Value = sortOnePhaseMerge.Comparisons;
                dataGridView1.Rows[1].Cells[sortedCell].Value = sortOnePhaseMerge.Sorted;
            }
            if (arraySortChecked[2])
            {
                InfoSort sortOnePhaseNaturalMerge = TwoPhaseNaturalMergeSort(array);
                dataGridView1.Rows[2].Cells[timeCell].Value = sortOnePhaseNaturalMerge.Time;
                dataGridView1.Rows[2].Cells[assigmentCell].Value = sortOnePhaseNaturalMerge.Assigments;
                dataGridView1.Rows[2].Cells[comparisonsCell].Value = sortOnePhaseNaturalMerge.Comparisons;
                dataGridView1.Rows[2].Cells[sortedCell].Value = sortOnePhaseNaturalMerge.Sorted;
            }
        }
        #region 
        //public InfoSort BubbleSort(int[] array)
        //{
        //    int comparisons = 0;
        //    int permutations = 0;

        //    int[] arrayCopy = new int[array.Length];
        //    Array.Copy(array, arrayCopy, array.Length);
        //    int StartTime = Environment.TickCount;
        //    {
        //        bool swapped;
        //        for (int i = 0; i < arrayCopy.Length - 1; i++)
        //        {
        //            swapped = false;
        //            for (int j = 0; j < arrayCopy.Length - i - 1; j++)
        //            {
        //                if (arrayCopy[j] > arrayCopy[j + 1])
        //                {

        //                    int temp = arrayCopy[j];
        //                    arrayCopy[j] = arrayCopy[j + 1];
        //                    arrayCopy[j + 1] = temp;
        //                    swapped = true;
        //                    permutations++;
        //                }
        //                comparisons++;
        //            }
        //            if (!swapped)
        //                break;
        //        }
        //        int ResultTime = Environment.TickCount - StartTime;

        //        String sorted;
        //        if (CheckSortArray(arrayCopy))
        //        {
        //            sorted = "Да";
        //        }
        //        else sorted = "Нет";
        //        return new InfoSort { Time = ResultTime, Comparisons = comparisons, Permutations = permutations, Sorted = sorted };
        //    }
        //}

        //public InfoSort SortDirectSelection(int[] _arr)
        //{
        //    int comparisons = 0;
        //    int permutations = 0;

        //    int[] arr = new int[_arr.Length]; 
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        arr[i] = _arr[i];
        //    }

        //    int StartTime = Environment.TickCount;
        //    {
        //        for (int i = 0; i < arr.Length - 1; i++)
        //        {
        //            int minIndex = i; 

        //            for (int j = i + 1; j < arr.Length; j++)  
        //            {
        //                if (arr[j] < arr[minIndex])
        //                {
        //                    minIndex = j;
        //                }
        //                comparisons++;
        //            }

        //            // Swap.
        //            int temp = arr[i];
        //            arr[i] = arr[minIndex];
        //            arr[minIndex] = temp;
        //            permutations++;
        //        }
        //    }
        //    int ResultTime = Environment.TickCount - StartTime;

        //    String sorted;
        //    if (CheckSortArray(arr))
        //    {
        //        sorted = "Да";
        //    }
        //    else sorted = "Нет";
        //    return new InfoSort { Time = ResultTime, Comparisons = comparisons, Permutations = permutations, Sorted = sorted };
        //}

        //public InfoSort SortDirectInclusion(int[] _arr)
        //{
        //    int comparisons = 0;
        //    int permutations = 0;
        //    int minIndex = 0;

        //    int[] arr = new int[_arr.Length]; 
        //    for (int i = 0; i < _arr.Length; i++)
        //    {
        //        arr[i] = _arr[i];
        //    }
        //    int minArr = 99999;
        //    int StartTime = Environment.TickCount;
        //    {
        //        for (int i = 0; i < arr.Length; i++)
        //        {
        //            comparisons++;
        //            if (minArr > arr[i])
        //            {
        //                minArr = arr[i];
        //                minIndex = i;
        //            }

        //        }
        //        int valIndex = arr[0];
        //        arr[0] = arr[minIndex];
        //        arr[minIndex] = valIndex;
        //        permutations++;

        //        for (int i = 2; i < arr.Length; i++) 
        //        {
        //            int key = arr[i];
        //            int j = i - 1;

        //            while (arr[j] > key)
        //            {
        //                comparisons++;
        //                arr[j + 1] = arr[j];
        //                j--;
        //                permutations++;
        //            }
        //            arr[j + 1] = key;
        //            comparisons++;
        //        }
        //    }
        //    int ResultTime = Environment.TickCount - StartTime;

        //    int[] sortedArray = new int[arr.Length - 1];
        //    Array.Copy(arr, 1, sortedArray, 0, sortedArray.Length);

        //    String sorted;
        //    if (CheckSortArray(sortedArray))
        //    {
        //        sorted = "Да";
        //    }
        //    else sorted = "Нет";
        //    return new InfoSort { Time = ResultTime, Comparisons = comparisons, Permutations = permutations, Sorted = sorted };
        //}
        //public InfoSort doQuickSort(int[] _arr, int low, int high)
        //{
        //    int[] arr = new int[_arr.Length]; 
        //    for (int i = 0; i < _arr.Length; i++)
        //    {
        //        arr[i] = _arr[i];
        //    }

        //    int[] stack = new int[high - low + 1];
        //    int top = -1;
        //    stack[++top] = low;
        //    stack[++top] = high;

        //    int comparisons = 0, permutations = 0;
        //    int start = Environment.TickCount;
        //    {
        //        while (top >= 0)
        //        {
        //            high = stack[top--];
        //            low = stack[top--];

        //            int pivotIndex = new Random().Next(low, high + 1);
        //            int pivotValue = arr[pivotIndex];

        //            int i = low;
        //            int j = high;


        //            while (i <= j)
        //            {
        //                comparisons++;
        //                while (arr[i] < pivotValue)
        //                {
        //                    comparisons++;
        //                    i++;
        //                }

        //                comparisons++;
        //                while (arr[j] > pivotValue)
        //                {
        //                    comparisons++;
        //                    j--;
        //                }

        //                if (i <= j)
        //                {
        //                    permutations++;
        //                    int temp = arr[i];
        //                    arr[i] = arr[j];
        //                    arr[j] = temp;
        //                    i++;
        //                    j--;
        //                }
        //            }

        //            if (i < high)
        //            {
        //                stack[++top] = i;
        //                stack[++top] = high;
        //            }

        //            if (j > low)
        //            {
        //                stack[++top] = low;
        //                stack[++top] = j;
        //            }
        //        }
        //    }
        //    int ResultTime = Environment.TickCount - start;

        //    String sorted;
        //    if (CheckSortArray(arr))
        //    {
        //        sorted = "Да";
        //    }
        //    else
        //    {
        //        sorted = "Нет";
        //    }


        //    return new InfoSort { Time = ResultTime, Comparisons = comparisons, Permutations = permutations, Sorted = sorted };
        //}

        //public InfoSort SortShell(int[] _arr)
        //{
        //    int[] arr = new int[_arr.Length];
        //    for (int i = 0; i < _arr.Length; i++)
        //    {
        //        arr[i] = _arr[i];
        //    }

        //    int comparisons = 0;
        //    int permutations = 0;

        //    int start = Environment.TickCount;
        //    {
        //        int t = (int)Math.Log(arr.Length, 2) - 1;

        //        int currentStep = (int)Math.Pow(2, t) - 1;
        //        while (currentStep > 0)
        //        {
        //            for (int i = currentStep; i < arr.Length; ++i)
        //            {
        //                int key = arr[i];
        //                int j = i;

        //                while (j >= currentStep && arr[j - currentStep] > key)
        //                {
        //                    comparisons++;
        //                    permutations++;
        //                    arr[j] = arr[j - currentStep];
        //                    j -= currentStep;
        //                }
        //                permutations++;
        //                arr[j] = key;
        //            }
        //            currentStep /= 2; 
        //        }
        //    }
        //    int ResultTime = Environment.TickCount - start;

        //    String sorted;
        //    if (CheckSortArray(arr))
        //    {
        //        sorted = "Да";
        //    }
        //    else
        //    {
        //        sorted = "Нет";
        //    }

        //    return new InfoSort { Time = ResultTime, Comparisons = comparisons, Permutations = permutations, Sorted = sorted };
        //}

        //public InfoSort SortCounting(int[] _arr)
        //{ 
        //    int[] arr = new int[_arr.Length];
        //    for (int i = 0; i < _arr.Length; i++)
        //    {
        //        arr[i] = _arr[i];
        //    }

        //    int comparisons = 0;
        //    int permutations = 0;

        //    int start = Environment.TickCount;

        //    {
        //        int minVal = arr[0];
        //        int maxVal = arr[0];
        //        for (int i = 0; i < arr.Length; i++)
        //        {
        //            comparisons++;
        //            if (arr[i] < minVal)
        //            {
        //                minVal = arr[i];
        //            }
        //            if (arr[i] > maxVal)
        //            {
        //                maxVal = arr[i];
        //            }
        //        }

        //        int[] count = new int[maxVal - minVal + 1];

        //        for (int i = 0; i < arr.Length; i++)
        //        {
        //            count[arr[i] - minVal]++;
        //            permutations++;
        //        }

        //        int index = 0;
        //        for (int i = 0; i < count.Length; i++)
        //        {
        //            while (count[i] > 0)
        //            {
        //                permutations++;
        //                arr[index] = i + minVal;
        //                index++;
        //                count[i]--;
        //            }
        //        }
        //    }

        //    int ResultTime = Environment.TickCount - start;

        //    String sorted;
        //    if (CheckSortArray(arr))
        //    {
        //        sorted = "Да";
        //    }
        //    else
        //    {
        //        sorted = "Нет";
        //    }

        //    return new InfoSort { Time = ResultTime, Comparisons = comparisons, Permutations = permutations, Sorted = sorted };
        //}

        //public InfoSort CSharpSort(int[] _arr)
        //{

        //    int[] arr = new int[_arr.Length];
        //    for (int i = 0; i < _arr.Length; i++)
        //    {
        //        arr[i] = _arr[i];
        //    }

        //    int start = Environment.TickCount;
        //    {
        //        Array.Sort(arr);
        //    }
        //    int ResultTime = Environment.TickCount - start;

        //    String sorted;
        //    if (CheckSortArray(arr))
        //    {
        //        sorted = "Да";
        //    }
        //    else
        //    {
        //        sorted = "Нет";
        //    }
        //    return new InfoSort { Time = ResultTime, Comparisons = 0, Permutations = 0, Sorted = sorted };
        //}

        //private static int _compareCount = 0;
        //private static int _swapCount = 0;

        //// Просеивание вниз
        //private static void Down(int[] A, int heapSize, int index)
        //{
        //    while (index < heapSize)
        //    {
        //        int leftChild = 2 * index + 1;
        //        int rightChild = 2 * index + 2;
        //        int current = index;

        //        if (leftChild < heapSize)
        //        {
        //            _compareCount++; // Сравнение A[leftChild] > A[current]
        //            if (A[leftChild] > A[current])
        //                current = leftChild;
        //        }

        //        if (rightChild < heapSize)
        //        {
        //            _compareCount++; // Сравнение A[rightChild] > A[current]
        //            if (A[rightChild] > A[current])
        //                current = rightChild;
        //        }

        //        if (current == index)
        //            break;

        //        // Обмен элементов
        //        (A[index], A[current]) = (A[current], A[index]);
        //        _swapCount++; // Увеличиваем счётчик перестановок

        //        index = current;
        //    }
        //}

        //// Основная функция сортировки с возвратом статистики
        //public InfoSort PyramidalSort(int[] _arr)
        //{
        //    // Создаём копию массива, чтобы не менять исходный
        //    int[] arr = new int[_arr.Length];
        //    for (int i = 0; i < _arr.Length; i++)
        //    {
        //        arr[i] = _arr[i];
        //    }

        //    // Сбрасываем счётчики
        //    _swapCount = 0;
        //    _compareCount = 0;

        //    int start = Environment.TickCount;

        //    // Построение кучи через Down (оптимальный способ)
        //    for (int i = arr.Length / 2 - 1; i >= 0; i--)
        //        Down(arr, arr.Length, i);

        //    // Извлекаем элементы из кучи
        //    for (int i = arr.Length - 1; i > 0; i--)
        //    {
        //        // Перемещаем корень (максимум) в конец
        //        (arr[0], arr[i]) = (arr[i], arr[0]);
        //        _swapCount++; // Увеличиваем счётчик перестановок

        //        // Восстанавливаем кучу
        //        Down(arr, i, 0);
        //    }
        //    int stop = Environment.TickCount;
        //    int ResultTime = stop - start;
        //    String sorted;
        //    if (CheckSortArray(arr))
        //    {
        //        sorted = "Да";
        //    }
        //    else
        //    {
        //        sorted = "Нет";
        //    }
        //    return new InfoSort { Time = ResultTime, Comparisons = _compareCount, Permutations = _swapCount, Sorted = sorted };
        //}

        #endregion

        public InfoSort TwoPhaseMergeSort(int[] _arr)
        {
            int assignments = 0;
            int comparisons = 0;
            int[] arr = new int[_arr.Length];
            Array.Copy(_arr, arr, _arr.Length);

            int startTime = Environment.TickCount;
            int endTime;

            // Крайний случай: массив пуст или имеет 1 элемент
            if (arr == null || arr.Length <= 1)
            {
                endTime = Environment.TickCount;
                return new InfoSort
                {
                    Time = endTime - startTime,
                    Assigments = 0,
                    Comparisons = 0,
                    Sorted = "В массиве 1 элемент или он пуст"
                };

            }

            int[] B = new int[arr.Length];
            int[] C = new int[arr.Length];

            int runLength = 1;
            bool sorted = false;

            while (!sorted)
            {
                // ФАЗА 1: РАЗДЕЛЕНИЕ 
                // Разбиваем исходный массив на два вспомогательных:
                // - tempArray1 получает 1-ю, 3-ю, 5-ю... серии 
                // - tempArray2 получает 2-ю, 4-ю, 6-ю... серии
                // Серия - подмассив длиной runLength
                var (length1, length2) = SplitArray(arr, B, C, runLength, ref comparisons, ref assignments);

                // ФАЗА 2: СЛИЯНИЕ 
                // Объединяем серии из двух массивов обратно в исходный:
                // - Пары серий сливаются в упорядоченные последовательности
                // - Длина результирующих серий удваивается (runLength * 2)
                sorted = MergeArrays(
                    dest: arr,            // Целевой массив
                    source1: B,    // Первый источник
                    source2: C,    // Второй источник
                    runLength: runLength,   // Текущий размер серии
                    source1Length: length1, // Реальная длина данных в source1
                    source2Length: length2, // Реальная длина данных в source2
                    comparisons: ref comparisons,
                    assignments: ref assignments
                );

                runLength *= 2;
            }
            endTime = Environment.TickCount;
            return new InfoSort
            {
                Sorted = sorted ? "Да" : "Нет",
                Assigments = assignments,
                Comparisons = comparisons,
                Time = endTime - startTime
            };
        }

        /// <summary>
        /// Фаза разделения: распределение элементов исходного массива
        /// между двумя вспомогательными массивами блоками по runLength элементов
        /// </summary>
        /// <param name="source">Исходный массив</param>
        /// <param name="dest1">Первый вспомогательный массив</param>
        /// <param name="dest2">Второй вспомогательный массив</param>
        /// <param name="runLength">Текущая длина серии</param>
        /// <param name="AssignmentCount">Счетчик операций присваивания</param>
        /// <returns>Кортеж с реальными длинами данных в dest1 и dest2</returns>
        private (int length1, int length2) SplitArray(
            int[] source,
            int[] dest1,
            int[] dest2,
            int runLength,
            ref int comparisons, ref int assignments)
        {
            int dest1Index = 0;
            int dest2Index = 0;
            bool writeToFirst = true;


            for (int i = 0; i < source.Length;)
            {

                int elementsToWrite = Math.Min(runLength, source.Length - i);

                if (writeToFirst)
                {
                    Array.Copy(
                        sourceArray: source,        // Откуда копируем
                        sourceIndex: i,             // Стартовая позиция в источнике
                        destinationArray: dest1,    // Куда копируем
                        destinationIndex: dest1Index, // Стартовая позиция в приемнике
                        length: elementsToWrite     // Количество элементов
                    );
                    dest1Index += elementsToWrite; // Сдвигаем указатель записи
                    assignments += elementsToWrite; // Учет перемещений
                }
                else
                {
                    Array.Copy(source, i, dest2, dest2Index, elementsToWrite);
                    dest2Index += elementsToWrite;
                    assignments += elementsToWrite;
                }

                i += elementsToWrite;
                writeToFirst = !writeToFirst;
            }

            return (dest1Index, dest2Index);
        }

        private bool MergeArrays(
            int[] dest,
            int[] source1,
            int[] source2,
            int runLength,
            int source1Length,
            int source2Length,
            ref int comparisons, ref int assignments)
        {
            int index1 = 0;
            int index2 = 0;
            int destIndex = 0;

            while (index1 < source1Length && index2 < source2Length)
            {
                int end1 = Math.Min(index1 + runLength, source1Length);
                int end2 = Math.Min(index2 + runLength, source2Length);

                while (index1 < end1 && index2 < end2)
                {
                    comparisons++;
                    if (source1[index1] <= source2[index2])
                    {
                        dest[destIndex++] = source1[index1++];
                    }
                    else
                    {
                        dest[destIndex++] = source2[index2++];
                    }
                    assignments++;
                }

                while (index1 < end1)
                {
                    dest[destIndex++] = source1[index1++];
                    assignments++;
                }

                while (index2 < end2)
                {
                    dest[destIndex++] = source2[index2++];
                    assignments++;
                }
            }

            while (index1 < source1Length)
            {
                dest[destIndex++] = source1[index1++];
                assignments++;
            }

            while (index2 < source2Length)
            {
                dest[destIndex++] = source2[index2++];
                assignments++;
            }

            return runLength >= dest.Length;
        }

        private InfoSort SinglePhaseMergeSort(int[] arr)
        {
            int comparisons = 0;
            int assignments = 0;

            int[] aFile = new int[arr.Length];
            Array.Copy(arr, arr, arr.Length);

            int[] bFile = new int[aFile.Length];
            int[] cFile = new int[aFile.Length];
            int[] dFile = new int[aFile.Length];
            int[] eFile = new int[aFile.Length];

            int bPointer = 0;
            int cPointer = 0;
            int dPointer = 0;
            int ePointer = 0;

            bool isFirst = true;
            int sequenceLength = 1;

            int start = Environment.TickCount;

            (bPointer, cPointer) = SplitArray(aFile, bFile, cFile, sequenceLength, ref comparisons, ref assignments);

            for (int i = 1; i <= aFile.Length; i *= 2)
            {
                if (isFirst)
                    (dPointer, ePointer) = TransferItems(
                        i,
                        ref bFile,
                        ref bPointer,
                        ref cFile,
                        ref cPointer,
                        ref dFile,
                        ref dPointer,
                        ref eFile,
                        ref ePointer,
                        ref comparisons,
                        ref assignments);
                else
                    (bPointer, cPointer) = TransferItems(
                        i,
                        ref dFile,
                        ref dPointer,
                        ref eFile,
                        ref ePointer,
                        ref bFile,
                        ref bPointer,
                        ref cFile,
                        ref cPointer,
                        ref comparisons,
                        ref assignments);
                isFirst = !isFirst;
            }
            if (isFirst)
                MergeArrays(aFile, cFile, bFile, sequenceLength, cPointer, bPointer, ref comparisons, ref assignments);
            else
                MergeArrays(aFile, dFile, eFile, sequenceLength, dPointer, ePointer, ref comparisons, ref assignments);

            int elapsedTime = Environment.TickCount - start;

            return new InfoSort
            {
                Assigments = assignments,
                Comparisons = comparisons,
                Time = elapsedTime,
                Sorted = IsArraySorted(aFile) ? "Да" : "Нет"
            };

        }

        private (int, int) TransferItems(int sequenceLength,
            ref int[] source1, ref int source1Pointer,
            ref int[] source2, ref int source2Pointer,
            ref int[] dest1, ref int dest1Pointer,
            ref int[] dest2, ref int dest2Pointer,
            ref int comparisons, ref int assignments)
        {

            bool flag = true;
            int index1 = 0;
            int index2 = 0;

            int count1 = 0;
            int count2 = 0;

            while (index1 < source1Pointer || index2 < source2Pointer)
            {
                comparisons++;

                long curFirst = sequenceLength;
                long curSecond = sequenceLength;

                while (curFirst != 0 && curSecond != 0 && index1 < source1Pointer && index2 < source2Pointer)
                {
                    comparisons++;
                    assignments++;
                    if (source1[index1] <= source2[index2])
                    {
                        if (flag)
                            dest1[count1++] = source1[index1++];
                        else
                            dest2[count2++] = source1[index1++];
                        curFirst--;
                    }
                    else
                    {
                        if (flag) dest1[count1++] = source2[index2++];
                        else dest2[count2++] = source2[index2++];
                        curSecond--;
                    }
                }

                while (curFirst != 0 && index1 < source1Pointer)
                {
                    assignments++;
                    if (flag)
                        dest1[count1++] = source1[index1++];
                    else
                        dest2[count2++] = source1[index1++];
                    curFirst--;
                }

                while (curSecond != 0 && index2 < source2Pointer)
                {
                    assignments++;
                    if (flag)
                        dest1[count1++] = source2[index2++];
                    else
                        dest2[count2++] = source2[index2++];
                    curSecond--;
                }
                flag = !flag;
            }

            return (count1, count2);
        }

        /// <summary>
        /// Двухфазная сортировка естественным слиянием
        /// </summary>
        /// <param name="array">Ссылка на сортируемый массив</param>
        /// <returns>
        /// Кортеж с метриками:
        /// comparisons - количество сравнений элементов
        /// permutations - количество перестановок элементов
        /// time - время выполнения в миллисекундах
        /// </returns>
        public static InfoSort TwoPhaseNaturalMergeSort(int[] arr)
        {
            int comparisons = 0, permutations = 0;
            int[] array = new int[arr.Length];
            Array.Copy(arr, array, arr.Length);

            int start = Environment.TickCount;

            int[] bArray = new int[array.Length];
            int[] cArray = new int[array.Length];

            bool flag;
            do
            {
                (int bSize, int cSize) = NaturalSplit(array, bArray, cArray, ref comparisons, ref permutations);

                flag = NaturalMerge(ref array, bArray, bSize, cArray, cSize, ref comparisons, ref permutations);

            } while (flag); 

            int resultTime = Environment.TickCount - start;

            return new InfoSort
            {
                Comparisons = comparisons,
                Assigments = permutations,
                Time = resultTime,
                Sorted = flag ? "Нет" : "Да"
            };
        }

        /// <summary>
        /// Разделяет исходный массив на два подмассива
        /// </summary>
        /// <param name="source">Исходный массив</param>
        /// <param name="bArray">Первый вспомогательный массив</param>
        /// <param name="cArray">Второй вспомогательный массив</param>
        /// <param name="comparisons">Счетчик сравнений</param>
        /// <param name="permutations">Счетчик перестановок</param>
        /// <returns>Размеры заполненных подмассивов (bSize, cSize)</returns>
        private static (int bSize, int cSize) NaturalSplit(int[] source, int[] bArray, int[] cArray,
            ref int comparisons, ref int permutations)
        {
            // Индексы для записи в подмассивы
            int bIndex = 0, cIndex = 0;
            bool writeToB = true;
            int lastValue = int.MinValue;

            // Проходим по всем элементам исходного массива
            for (int i = 0; i < source.Length; i++)
            {
                int current = source[i]; // Текущий элемент
                comparisons++; // Увеличиваем счетчик сравнений

                // Определяем конец серии (текущий элемент меньше предыдущего)
                if (current < lastValue)
                {
                    // При обнаружении конца серии переключаем целевой подмассив
                    writeToB = !writeToB;
                }

                // Записываем элемент в соответствующий подмассив
                if (writeToB)
                {
                    bArray[bIndex++] = current;
                }
                else
                {
                    cArray[cIndex++] = current;
                }
                permutations++; // Увеличиваем счетчик перестановок

                lastValue = current; // Сохраняем текущее значение для следующей итерации
            }

            // Возвращаем размеры заполненных подмассивов
            return (bIndex, cIndex);
        }
        /// <summary>
        /// Сливает два подмассива обратно в исходный массив, сохраняя порядок
        /// </summary>
        /// <param name="dest">Исходный массив (результат слияния)</param>
        /// <param name="bArray">Первый подмассив</param>
        /// <param name="bSize">Размер первого подмассива</param>
        /// <param name="cArray">Второй подмассив</param>
        /// <param name="cSize">Размер второго подмассива</param>
        /// <param name="comparisons">Счетчик сравнений</param>
        /// <param name="permutations">Счетчик перестановок</param>
        /// <returns>true, если остались серии для следующего прохода</returns>
        private static bool NaturalMerge(ref int[] dest, int[] bArray, int bSize, int[] cArray, int cSize,
            ref int comparisons, ref int permutations)
        {
            // Индексы для подмассивов и результирующего массива
            int bIndex = 0, cIndex = 0, destIndex = 0;
            // Флаг наличия более одной серии
            bool hasMoreThanOneSeries = false;

            // Пока есть элементы в любом из подмассивов
            while (bIndex < bSize || cIndex < cSize)
            {
                // Находим концы текущих серий в обоих подмассивах
                int bSeriesEnd = FindSeriesEnd(bArray, bIndex, bSize, ref comparisons, ref permutations);
                int cSeriesEnd = FindSeriesEnd(cArray, cIndex, cSize, ref comparisons, ref permutations);

                // Слияние двух серий 
                while (bIndex < bSeriesEnd && cIndex < cSeriesEnd)
                {
                    comparisons++; // Увеличиваем счетчик сравнений

                    // Выбираем меньший элемент из двух подмассивов
                    if (bArray[bIndex] <= cArray[cIndex])
                    {
                        dest[destIndex++] = bArray[bIndex++];
                    }
                    else
                    {
                        dest[destIndex++] = cArray[cIndex++];
                    }
                    permutations++; // Увеличиваем счетчик перестановок
                }

                // Дописываем оставшиеся элементы из первого подмассива
                while (bIndex < bSeriesEnd)
                {
                    dest[destIndex++] = bArray[bIndex++];
                    permutations++;
                }

                // Дописываем оставшиеся элементы из второго подмассива
                while (cIndex < cSeriesEnd)
                {
                    dest[destIndex++] = cArray[cIndex++];
                    permutations++;
                }

                // Проверяем, есть ли еще серии в подмассивах
                if (bIndex < bSize || cIndex < cSize)
                {
                    hasMoreThanOneSeries = true;
                }
            }

            return hasMoreThanOneSeries;
        }

        /// <summary>
        /// Находит конец текущей упорядоченной последовательности (серии) в массиве
        /// </summary>
        /// <param name="array">Исследуемый массив</param>
        /// <param name="start">Начальный индекс</param>
        /// <param name="end">Конечный индекс</param>
        /// <param name="comparisons">Счетчик сравнений</param>
        /// <param name="permutations">Счетчик перестановок</param>
        /// <returns>Индекс конца серии</returns>
        private static int FindSeriesEnd(int[] array, int start, int end, ref int comparisons, ref int permutations)
        {
            // Если начальный индекс выходит за границы
            if (start >= end) return start;

            int i = start;
            // Ищем место, где нарушается упорядоченность
            while (i < end - 1)
            {
                comparisons++; // Увеличиваем счетчик сравнений
                               // Если текущий элемент больше следующего - серия закончилась
                if (array[i] > array[i + 1])
                {
                    return i + 1;
                }
                i++;
            }

            // Если дошли до конца - серия занимает весь оставшийся массив
            return end;
        }

        public bool IsArraySorted(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }
            return true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}