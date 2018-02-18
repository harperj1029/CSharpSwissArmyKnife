using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using CSharpSwissArmyKnife.Extensions;

namespace UnitTest.Extensions
{
    [TestClass]
    public class ObjectExtensionsTests
    {
        [TestMethod]
        public void ShouldClone()
        {
            // Arrange
            var foo = new Foo { Bar = new Bar { Baz = "Foo-Bar-Baz" } };

            // Act
            var fooClone = foo.DeepClone();

            // Assert
            foo.Should().BeEquivalentTo(fooClone);
            foo.Bar.Should().BeEquivalentTo(fooClone.Bar);
            foo.Should().NotBe(fooClone);
            foo.Bar.Should().NotBe(fooClone.Bar);            
        }
    }

    [Serializable]
    public class Foo
    {
        public Bar Bar { get; set; }        
    }

    [Serializable]
    public class Bar
    {
        public string Baz { get; set; }
    }
}
