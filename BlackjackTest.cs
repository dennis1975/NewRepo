using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blackjack;

namespace UnitTestBlackjack
{
    [TestClass]
    public class BlackjackTest
    {
        [TestMethod]
        public void ViewResultsTest()
        {
            //-- Arrange
            Program.playerTotal = 21;
            Program.computerTotal = 16;
            Program.ViewResults(true);

            string expected = "Congrats! You won!";

            //-- Act
            string actual = Program.strTest;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
