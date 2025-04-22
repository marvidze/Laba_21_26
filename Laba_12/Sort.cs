using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_12
{
    class Sort
    {
        /// <summary>
        /// Реализация двухфазной сортировки слиянием с метриками производительности
        /// 1. Разделение массива на два вспомогательных (фаза разделения)
        /// 2. Попарное слияние серий (фаза слияния)
        /// 3. Удвоение длины серий на каждом проходе
        /// 4. Завершение при длине серии ≥ размера массива
        /// </summary>
        /// 
        class TwoPhaseMergeSortWithMetrics
        {
            /// <summary>
            /// Основной метод сортировки с подсчетом операций
            /// </summary>
            /// <param name="A">Сортируемый массив</param>
            /// <param name="ComparisonCount">Счетчик сравнений элементов</param>
            /// <param name="AssignmentCount">Счетчик присваиваний элементов</param>
            public static void Sort(int[] A, ref int ComparisonCount, ref int AssignmentCount)
            {
                // Крайний случай: массив пуст или имеет 1 элемент
                if (A == null || A.Length <= 1)
                    return;

                // Инициализация двух рабочих массивов для фаз разделения
                // Размер равен исходному массиву для обработки худшего случая
                int[] B = new int[A.Length];
                int[] C = new int[A.Length];

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
                    var (length1, length2) = SplitArray(A, B, C, runLength, ref AssignmentCount);

                    // ФАЗА 2: СЛИЯНИЕ 
                    // Объединяем серии из двух массивов обратно в исходный:
                    // - Пары серий сливаются в упорядоченные последовательности
                    // - Длина результирующих серий удваивается (runLength * 2)
                    sorted = MergeArrays(
                        dest: A,            // Целевой массив
                        source1: B,    // Первый источник
                        source2: C,    // Второй источник
                        runLength: runLength,   // Текущий размер серии
                        source1Length: length1, // Реальная длина данных в source1
                        source2Length: length2, // Реальная длина данных в source2
                        ComparisonCount: ref ComparisonCount,
                        AssignmentCount: ref AssignmentCount
                    );

                    // Подготовка к следующей итерации:
                    runLength *= 2; // Удваиваем длину серии согласно алгоритму
                }
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
                int runLength,
                ref int AssignmentCount)
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
                        AssignmentCount += elementsToWrite; // Учет перемещений
                    }
                    else
                    {
                        // Аналогично для dest2
                        Array.Copy(source, i, dest2, dest2Index, elementsToWrite);
                        dest2Index += elementsToWrite;
                        AssignmentCount += elementsToWrite;
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
                int source2Length,
                ref int ComparisonCount,
                ref int AssignmentCount)
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
                        ComparisonCount++; // Учет операции сравнения
                        if (source1[index1] <= source2[index2])
                        {
                            dest[destIndex++] = source1[index1++];
                        }
                        else
                        {
                            dest[destIndex++] = source2[index2++];
                        }
                        AssignmentCount++; // Учет перемещения элемента
                    }

                    // Докопирование остатков из первой серии (если есть)
                    while (index1 < end1)
                    {
                        dest[destIndex++] = source1[index1++];
                        AssignmentCount++;
                    }

                    // Докопирование остатков из второй серии (если есть)
                    while (index2 < end2)
                    {
                        dest[destIndex++] = source2[index2++];
                        AssignmentCount++;
                    }
                }

                // Докопирование оставшихся элементов source1 (если массивы разной длины)
                while (index1 < source1Length)
                {
                    dest[destIndex++] = source1[index1++];
                    AssignmentCount++;
                }

                // Докопирование оставшихся элементов source2
                while (index2 < source2Length)
                {
                    dest[destIndex++] = source2[index2++];
                    AssignmentCount++;
                }

                // Проверка условия завершения:
                // Если размер серии превысил длину массива - сортировка завершена
                return runLength >= dest.Length;
            }

            /// <summary>
            /// Генерация массива случайных чисел
            /// </summary>
            /// <param name="size">Размер массива</param>
            /// <param name="minValue">Минимальное значение</param>
            /// <param name="maxValue">Максимальное значение</param>
            /// <returns>Сгенерированный массив</returns>
            public static int[] GenerateRandomArray(int size, int minValue = 0, int maxValue = 100)
            {
                Random random = new Random();
                int[] array = new int[size];
                for (int i = 0; i < size; i++)
                {
                    array[i] = random.Next(minValue, maxValue);
                }
                return array;
            }
        }
    }
}
