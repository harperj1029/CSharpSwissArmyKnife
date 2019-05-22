using System;
using System.Collections.Generic;
using System.Dynamic;
using NUnit.Framework;
using FluentAssertions;
using CSharpSwissArmyKnife.Extensions;

namespace UnitTest.Extensions
{
    [TestFixture]
    public class ExpandoObjectExtensionsTests
    {
        [Test]
        public void ShouldMergeAnonymousObjects()
        {
            // Arrange
            var foo = new { Foo = "Foo" };
            var bar = new { Bar = "Bar" };
            var baz = new { Baz = "Baz" };

            // Act
            dynamic result = new ExpandoObject().AddProperties(foo).AddProperties(bar).AddProperties(baz);

            // Assert
            ((string)result.Foo).Should().Equals("Foo");
            ((string)result.Bar).Should().Equals("Bar");
            ((string)result.Baz).Should().Equals("Baz");
        }

        [Test]
        public void Should_AddPublicProperties_LastOneWithValueWins()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var a = new ObjectA { PropertyOne = 1, PropertyTwo = "two" };
            var b = new ObjectB { PropertyOne = 2, PropertyTwo = null, PropertyThree = now };

            // Act
            dynamic c = new ExpandoObject().AddProperties(a).AddProperties(b);

            // Assert
            ((int)c.PropertyOne).Should().Equals(2);
            ((string)c.PropertyTwo).Should().Equals("two");
            ((DateTime?)c.PropertyThree).Should().Equals(now);
            var cAsDictionary = c as IDictionary<string, object>;
            cAsDictionary.Count.Should().Equals(3);
        }     

        private class ObjectA
        {
            public ObjectA()
            {
                PrivateProperty = "Private property";
            }

            public int PropertyOne { get; set; }
            public string PropertyTwo { get; set; }
            private string PrivateProperty { get; set; }
        }

        private class ObjectB
        {
            public int PropertyOne { get; set; }
            public string PropertyTwo { get; set; }
            public DateTime? PropertyThree { get; set; }
        }

    }
}
