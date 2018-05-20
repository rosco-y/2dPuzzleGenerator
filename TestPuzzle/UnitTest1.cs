using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2dPuzzleGenerator.sudoLib;

namespace TestPuzzle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCurPositionClass()
        {
            cCurPosition cur = new cCurPosition();
            while (!cur.EndPosition)
            {
                cur++;
            }
            Assert.AreEqual(g.PSIZE - 1, cur.Row, "Row is not at its End." );
            Assert.AreEqual(g.PSIZE - 1, cur.Col, "Col is not at its End." );

            while (!cur.StartPosition)
            {
                cur--;
            }
            Assert.AreEqual(0, cur.Row, "Row is not at its Beginning." );
            Assert.AreEqual(0, cur.Col, "Col is not at its Beginning." );
        }
    }
}
