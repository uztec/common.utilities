using System.Collections.Generic;
using System.Diagnostics;
using UzunTec.Utils.Common.PerformanceTest.Stuff;

namespace UzunTec.Utils.Common.PerformanceTest
{
    internal class SubractListPerformanceTest
    {
        public static void Run()
        {
            TestWith(10, 5, 5);
            TestWith(500, 100, 40);
            TestWith(100, 50, 900);
            TestWith(10000, 2000, 1);
            TestWith(100000, 30000, 10000);
            TestWith(100000, 90000, 10000);
            TestWith(1000000, 564, 4055);
            TestWith(1000000, 130000, 150000);
            TestWith(4000000, 530000, 550000);
        }

        private static void TestWith(int firstListSize, int objectsInCommun, int difference)
        {
            Stopwatch timer = new Stopwatch();
            List<string> newList = new List<string>();

            timer.Start();
            Console.Write($"\nBuilding list with {firstListSize:n0} ( {objectsInCommun:n0} + {difference:n0} )objects ...");
            List<string> list = BuildFirstList(firstListSize);
            List<string> listToSubtract = BuildSecondList(list, objectsInCommun, difference);
            Console.WriteLine($"{timer.ElapsedFormated()} ");

            timer.Restart();
            Console.Write($"Scrambling Lists ...");
            //list = ScrambleList(list);
            listToSubtract = ScrambleList(listToSubtract);
            Console.WriteLine($"{timer.ElapsedFormated()} ");

            timer.Restart();
            Console.Write($"Subtracting List Base.... ");
            newList = SubtractListOriignal(list, listToSubtract);
            Console.WriteLine($"{timer.ElapsedFormated()} - {newList.Count:n0} records");

            timer.Restart();
            Console.Write($"Subtracting List Old.... ");
            Console.WriteLine($"{timer.ElapsedFormated()} - {newList.Count:n0} records");

            timer.Restart();
            Console.Write($"Subtracting List Generic.... ");
            newList = list.SubtractList(listToSubtract, (o, l) => o.PadRight(l).Substring(0,l));
            Console.WriteLine($"{timer.ElapsedFormated()} - {newList.Count:n0} records");

            timer.Restart();
            Console.Write($"Subtracting List String.... ");
            newList = list.SubtractList(listToSubtract);
            Console.WriteLine($"{timer.ElapsedFormated()} - {newList.Count:n0} records");
        }

        private static List<string> BuildFirstList(int firstListSize)
        {
            HashSet<string> output = new HashSet<string>();
            for (int i = 0; i < firstListSize; i++)
            {
                output.Add(StringUtils.GenerateRandomString(new Random().Next(3, 50)));
            }
            return new List<string>(output);
        }

        private static List<string> BuildSecondList(List<string> firstList, int objectsInCommun, int difference)
        {
            HashSet<string> output = new HashSet<string>();
            while (output.Count < objectsInCommun)
            {
                output.Add(firstList[new Random().Next(0, firstList.Count - 1)]);
            }
            while (output.Count < (objectsInCommun + difference))
            {
                output.Add(StringUtils.GenerateRandomString(new Random().Next(3, 50)));
            }
            return new List<string>(output);
        }

        public static List<T> ScrambleList<T>(List<T> list)
        {
            List<T> output = new List<T>();
            while (list.Count > 0)
            {
                int index = new Random().Next(0, list.Count - 1);
                output.Add(list[index]);
                list.RemoveAt(index);
            }
            return output;
        }


        private static List<string> SubtractListOld(IEnumerable<string> baseList, IEnumerable<string> listToSubtract)
        {
            List<string> output = new List<string>();
            IDictionary<string, List<string>> hashList = listToSubtract.DivideByGroup((o) => (o + "  ").Substring(0, 2));
            foreach (string value in baseList)
            {
                string tag = (value + "  ").Substring(0, 2);
                if (!hashList.ContainsKey(tag) || !hashList[tag].Contains(value))
                {
                    output.Add(value);
                }
            }
            return output;
        }


        private static List<T> SubtractListOriignal<T>( IEnumerable<T> baseList, IEnumerable<T> listToSubtract)
        {
            List<T> output = new List<T>();
            foreach (T value in baseList)
            {
                if (!listToSubtract.Contains(value))
                {
                    output.Add(value);
                }
            }
            return output;
        }
    }
}
