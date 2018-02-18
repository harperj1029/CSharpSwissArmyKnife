﻿using System;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Helpers
{
    [TestClass]
    public class SerializationHelperTests
    {
        [TestMethod]
        public void ConvertFromByteArray_PassSimpleByteArray_GetExpectedString()
        {
            var byteArray = GetSimpleByteArray();
            var actual = SerializationHelper.ConvertFromByteArray(byteArray);
            var expectedResult = "This is simple string";

            Assert.AreEqual(expectedResult, actual);
        }

        [TestMethod]
        public void ConvertFromByteArray_PassSimpleByteArrayWithMultipleLines_GetExpectedString()
        {
            var byteArray = GetSimpleByteArrayWithMultipleLines();
            var actual = SerializationHelper.ConvertFromByteArray(byteArray);
            var expectedResult = "This is an example of what a test string might look like.\r\n" +
                "It has a couple lines\r\nSo it is a bit more complex than the simple version";

            Assert.AreEqual(expectedResult, actual);
        }

        [TestMethod]
        public void ConvertFromByteArray_PassSimpleByteArrayWithNonAlphaNumericCharacters_GetExpectedString()
        {
            var byteArray = GetSimpleByteArrayWithSillyCharacters();
            var array = SerializationHelper.ConvertFromByteArray(byteArray);
            var expectedResult = "This is an example of what a test string might look like.\r\n" +
                "Let's put some characters that might make this fail?" +
                "\r\n\"';:!@#$%^&*()-_=+[]\\{}|,./<>`~\r\n0123456789";

            Assert.AreEqual(expectedResult, array);
        }


        [TestMethod]
        public void ConvertToByteArray_PassSimpleString_GetExpectedByteArray()
        {
            var str = "This is simple string";
            var actual = SerializationHelper.ConvertToByteArray(str);
            var expectedResult = GetSimpleByteArray();

            Assert.AreEqual(expectedResult.Length, actual.Length);
            Assert.AreEqual(expectedResult[5], actual[5]);
            Assert.AreEqual(expectedResult[14], actual[14]);
        }

        [TestMethod]
        public void ConvertToByteArray_PassSimpleStringWithMultipleLines_GetExpectedByteArray()
        {
            var str = "This is an example of what a test string might look like.\r\n" +
                "It has a couple lines\r\nSo it is a bit more complex than the simple version";
            var actual = SerializationHelper.ConvertToByteArray(str);
            var expectedResult = GetSimpleByteArrayWithMultipleLines();

            Assert.AreEqual(expectedResult.Length, actual.Length);
            Assert.AreEqual(expectedResult[5], actual[5]);
            Assert.AreEqual(expectedResult[14], actual[14]);
            Assert.AreEqual(expectedResult[33], actual[33]);
        }

        [TestMethod]
        public void ConvertToByteArray_PassSimpleStringWithNonAlphaNumericCharacters_GetExpectedByteArray()
        {
            var str = "This is an example of what a test string might look like.\r\n" +
                "Let's put some characters that might make this fail?" +
                "\r\n\"';:!@#$%^&*()-_=+[]\\{}|,./<>`~\r\n0123456789";
            var actual = SerializationHelper.ConvertToByteArray(str);
            var expectedResult = GetSimpleByteArrayWithSillyCharacters();

            Assert.AreEqual(expectedResult.Length, actual.Length);
            Assert.AreEqual(expectedResult[5], actual[5]);
            Assert.AreEqual(expectedResult[14], actual[14]);
            Assert.AreEqual(expectedResult[39], actual[39]);
            Assert.AreEqual(expectedResult[45], actual[45]);
        }

        private byte[] GetSimpleByteArray()
        {
            return new byte[]
            {
                0x54, 0x68, 0x69, 0x73, 0x20, 0x69, 0x73, 0x20, 0x73, 0x69, 0x6D, 0x70, 0x6C, 0x65, 0x20,
                0x73, 0x74, 0x72, 0x69, 0x6E, 0x67
            };
        }

        private byte[] GetSimpleByteArrayWithMultipleLines()
        {
            return new byte[]
            {
                0x54, 0x68, 0x69, 0x73, 0x20, 0x69, 0x73, 0x20, 0x61, 0x6E, 0x20, 0x65, 0x78, 0x61, 0x6D,
                0x70, 0x6C, 0x65, 0x20, 0x6F, 0x66, 0x20, 0x77, 0x68, 0x61, 0x74, 0x20, 0x61, 0x20, 0x74,
                0x65, 0x73, 0x74, 0x20, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x20, 0x6D, 0x69, 0x67, 0x68,
                0x74, 0x20, 0x6C, 0x6F, 0x6F, 0x6B, 0x20, 0x6C, 0x69, 0x6B, 0x65, 0x2E, 0x0D, 0x0A, 0x49,
                0x74, 0x20, 0x68, 0x61, 0x73, 0x20, 0x61, 0x20, 0x63, 0x6F, 0x75, 0x70, 0x6C, 0x65, 0x20,
                0x6C, 0x69, 0x6E, 0x65, 0x73, 0x0D, 0x0A, 0x53, 0x6F, 0x20, 0x69, 0x74, 0x20, 0x69, 0x73,
                0x20, 0x61, 0x20, 0x62, 0x69, 0x74, 0x20, 0x6D, 0x6F, 0x72, 0x65, 0x20, 0x63, 0x6F, 0x6D,
                0x70, 0x6C, 0x65, 0x78, 0x20, 0x74, 0x68, 0x61, 0x6E, 0x20, 0x74, 0x68, 0x65, 0x20, 0x73,
                0x69, 0x6D, 0x70, 0x6C, 0x65, 0x20, 0x76, 0x65, 0x72, 0x73, 0x69, 0x6F, 0x6E
            };
        }

        private byte[] GetSimpleByteArrayWithSillyCharacters()
        {
            return new byte[]
            {
                0x54, 0x68, 0x69, 0x73, 0x20, 0x69, 0x73, 0x20, 0x61, 0x6E, 0x20, 0x65, 0x78, 0x61, 0x6D,
                0x70, 0x6C, 0x65, 0x20, 0x6F, 0x66, 0x20, 0x77, 0x68, 0x61, 0x74, 0x20, 0x61, 0x20, 0x74,
                0x65, 0x73, 0x74, 0x20, 0x73, 0x74, 0x72, 0x69, 0x6E, 0x67, 0x20, 0x6D, 0x69, 0x67, 0x68,
                0x74, 0x20, 0x6C, 0x6F, 0x6F, 0x6B, 0x20, 0x6C, 0x69, 0x6B, 0x65, 0x2E, 0x0D, 0x0A, 0x4C,
                0x65, 0x74, 0x27, 0x73, 0x20, 0x70, 0x75, 0x74, 0x20, 0x73, 0x6F, 0x6D, 0x65, 0x20, 0x63,
                0x68, 0x61, 0x72, 0x61, 0x63, 0x74, 0x65, 0x72, 0x73, 0x20, 0x74, 0x68, 0x61, 0x74, 0x20,
                0x6D, 0x69, 0x67, 0x68, 0x74, 0x20, 0x6D, 0x61, 0x6B, 0x65, 0x20, 0x74, 0x68, 0x69, 0x73,
                0x20, 0x66, 0x61, 0x69, 0x6C, 0x3F, 0x0D, 0x0A, 0x22, 0x27, 0x3B, 0x3A, 0x21, 0x40, 0x23,
                0x24, 0x25, 0x5E, 0x26, 0x2A, 0x28, 0x29, 0x2D, 0x5F, 0x3D, 0x2B, 0x5B, 0x5D, 0x5C, 0x7B,
                0x7D, 0x7C, 0x2C, 0x2E, 0x2F, 0x3C, 0x3E, 0x60, 0x7E, 0x0D, 0x0A, 0x30, 0x31, 0x32, 0x33,
                0x34, 0x35, 0x36, 0x37, 0x38, 0x39
            };
        }
    }
}