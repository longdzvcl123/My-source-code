using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step1
{
    class Program
    {
        static void Main(string[] args)
        {
            Queens BL = new Queens();
            Console.Write("Enter N: ");
            BL.Init();
            BL.printQueens();
            Console.ReadKey();
        }
    }
    class Queens
    {
        private int[,] arr;
        private int n;

        public void Init()
        {
            n = Convert.ToInt32(Console.ReadLine());
            arr = new int[n, n];
        }
        public int max(int x,int  y)
        {
            return (x > y) ? x : y;
        }
        public int min (int x,int y)
        {
            return (x > y) ? y : x;
        }
        private bool checkRow( int col, int row = 0)
        {
            if (row >= n) return true;
            if (arr[row, col] != 0) return false;
            return checkRow( col, row + 1);
        }
        private bool checkCol(int row, int col = 0)
        {
            if (col >= n) return true;
            if (arr[row, col] != 0) return false;
            return checkCol(row, col + 1);
        }
        private bool checkCross_1(int row, int col)
        {
            if (row < 0 || col < 0) return true;
            if (arr[row, col] != 0) return false;
            return checkCross_1(row - 1, col - 1);
        }
        private bool checkCross_2(int row, int col)
        {
            if (row < 0 || col >= n) return true;
            if (arr[row, col] != 0) return false;
            return checkCross_1(row - 1, col + 1);
        }
        public bool checkQueen(int row,int col)
        {
            return (checkCol(row) && checkRow(col) && checkCross_1(row, col));
        }
        public bool tickQueens(int N, int row, int col)
        {
            if (col >= n) return false;
            if (row >= n)
            {
                if (N == 0) return true;
                return false;
            }
            if (checkQueen(row, col))
            {
                arr[row, col] = 1;
                if (tickQueens(N - 1, row + 1, 0)) return true;
                else
                {
                    arr[row, col] = 0;
                    return tickQueens(N, row, col + 1);
                }
            }
            else return tickQueens(N, row, col + 1);
        }
        public void printQueens()
        {
            int tmp = n;
            if (tickQueens(tmp, 0, 0))
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(arr[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
