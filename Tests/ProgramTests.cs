using System;
using System.Collections.Generic;
using Xunit;

namespace Module7Assignment.Tests
{
    // These tests validate core dictionary behaviors:
    public class ProgramTests
    {
        [Fact]
        public void AddAndRetrieveValues()
        {
            var dict = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            var key = "Cities";
            dict[key] = new List<string> { "New York" };
            dict[key].Add("Los Angeles");

            Assert.True(dict.ContainsKey(key));
            Assert.Collection(dict[key],
                item => Assert.Equal("New York", item),
                item => Assert.Equal("Los Angeles", item));
        }

        [Fact]
        public void RemoveKey_RemovesEntry()
        {
            var dict = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
            dict["K"] = new List<string> { "v" };
            var removed = dict.Remove("K");
            Assert.True(removed);
            Assert.False(dict.ContainsKey("K"));
        }
    }
}