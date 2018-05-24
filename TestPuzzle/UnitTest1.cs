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


        /// <summary>
        /// TestLinkSums.
        /// Loop through all of the Squares in each Square's Validation List, giving them
        /// a value starting at 1, and each one incrementing each value by 1.  Then, when
        /// finished assigning values to each member of the validation chain, sum them all
        /// and verify that the total = 231 (sum of 1+2+3+4+5+6+7+8+9+10+11+12+13+14+15+16+17+18+19+20+21)
        /// (21 total squares: 9 squares in the region, + 6 vertical squares + 6 horizontal squares
        ///  = 9 + 12 = 21).  6 horizontoal and 6 vertical because 3 vertical exist in the 3x3
        ///  region and 3 horizontal are found in the same 3x3 region.
        /// </summary>
        [TestMethod]
        public void TestLinkSums()
        {
            cLayer layer = new cLayer();
            cValidatation valid = new cValidatation(layer); // creates links

            bool success = true;
            foreach (cRow row in layer.Rows)
            {
                foreach(cSquare sqr in row.Squares)
                {
                    resetLayer(layer);
                    success &= CreateValuesAndCheckSumOfValidationList(sqr);
                }
            }

            Assert.AreEqual(true, success, "TestLinkSums test failed.");
            layer = null;
        }

        [TestMethod]
        public void TestLinkLengths()
        {
            cLayer layer = new cLayer();
            cValidatation valid = new cValidatation(layer); // creates links

            Assert.AreEqual(true, CheckValidationLinkListLengths(layer), "Validation Linked Lists Lengths Invalid");
            layer = null;
        }

        const int VALIDLENGTH = 21;
        bool CheckValidationLinkListLengths(cLayer layer)
        {
            bool success = true;
            foreach (cRow row in layer.Rows)
            {
                foreach (cSquare sqr in row.Squares)
                {
                    success &= (sqr.ValidationList.Count == VALIDLENGTH);
                }
            }
            return success;
        }

        // magic value noted by Sum(1...21)
        const int MAGICSUM = 231;
        bool CreateValuesAndCheckSumOfValidationList(cSquare sqr)
        {

            int addNum = 0;
            foreach (cSquare vSqare in sqr.ValidationList)
            {
                vSqare.Value = ++addNum;
            }

            int checkSum = 0;
            foreach (cSquare vSqare in sqr.ValidationList)
            {
                checkSum += vSqare.Value;
            }

            return checkSum == MAGICSUM;
        }

        void resetLayer(cLayer lyr)
        {
            for (int row = 0; row < g.PSIZE -1; row++)
            {
                for (int col = 0; col < g.PSIZE - 1; col++)
                    lyr[row][col].Value = 0;
            }
        }

    }

    
}
