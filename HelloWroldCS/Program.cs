using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWroldCS
{
    class Program
    {
        static void Main(string[] args)
        {
            TestBigNumDivision();
            Console.ReadLine();
        }

        static void TestPrime()
        {
            int test_num = 100;
            int[] result = GetPrime(test_num);
            for (int i = 0; i < result.Length; i++)
                Console.WriteLine(result[i]);

        }

        static void TestBigNumDivision()
        {
            string str_input = "247";
            //Console.WriteLine(str_input[0]);
            int[] array_input = new int[str_input.Length];

            for (int count_input = 0; count_input < str_input.Length; count_input++)
                array_input[count_input] = str_input[count_input] - '0';


            int[] array_divisor = new int[3];
            array_divisor[0] = 1;
            array_divisor[1] = 2;
            array_divisor[2] = 3;

            bool count;

            count = ArrayDivision(ref array_input, array_divisor);
            //Console.WriteLine();
            for (int count_print = 0; count_print < array_input.Length; count_print++)
                Console.Write(array_input[count_print]);
            Console.WriteLine();
            Console.Write(count);
            Console.WriteLine();
        }

        static void ShowArrayExample()
        {
            int[] a = new int[10];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = i * i;
            }
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine($"a[{i}] = {a[i]}");
            }
        }

        static bool ArrayDivision(ref int[] input, int[] divisor)
        {
            int[] temp_array = new int[input.Length];
            int[] original_array = new int[input.Length];
            int[] out_temp_array = new int[input.Length];
            //Queue queue = new Queue();
            Array.Copy(input, original_array, input.Length);
            for (int count = 1; count < input.Length + 1; count++)
            {
                Array.Copy(input, temp_array, count);
                out_temp_array[count-1] = GetOneDivision(ref temp_array, divisor, count);
                Array.Copy(temp_array, input, count);
            }
            for(int i = 0; i < input.Length; i++)
                if (input[i] != 0)
                {
                    Array.Copy(original_array, input, input.Length);
                    return false;
                }
            Array.Copy(out_temp_array, input, input.Length);
            return true;
        }

        static int GetOneDivision(ref int[] input, int[] divisor, int count_input)
        {
            int count = 0;
            while (ArraySubstraction(ref input, divisor, count_input) != -1)
                count++;
            return count;
        }

        static int ArraySubstraction(ref int[] input, int[] divisor, int count_input)
        {
            int length_input = 0;
            int length_divisor = 0;
            int[] out_array = new int[input.Length];
            Array.ConstrainedCopy(input, 0, out_array, 0, input.Length);

            for (int i = 0; i < count_input; i++)
                if (input[i] != 0)
                {
                    length_input = count_input - i;
                    break;
                }

            for (int i = 0; i < divisor.Length; i++)
                if (divisor[i] != 0)
                {
                    length_divisor = divisor.Length - i;
                    break;
                }
            if (length_input < length_divisor)
            {
                Array.ConstrainedCopy(out_array, 0, input, 0, input.Length);
                return -1;
            }

            for (int i = 1; i < divisor.Length+1; i++)
            {
                if (i == length_input && input[count_input - i] < divisor[divisor.Length - i])
                {
                    Array.ConstrainedCopy(out_array, 0, input, 0, input.Length);
                    return -1;
                }
                if (input[count_input - i] >= divisor[divisor.Length - i])
                    input[count_input - i] = input[count_input - i] - divisor[divisor.Length - i];
                else
                {
                    input[count_input - i] = input[count_input - i] - divisor[divisor.Length - i] + 10;
                    input[count_input - i - 1]--;
                }

            }
            return 0;
        }

        static int[] GetPrime(int input)
        {
            Queue<int> q_prime = new Queue<int>();
            q_prime.Enqueue(2);
            for (int i = 3; i < input; i++)
                if (CheckPrime(i, q_prime))
                    q_prime.Enqueue(i);
            int[] list_prime = new int[q_prime.Count];
            list_prime = q_prime.ToArray();
            return list_prime;
        }

        static bool CheckPrime(int input, Queue<int> q_prime)
        {
            int[] prime = q_prime.ToArray();
            for (int i = 0; i < prime.Length; i++)
                if (input % prime[i] == 0)
                    return false;
            return true;
        }

        static int[][] GetPrimeBigNum(int[] input)
        {
            Queue<int[]> q_prime = new Queue<int[]>();
            int[] prime2 = new int[1];
            prime2[0] = 2;
            q_prime.Enqueue(prime2);
            for (int i = )
        }
    }

    class BigNum
    {
        int[] storage;

        bool init(string str_input)
        {
            storage = new int[str_input.Length];
            for (int count_input = 0; count_input < str_input.Length; count_input++)
                storage[count_input] = str_input[count_input] - '0';
            return true;
        }

        bool Division(BigNum divisor)
        {
            //int[] array_divisor = new int[divisor.storage.Length];
            int[] temp_array = new int[storage.Length];
            int[] original_array = new int[storage.Length];
            int[] out_temp_array = new int[storage.Length];
            //Queue queue = new Queue();
            Array.Copy(storage, original_array, storage.Length);
            for (int count = 1; count < storage.Length + 1; count++)
            {
                Array.Copy(storage, temp_array, count);
                out_temp_array[count - 1] = GetOneDivision(ref temp_array, divisor.storage, count);
                Array.Copy(temp_array, storage, count);
            }
            for (int i = 0; i < storage.Length; i++)
                if (storage[i] != 0)
                {
                    Array.Copy(original_array, storage, storage.Length);
                    return false;
                }
            Array.Copy(out_temp_array, storage, storage.Length);
            return true;
        }

        int GetOneDivision(ref int[] input, int[] divisor, int count_input)
        {
            int count = 0;
            while (ArraySubstraction(ref input, divisor, count_input) != -1)
                count++;
            return count;
        }

        int ArraySubstraction(ref int[] input, int[] divisor, int count_input)
        {
            int length_input = 0;
            int length_divisor = 0;
            int[] out_array = new int[input.Length];
            Array.ConstrainedCopy(input, 0, out_array, 0, input.Length);

            for (int i = 0; i < count_input; i++)
                if (input[i] != 0)
                {
                    length_input = count_input - i;
                    break;
                }

            for (int i = 0; i < divisor.Length; i++)
                if (divisor[i] != 0)
                {
                    length_divisor = divisor.Length - i;
                    break;
                }
            if (length_input < length_divisor)
            {
                Array.ConstrainedCopy(out_array, 0, input, 0, input.Length);
                return -1;
            }

            for (int i = 1; i < divisor.Length + 1; i++)
            {
                if (i == length_input && input[count_input - i] < divisor[divisor.Length - i])
                {
                    Array.ConstrainedCopy(out_array, 0, input, 0, input.Length);
                    return -1;
                }
                if (input[count_input - i] >= divisor[divisor.Length - i])
                    input[count_input - i] = input[count_input - i] - divisor[divisor.Length - i];
                else
                {
                    input[count_input - i] = input[count_input - i] - divisor[divisor.Length - i] + 10;
                    input[count_input - i - 1]--;
                }

            }
            return 0;
        }

    }
}
