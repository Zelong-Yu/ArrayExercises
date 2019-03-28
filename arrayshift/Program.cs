using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arrayshift
{
    class Program
    {
        static void Main(string[] args)
        {
            //assume arr is at least 2 elements long, and shift by less then length of arr
            var arr = new[] { 1, 2, 3, 4, 5, 6 };

            //shift array left by 2
            //fixed shift version
            //FixedShift(arr);
            //left shift variable
            //LeftShift(arr, -1);
            //linq version . lazy evaluation when using IEnumerable
            var res = LeftShiftLinq(arr, 9);

            //try change the array
            arr[4] = 100;
            arr[2] = 10;

            //3,4,5,6,1,2 //if using LeftShiftLinq it will modify the array ! because Linq use Lazy Eval
            foreach (var a in res)
            {
                Console.WriteLine($"{a} ");
            }

            Console.WriteLine();
        }



        //fixshift
        private static void FixedShift(int[] arr)
        {
            //performance concern? storage concern?
            //XOR shifting: hacky way
            var v1 = arr[0];
            var v2 = arr[1];
            
            int i;
            for (i=0; i+2 < arr.Length; ++i)
            {
                arr[i] = arr[i + 2];
            }

            //arr[arr.Length - 2] = v1;
            //arr[arr.Length - 1] = v2;
            arr[i++] = v1;
            arr[i] = v2;
        }
        private static void LeftShift(int[] arr, int n)
        {
            n %= arr.Length; 
            var tmp = new int[n];
            for (int k=0;k<n;++k)
            {
                tmp[k] = arr[k];
            }

            {
                int i;
                for (i = 0; i + n < arr.Length; ++i)
                {
                    arr[i] = arr[i + n];
                }


                for(int offset = 0; offset < n; ++offset)
                {
                    arr[i + offset] = tmp[offset];
                }

            }
        }

        //linq is functional programing embeded in c#. Skip is drop in Haskell, Concat is ++, Take is take in haskell
        private static IEnumerable<int> LeftShiftLinq(int[] arr, int nRaw)
        {
            var n = nRaw % arr.Length;
            return arr.Skip(n).Concat(arr.Take(n));
        }
        //
    }
}
