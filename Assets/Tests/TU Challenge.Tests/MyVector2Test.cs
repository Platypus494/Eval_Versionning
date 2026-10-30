using NUnit.Framework;
using System;
using System.Collections;
using TU_Challenge;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.TestTools;

namespace TU_Challenge.Tests
{
    public class MyVector2Test
    {
        // A Test behaves as an ordinary method
        [Test]
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void MyVector2BreakTest(int x, int y)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                new MyVector2(x, y);
            });

        }


        [Test]
        [TestCase(1, 1)]
        [TestCase(1, 3.5f)]
        [TestCase(2.3773f, 12.1987f)]
        public void MyVector2SimpleTest(float x, float y)
        {
            MyVector2 vector = new MyVector2(x, y);
            Assert.IsTrue(x.Equals(vector.X) && y.Equals(vector.Y));
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(1, 3.5f)]
        [TestCase(2.3773f, 12.1987f)]
        public void NormalizeSimpleTest(float x, float y)
        {
            MyVector2 vector = new MyVector2(x, y);
            vector.Normalize();
            Assert.IsTrue(vector.X<1 && vector.Y<1);
        }
    }
}
