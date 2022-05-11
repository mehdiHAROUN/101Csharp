using _101CSharpByExemple;
using NUnit.Framework;
using System;

namespace _101CSharpByExempleTest
{
    public class ReferencingObjectTests
    {
        [Test]
        public void DifferentObjects()
        {
            var car1 = GetCar("car1");
            var car2 = GetCar("car2");

            Assert.AreEqual("car1", car1.Price);
            Assert.AreEqual("car2", car2.Price);

        }

        [Test]
        public void PassingObjectReference()
        {
            var car1 = GetCar("car1");

            SetPrice(car1 , "car2");

            Assert.AreEqual("car2", car1.Price);
        }

        [Test]
        public void PassingObjectReference2()
        {
            var car1 = GetCar("car1");

            GetNewCar(car1, "car2");

            Assert.AreEqual("car1", car1.Price);
        }



        [Test]
        public void PassingValue()
        {
            int car1 = 5;
            SetThing(car1);
            Assert.AreEqual(5, car1);
        }

        [Test]
        public void StringBehaveLikeValueType()
        {
            string car1 = "5";
            SetThing(car1);
            Assert.AreEqual("5", car1);
        } 


        private Car GetCar(string price)
        {
            return new Car(price);
        }
        private void SetPrice(Car car1, string price)
        {
            car1.Price = price;
        }
        private void SetThing(int car)
        {
            car = 18;
        }

        private void SetThing(string car)
        {
            car = "10";
        }
        private void GetNewCar(Car car1, string name)
        {
            car1 = new Car(name);
        }

    }
}