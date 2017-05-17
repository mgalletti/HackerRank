using System;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DArray
{
    class Program
    {
        static void Main(String[] args)
        {
            string inputFile = Path.Combine(ConfigurationSettings.AppSettings["ResourcePath"].ToString(), "input3_o-6.txt");
            if (!File.Exists(inputFile))
            {
                throw new Exception(string.Format("file {0} don't exists", inputFile));
            }
            StreamReader sr = new StreamReader(inputFile);

            int[][] arr = new int[6][];
            //for (int arr_i = 0; arr_i < 6; arr_i++)
            //{
            //    string[] arr_temp = Console.ReadLine().Split(' ');
            //    arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            //}

            for (int arr_i = 0; arr_i < 6; arr_i++)
            {
                string[] arr_temp = sr.ReadLine().Split(' ');
                arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            }

            ArrayParser parser = new ArrayParser();
            parser.ParseArray(arr);

            parser.PrintAll();

            Console.WriteLine(parser.GetLargestHourglass().ToString());
            Console.ReadLine();
        }
    }

    class HourglassArray 
    {

        private int[][] arr = new int[3][];

        public HourglassArray(int x, int y, int[][] parentArr)
        {
            arr[0] = new int[3];
            arr[1] = new int[3];
            arr[2] = new int[3];
            Array.Copy(parentArr[y], x, arr[0], 0, 3);
            Array.Copy(parentArr[y + 1], x, arr[1], 0, 3);
            Array.Copy(parentArr[y + 2], x, arr[2], 0, 3);
        }

        public int Sum()
        {
            int result = arr[0].Sum();
            result += arr[1][1];
            result += arr[2].Sum();

            return result;
        }

        public void Print()
        { 
            for (int i = 0; i < 3; i++)
			{
                Console.WriteLine(string.Join(" ", arr[i]));
			}
        }
    }

    class ArrayParser 
    {
        private List<HourglassArray> hourglasses;
        public void ParseArray(int[][] arr)
        {
            hourglasses.Clear();

            int x = 0, y = 0;
            while (y + 2 < 6)
            {
                hourglasses.Add(new HourglassArray(x, y, arr));
                if (x + 3 == 6)
                {
                    y++;
                    x = 0;
                }
                else
                {
                    x++;
                }
            }
        }

        public ArrayParser()
        {
            hourglasses = new List<HourglassArray>();
        }

        public void PrintAll()
        {
            foreach (var hg in hourglasses)
            {
                hg.Print();
                Console.WriteLine("------");
            }
        }

        public int GetLargestHourglass()
        {
            int sum = Int32.MinValue;
            foreach (var hg in hourglasses)
            {
                if (hg.Sum() > sum)
                {
                    sum = hg.Sum();
                }
            }
            return sum;
        }
    }
}
