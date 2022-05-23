using System;
using System.IO;
using System.Globalization;
using ClassV;

namespace Application
{
    class Program
    {
        public static int[] row_col(string line_data1)
        {
            int[] r_c = new int[2];
            r_c[0] = 0;
            r_c[1] = 0;
            if (line_data1.Length > 5)
            {
                Console.WriteLine("Исходные данные не корректны. Поместите количество строк и столбцов в первую строку.");
                return r_c;
            }
            string[] subs = line_data1.Split(' ');
            if (subs.Length != 2)
            {
                Console.WriteLine("Исходные данные не корректны. Поместите количество строк и столбцов в первую строку.");
                return r_c;
            }
            bool test1 = true;
            bool isNum;
            for (int i = 0; i < 2; i++)
            {
                isNum = int.TryParse(subs[i], out r_c[i]);
                if (!isNum)
                {
                    test1 = false;
                }
                   
            }
            if (!test1)
            {
                Console.WriteLine("Исходные данные не корректны. Количество строк и столбцов не являются числами.");
                r_c[0] = 0;
                r_c[1] = 0;
                return r_c;
            }
            bool test2 = true;
            for (int i = 0; i < 2; i++)
            {
                if (r_c[i] < 2 || r_c[i] > 50) test2 = false;
            }
            if (!test2)
            {
                Console.WriteLine("Количество строк и столбцов не корректны.");
                r_c[0] = 0;
                r_c[1] = 0;
                return r_c;
            }
            return r_c;
        }

        public static void Main(string[] args)
        {
            int m, n, k;
            string[] str_lines = { };
            try
            {
                str_lines = File.ReadAllLines("G:\\My\\Proga\\Lab5-TP\\Lab5-TP\\Input.txt");
            }
            catch (IOException exc)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(exc.ToString());
                return;
            }
            /*foreach (string line in str_lines)
            {
                Console.Write(line + "\n");
            }*/
            int[] r_c = row_col(str_lines[0]);
            if (r_c[0] == 0)
            {
                Console.WriteLine("Данные не корректны.");
                return;
            }
            else
            {
                m = r_c[0];
                n = r_c[1];
                k = r_c[2];/*доделать v+2*/
            }
            if(str_lines.Length != (m + 1))
            {
                Console.WriteLine("Количество строк не совпадает с данными.");
                return;
            }
            V9 v = new V9(m, n);
            for(int i = 1; i < m + 1; i++)
            {
                string[] subs_lines = str_lines[i].Split(' ');
                if (subs_lines.Length != n)
                {
                    Console.WriteLine("Неверное количество элементов в строках массива.");
                    return;
                }
                else
                {
                    for (int j = 0; j < n; j++)
                    {
                        double element;
                        if (double.TryParse(subs_lines[j], NumberStyles.Float, CultureInfo.InvariantCulture, out element))
                        {
                            v[i - 1, j] = element;
                        }
                        else
                        {
                            Console.WriteLine("Элементы массива не корректны.");
                            return;
                        }
                    }
                }
            }
            StreamWriter file;
            try
            {
                file = new StreamWriter("G:\\My\\Proga\\Lab5-TP\\Lab5-TP\\Output.txt");
            }
            catch (IOException exc)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(exc.ToString());
                return;
            }
            file.WriteLine("Array:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    file.Write(v[i, j] + " ");
                }
                file.WriteLine();
            }
            file.WriteLine("Rows = " + m + " Columns=" + n);
            v = v + 2;
            V9 v1 = new V9(v);
            file.WriteLine("Array 1:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    file.Write(Math.Round(v1[i, j], 3) + " ");
                }
                file.WriteLine();
            }
            Console.WriteLine("Результат записан в файл.");
            file.Close();
        }
    }
}