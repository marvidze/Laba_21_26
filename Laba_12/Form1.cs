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
        bool[] arraySortChecked = new bool[] { true, false, false, false, false };
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
        private static int assignments = 0;
        private static int comparisons = 0;
        public static InfoSort TwoPhaseMergeSort(int[] _arr)
        {
            assignments = 0;
            comparisons = 0;
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

            // Инициализация двух рабочих массивов для фаз разделения
            // Размер равен исходному массиву для обработки худшего случая
            int[] B = new int[arr.Length];
            int[] C = new int[arr.Length];

            int runLength = 1;    // Текущая длина серии (начинаем с 1 элемента)
            bool sorted = false;  // Флаг завершения сортировки

            // Главный цикл алгоритма (повтор до полной сортировки)
            // Каждая итерация - один полный проход (разделение + слияние)
            while (!sorted)
            {
                // ФАЗА 1: РАЗДЕЛЕНИЕ 
                // Разбиваем исходный массив на два вспомогательных:
                // - tempArray1 получает 1-ю, 3-ю, 5-ю... серии 
                // - tempArray2 получает 2-ю, 4-ю, 6-ю... серии
                // Серия - подмассив длиной runLength
                var (length1, length2) = SplitArray(arr, B, C, runLength);

                // ФАЗА 2: СЛИЯНИЕ 
                // Объединяем серии из двух массивов обратно в исходный:
                // - Пары серий сливаются в упорядоченные последовательности
                // - Длина результирующих серий удваивается (runLength * 2)
                sorted = MergeArrays(
                    dest:arr,            // Целевой массив
                    source1: B,    // Первый источник
                    source2: C,    // Второй источник
                    runLength: runLength,   // Текущий размер серии
                    source1Length: length1, // Реальная длина данных в source1
                    source2Length: length2 // Реальная длина данных в source2
                );

                // Подготовка к следующей итерации:
                runLength *= 2; // Удваиваем длину серии согласно алгоритму
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
        private static (int length1, int length2) SplitArray(
            int[] source,
            int[] dest1,
            int[] dest2,
            int runLength)
        {
            int dest1Index = 0; // Текущая позиция записи в dest1
            int dest2Index = 0; // Текущая позиция записи в dest2
            bool writeToFirst = true; // Флаг текущего массива для записи

            // Проход по всему исходному массиву блоками по runLength элементов
            for (int i = 0; i < source.Length;)
            {
                // Вычисляем количество элементов для текущей серии:
                // Минимум между runLength и оставшимися элементами
                int elementsToWrite = Math.Min(runLength, source.Length - i);

                // Распределение серии между массивами
                if (writeToFirst)
                {
                    // Копируем серию в dest1
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
                    // Аналогично для dest2
                    Array.Copy(source, i, dest2, dest2Index, elementsToWrite);
                    dest2Index += elementsToWrite;
                    assignments += elementsToWrite;
                }

                // Сдвигаем указатель исходного массива
                i += elementsToWrite;
                // Меняем целевой массив для следующей серии
                writeToFirst = !writeToFirst;
            }

            return (dest1Index, dest2Index); // Фактические размеры данных
        }

        /// <summary>
        /// Фаза слияния: объединение двух массивов в один отсортированный
        /// </summary>
        /// <param name="dest">Целевой массив для результатов</param>
        /// <param name="source1">Первый массив-источник</param>
        /// <param name="source2">Второй массив-источник</param>
        /// <param name="runLength">Текущий размер серии</param>
        /// <param name="source1Length">Реальная длина данных в source1</param>
        /// <param name="source2Length">Реальная длина данных в source2</param>
        /// <param name="ComparisonCount">Счетчик сравнений</param>
        /// <param name="AssignmentCount">Счетчик присваиваний</param>
        /// <returns>True, если сортировка завершена</returns>
        private static bool MergeArrays(
            int[] dest,
            int[] source1,
            int[] source2,
            int runLength,
            int source1Length,
            int source2Length)
        {
            int index1 = 0; // Указатель текущей позиции в source1
            int index2 = 0; // Указатель текущей позиции в source2
            int destIndex = 0; // Указатель записи в dest

            // Цикл попарного слияния серий
            while (index1 < source1Length && index2 < source2Length)
            {
                // Границы текущих серий в обоих массивах:
                int end1 = Math.Min(index1 + runLength, source1Length);
                int end2 = Math.Min(index2 + runLength, source2Length);

                // Слияние двух серий 
                while (index1 < end1 && index2 < end2)
                {
                    // Сравнение элементов 
                    comparisons++; // Учет операции сравнения
                    if (source1[index1] <= source2[index2])
                    {
                        dest[destIndex++] = source1[index1++];
                    }
                    else
                    {
                        dest[destIndex++] = source2[index2++];
                    }
                    assignments++; // Учет перемещения элемента
                }

                // Докопирование остатков из первой серии (если есть)
                while (index1 < end1)
                {
                    dest[destIndex++] = source1[index1++];
                    assignments++;
                }

                // Докопирование остатков из второй серии (если есть)
                while (index2 < end2)
                {
                    dest[destIndex++] = source2[index2++];
                    assignments++;
                }
            }

            // Докопирование оставшихся элементов source1 (если массивы разной длины)
            while (index1 < source1Length)
            {
                dest[destIndex++] = source1[index1++];
                assignments++;
            }

            // Докопирование оставшихся элементов source2
            while (index2 < source2Length)
            {
                dest[destIndex++] = source2[index2++];
                assignments++;
            }

            // Проверка условия завершения:
            // Если размер серии превысил длину массива - сортировка завершена
            return runLength >= dest.Length;
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