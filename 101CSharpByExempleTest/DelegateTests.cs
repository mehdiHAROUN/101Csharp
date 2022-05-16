using _101CSharpByExemple;
using NUnit.Framework;
using System;

namespace _101CSharpByExempleTest
{
    public class DelegateTests
    {

        public delegate string LogDelegate(string logMessage);
        public delegate int NextNumberDelegate(ref int number);
        private int? _number;

        [Test]
        public void TestDelegate()
        {
            LogDelegate log = Models.PrintMessage;

            Assert.AreEqual(log("Hello"), "Hello");
        }

        [Test]
        public void TestMultiDelegate()
        {
            NextNumberDelegate operation = Models.GetNext;
            operation += Models.GetMultiplied;
            operation += Models.GetNext;
            operation += Models.GetMultiplied;

            int number = 1;

            Assert.AreEqual(operation(ref number), 10);
        }



        [Test]
        public void TestEvent()
        {
            BookEventTest bookEventTest = new BookEventTest();
            bookEventTest.ReadBook += HandleEvent;

            Assert.IsNull(_number);

            bookEventTest.Read();
            Assert.AreEqual(_number, 1);
        }

        private void HandleEvent(object sender, EventArgs e)
        {
            if (!_number.HasValue)
            {
                _number = 1;
            }
            Console.WriteLine("HandleEvent");
        }

    }
    public static class Models
    {
        public static string PrintMessage(string message)
        {
            return message;
        }

        public static int GetNext(ref int number)
        {
            return ++number;
        }

        public static int GetMultiplied(ref int number)
        {
            number = number * 2;
            return number;
        }
    }

    public class BookEventTest
    {
        public delegate void ReadBookDelegate(object sender, EventArgs e);
        public event ReadBookDelegate ReadBook;

        public void Read()
        {
            Console.WriteLine("Read Book");
            if (ReadBook != null)
            {
                ReadBook(this, new EventArgs());
            }
        }
    }

}