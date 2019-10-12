using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isThree = true; // Перевенная, которая означает проверку. Поставлены ли числа кратные 3 в левую сторону. True = не поставлены, False = поставлены.
            var list = new List<int>(); // Создание динамического массива
            int intArraySize;   // Длина массива

            Console.WriteLine("Write array's size:");
            string strArraySize = Console.ReadLine();
            intArraySize = Convert.ToInt32(strArraySize);

            for (int i = 1; i <= intArraySize; i++)
            {
                list.Add(i);
            }

            var intMass = list.ToArray();

            Console.WriteLine("Original array is:");
            foreach (int i in intMass)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            void Swap(ref int firstElement, ref int secondElement) // Функция обмена переменных в массиве
            {
                int forChange;

                forChange = firstElement;
                firstElement = secondElement;
                secondElement = forChange;
            }

            int ThreeMultiple(ref int[] mass, int indexStart, int indexFinish) // Функция переноса чисел кратных 3 в левую часть массива
            {
                int indexPivot = indexStart;

                for (int i = indexStart; i <= indexFinish; i++)
                {
                    if ((mass[i] % 3) == 0)
                    {
                        Swap(ref mass[i], ref mass[indexPivot]);
                        indexPivot++;
                    }
                }

                return indexPivot;
            }

            int PivotFinding(ref int[] mass, int indexStart, int indexFinish) // Функция переноса чисел, меньших последнего элемента массива в левую часть, а больших в правую. Последний элемент между ними
            {
                int indexPivot = indexStart;

                for (int i = indexStart; i < indexFinish; i++)
                {
                    if (mass[i] <= mass[indexFinish])
                    {
                        Swap(ref mass[i], ref mass[indexPivot]);
                        indexPivot++;
                    }
                }

                Swap(ref mass[indexPivot], ref mass[indexFinish]);

                return indexPivot;
            }

            void QuickSort(ref int[] mass, int indexStart, int indexFinish, ref bool three) // Быстрая сортировка
            {
                if (indexStart < indexFinish)
                {
                    if (three)
                    {
                        int indexPivot = ThreeMultiple(ref mass, indexStart, indexFinish);
                        three = false;
                        QuickSort(ref mass, indexStart, indexPivot - 1, ref three);
                        QuickSort(ref mass, indexPivot, indexFinish, ref three);
                    }
                    else
                    {
                        int indexPivot = PivotFinding(ref mass, indexStart, indexFinish);
                        QuickSort(ref mass, indexStart, indexPivot - 1, ref three);
                        QuickSort(ref mass, indexPivot + 1, indexFinish, ref three);
                    }
                }
            }

            QuickSort(ref intMass, 0, intMass.Length - 1, ref isThree);

            Console.WriteLine("Quicksorted array is:");
            foreach (int i in intMass)
            {
                Console.Write(i + " ");
            }
            Console.ReadLine();
        }
    }
}
