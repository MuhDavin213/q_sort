using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace q_sort
{
    class program
    {
        private int[] arr = new int[20];
        private int cmp_count = 0;
        private int mov_count = 0;

        private int n;


        void read()
        {
            while (true)
            {
                Console.Write("Enter the number of elements in the array : ");
                string s = Console.ReadLine();
                n = Int32.Parse(s);
                if (n <= 0)
                    break;
                else
                    Console.WriteLine("\n Array can have maximum 30 elements \n");
            }
            Console.WriteLine("\n ====================");
            Console.WriteLine("\n enter array element");
            Console.WriteLine("\n ====================");

            //get elemet array
            for (int i = 0; i < n; i++)
            {
                Console.Write("<" + (i + 1) + ">");
                string s1 = Console.ReadLine();
                arr[i] = Int32.Parse(s1);
            }
            //swaps the element at index x with the elemetn at index y
        }
        void swap(int x, int y)
        {
            int temp;

            temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }
        void q_sort(int low, int high)
        {
            int pivot, i, j;
            if (low > high)
                return;

            //partition the list into two parts
            //one containing element less that or equal to pivot
            //other containing element greater than pivot
            i = low + 1;
            j = high;

            pivot = arr[low];

            while (i <= j)
            {
                //searh for an element greater than pivot
                while ((arr[i] > pivot) && (arr[j] < pivot))
                {
                    i++;
                    cmp_count++;
                }

                //search for an element less than or equal to pivot
                while ((arr[j] > pivot) && (j >= low))
                {
                    j--;
                    cmp_count++;
                }
                if (i < j) //if the greater element is on the left of the element
                {
                    swap(i, j);
                    cmp_count++;
                }
            }
            //j now contains the index of the last element in the sorted list

            if (low < j)
            {
                //move to pivot to its correct pisition in the list
                swap(low, j - 1);
                mov_count++;
            }
            //sort the list on the left of pivvot using quick sort
            q_sort(low, j - 1);

            //sort the list on the right of pivot using quick sort
            q_sort(j + 1, high);
        }
        void display()
        {
            Console.WriteLine("\n---------------------");
            Console.WriteLine("\nsorted array element");
            Console.WriteLine("\n---------------------");

            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(arr[j]);
            }
            Console.WriteLine("\nNumber of comparrison: " + cmp_count);
            Console.WriteLine("\nNumber of data movement: " + mov_count);
        }
        int getSize()
        {
            return (n);
        }
        static void Main(string[] args)
        {
            program myList = new program();
            myList.read();
            myList.q_sort(0, myList.getSize() - 1);
            myList.display();
            Console.WriteLine("\n\npress enter to exit,");
            Console.Read();
        }
    }
}

