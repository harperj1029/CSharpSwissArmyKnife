using NUnit.Framework;
using System;
using FluentAssertions;
using CSharpSwissArmyKnife.Extensions;

namespace UnitTest.Extensions
{
    [TestFixture]
    public class ObjectExtensionsTests
    {
        [Test]
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

        [Test]
        public void CopyProperties_Should_copy_read_write_properties()
        {
            // Arrange
            var someClass = new SomeClass
            {
                Property1 = 1,
                Property2 = 2,
                Property3 = "Property 3",
                Property4 = 4,
                Property5 = -1
            };
            var similarClass = new SomeSimilarClass();

            // Act
            someClass.CopyProperties(similarClass);

            // Assert
            similarClass.Property1.Should().Equals(someClass.Property1);
            similarClass.Property2.Should().Equals(someClass.Property2);
            similarClass.Property3.Should().BeNull(); // bar.Property3 is not writable, so not copied
            similarClass.Property4.Should().BeNull(); // bar.Property4's type doesn't match, so not copied
            similarClass.Property5.Should().Equals(someClass.Property5);
        }

        [Serializable]
        class Foo
        {
            public Bar Bar { get; set; }
        }

        [Serializable]
        class Bar
        {
            public string Baz { get; set; }
        }

        class SomeClass
        {
            public int Property1 { get; set; }
            public decimal Property2 { get; set; }
            public string Property3 { get; set; }
            public int Property4 { get; set; }
            public string PropertyUniqueToFoo { get; set; }
            public int? Property5 { get; set; }
            public string PropertyWithGetterOnly { get; }
        }

        class SomeSimilarClass
        {
            public SomeSimilarClass()
            {
                Property3 = null;
            }

            public int Property1 { get; set; }
            public decimal Property2 { get; set; }

            public string Property3 { get; private set; }
            public string Property4 { get; set; } 
            public string PropertyUniqueToBar { get; set; }
            public int? Property5 { get; set; }
        }

    }
}
