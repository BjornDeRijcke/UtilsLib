using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using UtilsLib.Assemblies;
using Xunit;

namespace UtilsTests.Assemblies
{
    public class ClassDescriptorTests
    {
        [Fact]
        public void WhenCreatingDescription_ValidClass_ReturnsCorrectDescription()
        {
            // Arrange
            var type = typeof(Pain008);

            // Act
            var description = ClassDescriptor.ForClass(type);

            // Assert
            Assert.Equal("PAIN 008", description.DisplayName);
            Assert.Equal("Pain008", description.ClassType);
            Assert.Equal(4, description.Properties.Count);

            Assert.Equal("myFirstString", description.Properties[0].Name);
            Assert.Equal("ELKMON", description.Properties[0].DefaultValue);
            Assert.Equal("string", description.Properties[0].PropertyType);
            Assert.False(description.Properties[0].Required);

            Assert.Equal("mySecondString", description.Properties[1].Name);
            Assert.Null(description.Properties[1].DefaultValue);
            Assert.Equal("string", description.Properties[1].PropertyType);
            Assert.True(description.Properties[1].Required);

            Assert.Equal("classAA", description.Properties[2].Name);
            Assert.Null(description.Properties[2].DefaultValue);
            Assert.Equal("object:ThresholdSettings", description.Properties[2].PropertyType);
            Assert.True(description.Properties[2].Required);

            Assert.Equal("started", description.Properties[3].Name);
            Assert.Null(description.Properties[3].DefaultValue);
            Assert.Equal("datetime", description.Properties[3].PropertyType);
            Assert.False(description.Properties[3].Required);
        }

        [DisplayName("PAIN 008")]
        private class Pain008
        {
            [DefaultValue("ELKMON")]
            public string MyFirstString { get; set; } = "ELKMON";

            [Required]
            public string MySecondString { get; set; }

            [Required]
            public ThresholdSettings ClassAA { get; set; }

            public DateTime? Started { get; set; }
        }

        private class ThresholdSettings
        {
            public int UpperBoundX { get; set; }

            public int LowerBoundx { get; set; }

            public int UpperBoundQ { get; set; }

            public int LowerBoundQ { get; set; }

            public float? Divider { get; set; }
        }
    }
}
