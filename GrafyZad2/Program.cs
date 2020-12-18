using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GrafyZad2
{
    public class ListOfContainers
    {
        public static Dictionary<int, int> containerSet = new Dictionary<int, int>();
    }
    class Program
    {
        public static Random rnd = new Random();
        public static List<int> sequence = new List<int>();
        static void Main(string[] args)
        {
            var set = ListOfContainers.containerSet;
            int[] jugs = new int[] { 14, 10, 8, 3 };
            set.Add(14, 14);
            set.Add(10, 0);
            set.Add(8, 0);
            set.Add(3, 3);
            int counter = 0;
            while ((set[10] != 5) && (set[8] != 5))
            {
                int tmp = jugs[rnd.Next(3)];
                int tmp2 = jugs[rnd.Next(3)];
                if (tmp == tmp2)
                {
                    continue;
                }
                else if (set[tmp] == 0)
                {
                    continue;
                }
                //else if (sequence.Count > 1)
                //{
                //    if ((tmp == sequence[^1] && tmp2 == sequence[^2]) || (tmp2 == sequence[^1] && tmp == sequence[^2]))
                //    {
                //        continue;
                //    }
                //}
                else
                {
                    sequence.Add(tmp);
                    sequence.Add(tmp2);
                    while (true)
                    {
                        set[tmp]--;
                        set[tmp2]++;
                        if (!(set[tmp] > 0) || (set[tmp2] != tmp2))
                        {
                            break;
                        }
                    }
                    counter++;
                }
            }
            Console.WriteLine("Stan naczyń: \n");
            foreach (var item in set)
            {
                if (item.Value == 5)
                { 
                    Console.WriteLine("Naczynie {0}l :{1}l <---", item.Key, item.Value); 
                }
                else
                {
                    Console.WriteLine("Naczynie {0}l :{1}l", item.Key, item.Value);
                }
            }
            Console.WriteLine("\n==============================\noperacja zajela {0} przelewań", counter);

            Console.WriteLine("Sekwencja przelewań: \n");
            {
                for (int i = 0; i < sequence.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine("{0}l --> {1}l", sequence[i], sequence[i + 1]);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}