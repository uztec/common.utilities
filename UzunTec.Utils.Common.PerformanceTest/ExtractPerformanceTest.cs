using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UzunTec.Utils.Common.PerformanceTest.Stuff;

namespace UzunTec.Utils.Common.PerformanceTest
{
    internal class ExtractPerformanceTest
    {
        public static void Run()
        {
            TestWith(10000);
            TestWith(100000);
            TestWith(1000000);
            TestWith(10000000);
            //TestWith(100000000);
        }

        private static void TestWith(int size)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.Write($"\nBuilding list with {size:n0} objects ...");
            IEnumerable<SampleObject> list = BuildSampleObjectList(size);
            Console.WriteLine($"{timer.ElapsedFormated()} ");

            timer.Restart();
            Console.Write($"Extracting Name with Linq ...");
            IEnumerable<string> namesLinq = list.Select(o => o.Name);
            Console.WriteLine($"{timer.ElapsedFormated()} ");

            timer.Restart();
            Console.Write($"Doing job with Linq list...");
            StringBuilder sbLinq = new StringBuilder();
            namesLinq.ForEach(s => sbLinq.Append(s) );
            Console.WriteLine($"{timer.ElapsedFormated()} ");

            timer.Restart();
            Console.Write($"Extracting Name with Utils Lib ...");
            List<string> names = list.Extract(o => o.Name);
            Console.WriteLine($"{timer.ElapsedFormated()} ");

            timer.Restart();
            Console.Write($"Doing job with Utils lib list...");
            StringBuilder sbUtils = new StringBuilder();
            names.ForEach(s => sbUtils.Append(s));
            Console.WriteLine($"{timer.ElapsedFormated()} ");

            timer.Restart();
            Console.Write($"Extracting Distinct code with Linq ...");
            IEnumerable<string> codesLinq = list.Select(o => o.Code).Distinct();
            Console.WriteLine($"{timer.ElapsedFormated()} - {codesLinq.Count():n0} records");

            timer.Restart();
            Console.Write($"Doing job with Distinct Linq list...");
            StringBuilder sbCodesLinq = new StringBuilder();
            codesLinq.ForEach(s => sbCodesLinq.Append(s));
            Console.WriteLine($"{timer.ElapsedFormated()} ");


            timer.Restart();
            Console.Write($"Extracting distinct Codes with Utils Lib ...");
            HashSet<string> codes = list.ExtractDistinct(o => o.Code);
            Console.WriteLine($"{timer.ElapsedFormated()} - {codes.Count:n0} records");

            timer.Restart();
            Console.Write($"Doing job with distinct Utils lib list...");
            StringBuilder sbCodeUtils = new StringBuilder();
            codes.ForEach(s => sbCodeUtils.Append(s));
            Console.WriteLine($"{timer.ElapsedFormated()} ");

            timer.Restart();
            Console.Write($"Comparing Objects ...");
            int compareListResult = namesLinq.CompareList(names);
            int compareStringResult = sbUtils.ToString().CompareTo(sbLinq.ToString());
            Console.WriteLine($"{timer.ElapsedFormated()}  - Result: {compareStringResult} / {compareListResult}");
        }

        private static List<SampleObject> BuildSampleObjectList(int size)
        {
            List<SampleObject> output = new List<SampleObject>();
            for (int i = 0; i < size; i++)
            {
                output.Add(new SampleObject
                {
                    Code = StringUtils.GenerateRandomString(new Random().Next(1,4)),
                    Name =  StringUtils.GenerateRandomString(new Random().Next(15, 50)),
                    StartDate = DateTimeUtils.RandomDate(),
                    EndDate = DateTimeUtils.RandomDate(),

                });
            }
            return output;
        }
    }
}
