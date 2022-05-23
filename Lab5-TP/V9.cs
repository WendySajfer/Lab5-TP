using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassV
{
    internal class V9
    {
        private double[,] numbers;
        private int m;
        private int n;
        public V9(int rows, int columns)
        {
            m = rows;
            n = columns;
            numbers = new double[m, n];
        }
        public V9(V9 v)
        {
            m = v.m;
            n = v.n;
            numbers = new double[m, n];
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    numbers[i, j] = v.numbers[i, j];
                }
            }
        }
        public static V9 operator +(V9 v, int index)
        {
            for(int i = 0; i < v.m; i++)
            {
                v.numbers[i, 0] += v.numbers[i, index];
            }
            return v;
        }
        public int Rows { 
            get{ return m; } 
            set { m = value; }
        }
        public int Columns
        {
            get { return n; }
            set { n = value; }
        }
        public double this[int row, int col]
        {
            get { return numbers[row, col]; }
            set { numbers[row, col] = value; }
        }
    }
}
