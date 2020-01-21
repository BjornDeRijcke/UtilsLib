using UtilsLib.Unsafe;
using Xunit;

namespace UtilsTests.Unsafe
{
    public class ObjPtrTests
    {
        [Fact]
        public void ObjPtr_Deref_Value()
        {
            // Arrange
            object pointedValue = new OtherClass("tmp");
            var ptr = new ObjPtr<object>(() => pointedValue, (v) => pointedValue = v);

            // Act
            ptr.Deref = new DummyClass { x = 10L };

            // Assert;
            Assert.Equal(10L, (pointedValue as DummyClass).x);
        }

        [Fact]
        public void ObjPtr_Deref_ReferenceEquals()
        {
            // Arrange
            object pointedValue = new OtherClass("tmp");
            var ptr = new ObjPtr<object>(() => pointedValue, (v) => pointedValue = v);

            // Act
            var val = ptr.Deref;

            // Assert;
            Assert.Same(pointedValue, val);
        }

        private class DummyClass
        {
            public long x;
        }

        private class OtherClass
        {
            public OtherClass(string v)
                => _q = v;

            private string _q;
        }
    }

    public class ValPtrTests
    {
        [Fact]
        public void Ptr_Set_Value()
        {
            // Arrange
            long pointedValue = 0L;
            var ptr = new ValPtr<long>(() => pointedValue, (v) => pointedValue = v);

            // Act
            ptr.Deref = 9L;

            // Assert
            Assert.Equal(9L, pointedValue);
        }

        [Fact]
        public void Ptr_Deref_Value()
        {
            // Arrange
            long pointedValue = 89L;
            var ptr = new ValPtr<long>(() => pointedValue, (v) => pointedValue = v);

            // Act
            var val = ptr.Deref;
            ptr.Deref = 0L;

            // Assert
            Assert.Equal(89L, val);
            Assert.Equal(0L, pointedValue);
        }
    }
}
