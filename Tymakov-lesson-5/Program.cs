using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Tymakov_lesson_5
{

    enum Month
    {
        January,
        February,
        March,
        April,
        May,
        June,
        Jule,
        August,
        September,
        October,
        November,
        December
    }
    internal class Program
    {

        /// <summary>
        /// Возвращает масив первый элемент - кол-во гласных, второй - кол-во согласных
        /// </summary>
        /// <param name="fileText"></param>
        /// <returns></returns>
        static int[] GetVowConCount(List<char> TextChars)
        {
            string vowels = "аеёиоуыэюя";
            int vowelsCount = 0;
            int consonantCount = 0;

            foreach (char letter in TextChars)
            {
                if (char.IsLetter(letter))
                {
                    if (vowels.Contains(char.ToLower(letter)))
                    {
                        vowelsCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }
            return [vowelsCount, consonantCount];
        }

        /// <summary>
        /// Считывает текст с уже созданного файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static List<char> GetTextOfFile(string fileName)
        {
            Console.WriteLine("Введите текст в файл: ");
            string text = Console.ReadLine();
            using FileStream file = new FileStream(fileName, FileMode.Create);
            byte[] array = System.Text.Encoding.UTF8.GetBytes(text);
            file.Read(array, 0, array.Length);

            char[] chars = System.Text.Encoding.UTF8.GetString(array).ToCharArray();

            //Зачем в этой задаче использовать лист когда я могу передать сам массив символов в функцию я не понимаю
            List<char> list = [.. chars];
            return list;
        }

        /// <summary>
        /// Числа в матрице не превышают 10
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="cols"></param>
        /// <returns></returns>
        static int[,] GetMatrix2D(int rows, int cols)
        {
            Random rnd = new Random();
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rnd.Next(-20, 35);
                }
            }
            return matrix;
        }

        static int[,] MultiplayMatrixs(int[,] matrix1, int[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                Console.WriteLine("Мы не можем перемножить эти матрицы");
                return null;
            }
            else
            {
                int temp = 0;
                int[,] multiplayed = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
                for (int row = 0; row < multiplayed.GetLength(0); row++)
                {
                    for (int col = 0; col < multiplayed.GetLength(1); col++)
                    {
                        temp = 0;
                        for (int i = 0; i < matrix1.GetLength(1); i++)
                        {
                            temp += matrix1[row, i] * matrix2[i, col];
                        }
                        multiplayed[row, col] = temp;
                    }
                }
                return multiplayed;
            }
        }

        static void Main(string[] args)
        {
            //Написать программу, которая вычисляет число гласных
            //и согласных букв в файле.Имя файла передавать как аргумент в функцию
            //Main.Содержимое текстового файла заносится в массив символов.Количество
            //гласных и согласных букв определяется проходом по массиву.Предусмотреть
            //метод, входным параметром которого является массив символов.Метод
            //вычисляет количество гласных и согласных букв.

            Console.WriteLine("Упражнение 6.1");
            int[] vowConCounters = GetVowConCount(GetTextOfFile("text.txt"));
            Console.WriteLine($"Кол-во гласных букв: {vowConCounters[0]}\nКол-во согласных букв: {vowConCounters[1]}");


            //Написать программу, реализующую умножению двух матриц, заданных в
            //виде двумерного массива.В программе предусмотреть два метода: метод печати матрицы,
            //метод умножения матриц(на вход две матрицы, возвращаемое значение – матрица).
            Console.WriteLine("\nУпражнение 6.2");

            Console.WriteLine("Введите размерности первой и второй матрицы(положительные числа, по одному в столбик): ");


            int[,] multiplayedMatrix;

            if (!int.TryParse(Console.ReadLine(), out int n1) || !int.TryParse(Console.ReadLine(), out int m1) || !int.TryParse(Console.ReadLine(), out int n2) || !int.TryParse(Console.ReadLine(), out int m2))
            {
                Console.WriteLine("Вы не праильно ввели размерности. Будут переданны 2, 2 и 2, 3");
                multiplayedMatrix = MultiplayMatrixs(GetMatrix2D(2, 2), GetMatrix2D(2, 3));
            }
            else
            {
                multiplayedMatrix = MultiplayMatrixs(GetMatrix2D(Math.Abs(n1), Math.Abs(m1)), GetMatrix2D(Math.Abs(n2), Math.Abs(m2)));
            }


            if (multiplayedMatrix != null)
            {
                for (int row = 0; row < multiplayedMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < multiplayedMatrix.GetLength(1); col++)
                    {
                        Console.Write(multiplayedMatrix[row, col] + "\t");
                    }
                    Console.WriteLine();
                }
            }


            //Написать программу, вычисляющую среднюю температуру за год. Создать
            //двумерный рандомный массив temperature[12, 30], в котором будет храниться температура
            //для каждого дня месяца(предполагается, что в каждом месяце 30 дней).Сгенерировать
            //значения температур случайным образом. Для каждого месяца распечатать среднюю
            //температуру.Для этого написать метод, который по массиву temperature[12, 30] для каждого
            //месяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив
            //средних температур.Полученный массив средних температур отсортировать по
            //возрастанию.

            Console.WriteLine("\nУпражнение 6.3");

            Dictionary<Month, double> temperatures = new Dictionary<Month, double>();


            int[,] yearTemperature = GetMatrix2D(12, 30);

            for (int row = 0; row < yearTemperature.GetLength(0); row++)
            {
                double sum = 0;
                for (int col = 0; col < yearTemperature.GetLength(1); col++)
                {
                    sum += yearTemperature[row, col];
                }
                temperatures.Add((Month)row, (double)sum / yearTemperature.GetLength(1));
            }

            foreach (var item in temperatures)
            {
                Console.WriteLine($"{item.Key} : {item.Value:F1}");
            }

            Console.ReadKey();
        }
    }
}
