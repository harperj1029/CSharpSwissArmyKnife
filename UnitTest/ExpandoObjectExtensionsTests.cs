using System;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using CSharpUtilities.Extensions;

namespace UnitTest
{
    [TestClass]
    public class ExpandoObjectExtensionsTests
    {
        [TestMethod]
        public void ShouldMergeAnonymousObjects()
        {
            // Arrange
            var foo = new { Foo = "Foo" };
            var bar = new { Bar = "Bar" };
            var baz = new { Baz = "Baz" };

            // Act
            dynamic result = new ExpandoObject().AddProperties(foo).AddProperties(bar).AddProperties(baz);

            // Assert
            ((string)result.Foo).ShouldEqual("Foo");
            ((string)result.Bar).ShouldEqual("Bar");
            ((string)result.Baz).ShouldEqual("Baz");
        }

        [TestMethod]
        public void Should_AddPublicProperties_LastOneWithValueWins()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var a = new ObjectA { PropertyOne = 1, PropertyTwo = "two" };
            var b = new ObjectB { PropertyOne = 2, PropertyTwo = null, PropertyThree = now };

            // Act
            dynamic c = new ExpandoObject().AddProperties(a).AddProperties(b);

            // Assert
            ((int)c.PropertyOne).ShouldEqual(2);
            ((string)c.PropertyTwo).ShouldEqual("two");
            ((DateTime?)c.PropertyThree).ShouldEqual(now);
            var cAsDictionary = c as IDictionary<string, object>;
            cAsDictionary.Count.ShouldEqual(3);
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
