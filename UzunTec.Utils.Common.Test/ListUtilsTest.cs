using System.Collections.Generic;
using Xunit;
using UzunTec.Utils.Common;

namespace UzunTec.Utils.Common.Test
{
    public class ListUtilsTest
    {
        [Fact]
        public void AddOrUpdateTestAdd()
        {
            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"key1", "item1" }, {"key2", "item2" }, {"key3", "item3" }, {"key4", "item4" }
            };

            dic.AddOrUpdate("key5", "item5");
            Assert.Equal("item5", dic["key5"]);
            Assert.Equal(5, dic.Count);
        }

        [Fact]
        public void AddOrUpdateTestUpdate()
        {
            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"key1", "item1" }, {"key2", "item2" }, {"key3", "item3" }, {"key4", "item4" }
            };

            dic.AddOrUpdate("key3", "item5");
            Assert.Equal("item5", dic["key3"]);
            Assert.Equal(4, dic.Count);
        }

        [Fact]
        public void AddOrUpdateTestSL()
        {
            IDictionary<string, string> dic = new SortedList<string, string>
            {
                {"key1", "item1" }, {"key2", "item2" }, {"key3", "item3" }, {"key4", "item4" }
            };

            dic.AddOrUpdate("key5", "item5");
            Assert.Equal("item5", dic["key5"]);
            Assert.Equal(5, dic.Count);
        }

        [Fact]
        public void AddOrIgnoreTestAdd()
        {
            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"key1", "item1" }, {"key2", "item2" }, {"key3", "item3" }, {"key4", "item4" }
            };

            dic.AddOrIgnore("key5", "item5");
            Assert.Equal("item5", dic["key5"]);
            Assert.Equal(5, dic.Count);
        }

        [Fact]
        public void AddOrIgnoreTestSL()
        {
            IDictionary<string, string> dic = new SortedList<string, string>
            {
                {"key1", "item1" }, {"key2", "item2" }, {"key3", "item3" }, {"key4", "item4" }
            };

            dic.AddOrIgnore("key5", "item5");
            Assert.Equal("item5", dic["key5"]);
            Assert.Equal(5, dic.Count);
        }

        [Fact]
        public void AddOrIgnoreTestIgnore()
        {
            IDictionary<string, string> dic = new Dictionary<string, string>
            {
                {"key1", "item1" }, {"key2", "item2" }, {"key3", "item3" }, {"key4", "item4" }
            };

            dic.AddOrIgnore("key3", "item5");
            Assert.Equal("item3", dic["key3"]);
            Assert.Equal(4, dic.Count);
        }

        [Fact]
        public void GetFirstKeyTestBase()
        {
            IDictionary<string, string> scrambledDic = new Dictionary<string, string>
            {
                {"key3", "item2" }, {"key6", "item5" }, {"key4", "item1" }, {"key5", "item3" }
            };

            Assert.Equal("key3", scrambledDic.FirstKey());
            Assert.Equal(4, scrambledDic.Count);
        }

        [Fact]
        public void GetFirstKeyTestSL()
        {
            IDictionary<string, string> scrambledDic = new SortedList<string, string>
            {
                {"key3", "item2" }, {"key6", "item5" }, {"key4", "item1" }, {"key1", "item3" }
            };

            Assert.Equal("key1", scrambledDic.FirstKey());
            Assert.Equal(4, scrambledDic.Count);
        }

        [Fact]
        public void GetFirstKeyTestEmpty()
        {
            IDictionary<string, string> scrambledDic = new Dictionary<string, string>
            {
            };

            Assert.Null(scrambledDic.FirstKey());
            Assert.Equal(0, scrambledDic.Count);
        }

        [Fact]
        public void GetLastKeyTestBase()
        {
            IDictionary<string, string> scrambledDic = new Dictionary<string, string>
            {
                {"key3", "item2" }, {"key6", "item5" }, {"key4", "item1" }, {"key1", "item3" }
            };

            Assert.Equal("key1", scrambledDic.LastKey());
            Assert.Equal(4, scrambledDic.Count);
        }

        [Fact]
        public void GetLastKeyTestSL()
        {
            IDictionary<string, string> scrambledDic = new SortedList<string, string>
            {
                {"key3", "item2" }, {"key6", "item5" }, {"key4", "item1" }, {"key1", "item3" }
            };

            Assert.Equal("key6", scrambledDic.LastKey());
            Assert.Equal(4, scrambledDic.Count);
        }

        [Fact]
        public void GetLastKeyTestEmpty()
        {
            IDictionary<string, string> scrambledDic = new Dictionary<string, string>
            {              
            };

            Assert.Null(scrambledDic.LastKey());
            Assert.Equal(0, scrambledDic.Count);
        }
    }
}
