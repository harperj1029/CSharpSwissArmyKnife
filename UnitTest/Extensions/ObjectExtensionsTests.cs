using Microsoft.VisualStudio.TestTools.UnitTesting;
using Extensions;
using System;
using FluentAssertions;

namespace UnitTest.Extensions
{
    [TestClass]
    public class ObjectExtensionsTests
    {
        [TestMethod]
        public void ShouldClone()
        {
            // Arrange
            var foo = new Foo { Bar = "Bar1", Baz = 1 };

            // Act
            var fooClone = foo.DeepClone();

            // Assert
            foo.Should().BeEquivalentTo(fooClone);
        }
    }

    [Serializable]
    public class Foo
    {
        public string Bar { get; set; }
        internal int Baz { get; set; }
    }
}
