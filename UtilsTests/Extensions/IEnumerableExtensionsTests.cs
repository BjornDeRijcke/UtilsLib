using System.Linq;
using UtilsLib.Extensions;
using Xunit;

namespace UtilsTests.Extensions
{
    public class IEnumerableExtensionsTests
    {
        [Fact]
        public void Distinct()
        {
            var input = new DistinctTestClass[] { new DistinctTestClass { Prop = 'a' }, new DistinctTestClass { Prop = 'a' }, new DistinctTestClass { Prop = '\u00AD' }, new DistinctTestClass { Prop = 'µ' }, new DistinctTestClass { Prop = 'µ' }, new DistinctTestClass { Prop = '±' } }.AsEnumerable();
            var expected = new DistinctTestClass[] { new DistinctTestClass { Prop = 'a' }, new DistinctTestClass { Prop = '\u00AD' }, new DistinctTestClass { Prop = 'µ' }, new DistinctTestClass { Prop = '±' } };

            var output = input.Distinct(i => i.Prop).ToArray();

            for (int i = 0; i < output.Length; i++)
            {
                Assert.Equal(expected[i].Prop, output[i].Prop);
            }
        }

        private class DistinctTestClass
        {
            public char Prop { get; set; }
        }
    }
}
