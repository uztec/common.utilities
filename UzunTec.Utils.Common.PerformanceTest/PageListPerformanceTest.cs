using System.Diagnostics;
using UzunTec.Utils.Common.PerformanceTest.Stuff;

namespace UzunTec.Utils.Common.PerformanceTest
{
    internal class PageListPerformanceTest
    {
        public static void Run()
        {
            TestWith(5, 1);
            TestWith(15, 6);
            TestWith(100, 28);
            TestWith(10000, 1234);
            TestWith(100000, 298);
            TestWith(1000000, 564);
            TestWith(1000000, 1);
        }

        private static void TestWith(int size, int pageSize)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.Write($"\nBuilding list with {size:n0} objects ...");
            List<SampleObject> list = BuildSampleObjectList(size);
            IEnumerable<SampleObject> listGeneric = list;
            int totalPages = list.Count / pageSize;
            Console.WriteLine($"{timer.ElapsedFormated()} ");

            timer.Restart();
            Console.WriteLine($"Paging List with Linq ");
            for (int page = 0; page <= totalPages; page++)
            {
                IEnumerable<SampleObject> pageData = list.Skip(page * pageSize).Take(pageSize);
                if (page < 5 || page == totalPages)
                {
                    Console.WriteLine($" - Page {page} - {pageData.Count():n0} records ");
                }
            }
            Console.WriteLine($"  - Paging List with Linq time:{timer.ElapsedFormated()} \n");

            timer.Restart();
            Console.WriteLine($"Paging Generic List with Linq ");
            for (int page = 0; page <= totalPages; page++)
            {
                IEnumerable<SampleObject> pageData = listGeneric.Skip(page * pageSize).Take(pageSize);
                if (page < 5 || page == totalPages)
                {
                    Console.WriteLine($" - Page {page} - {pageData.Count():n0} records ");
                }
            }
            Console.WriteLine($"  - Paging Generic List with Linq time:{timer.ElapsedFormated()} \n");


            timer.Restart();
            Console.WriteLine($"Paging List with Page Method ");
            int pageMethodCount = 0;
            foreach (var pageData in list.Page(pageSize))
            {
                if (pageMethodCount < 5 || pageMethodCount == totalPages)
                {
                    Console.WriteLine($" - Page {pageMethodCount} - {pageData.Count:n0} records ");
                }
                pageMethodCount++;
            }
            Console.WriteLine($"  - Paging List with Page Method time:{timer.ElapsedFormated()} \n");

            timer.Restart();
            Console.WriteLine($"Paging Generic List with Page Method");
            int pageMethod2Count = 0;
            foreach (var pageData in listGeneric.Page(pageSize))
            {
                if (pageMethod2Count < 5 || pageMethod2Count++ == totalPages)
                {
                    Console.WriteLine($" - Page {pageMethod2Count} - {pageData.Count:n0} records ");
                }
                pageMethod2Count++;
            }
            Console.WriteLine($"  - Paging Generic List with Page Method time:{timer.ElapsedFormated()} \n");
        }

        private static List<SampleObject> BuildSampleObjectList(int size)
        {
            List<SampleObject> output = new List<SampleObject>();
            for (int i = 0; i < size; i++)
            {
                output.Add(new SampleObject
                {
                    Code = StringUtils.GenerateRandomString(new Random().Next(4, 12)),
                    Name = StringUtils.GenerateRandomString(new Random().Next(15, 50)),
                    StartDate = DateTimeUtils.RandomDate(),
                    EndDate = DateTimeUtils.RandomDate(),

                });
            }
            return output;
        }
    }
}
