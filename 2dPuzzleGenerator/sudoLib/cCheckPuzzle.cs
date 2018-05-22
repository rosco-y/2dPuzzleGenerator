﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPuzzleGenerator.sudoLib
{
    ///
    /// UTILITY CLASS FOR ASSISTING THE BUILDING OF THE SUDDOKU PUZZLE SOFTWARE.
    /// 
    

    ///////////////////////////////////////////////////////////////////////////////
    /// <summary>         
    /// cCheckPuzzle is a class for testing assumptions, and generally generally //
    /// trying things out to satisfy curiosity without actually stomping around  //
    /// in the actual project.                                                   //
    /// </summary>                                                               //
    ///////////////////////////////////////////////////////////////////////////////
    public class cCheckPuzzle
    {

        cLayer _lyr;
        bool _success;
        public cCheckPuzzle(cLayer layer)
        {
            _lyr = layer;
            _success = false; // unless valid puzzle is generated.
        }

        ///////////////////////////////////////////////////////////////////
        /// investigate cLayer, So as to develop a better understanding  //
        /// of what it means to access cLayer[0][0] (for example).       //
        ///////////////////////////////////////////////////////////////////
        public void CheckAccessOrder()
        {
            /// test to see of _lry[0][0] is upper-left hand corner
            g.Banner("Numbers should be increasing from top-left to lower-right.");
            int visit = 0;
            for (int i = 0; i < g.PSIZE; i++)
            {
                for (int j = 0; j < g.PSIZE; j++)
                {
                    _lyr[i][j].Value = ++visit;
                }
            }
            Console.WriteLine(_lyr);
            g.Pause();
        }

        public void CenterRegionCheck()
        {
            g.Banner("Print numbers in Center Region");
            for (int i = 3; i < 6; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    Console.Write($"{_lyr[i][j].Value}  ");
                }
                Console.Write(Environment.NewLine);
            }
            g.Pause();
        }

        public void CheckDecrementCurPostionObject()
        {
            cCurPosition pos = new cCurPosition(8,8);
            int i, j;

            Console.WriteLine($"{pos.Row}, {pos.Col}");

            while (!pos.StartPosition)
            {
                pos--;
                Console.WriteLine($"{pos.Row}, {pos.Col}");
            }
            g.Banner($"Success! pos is now at {pos.Row}, {pos.Col}");
        }

        public void CheckIncrementCurPostionObject()
        {
            cCurPosition pos = new cCurPosition();

            Console.WriteLine($"{pos.Row}, {pos.Col}");

            while (!pos.EndPosition)
            {
                pos++;
                Console.WriteLine($"{pos.Row}, {pos.Col}");
            }
            g.Banner($"Success! pos is now at {pos.Row}, {pos.Col}");
        }


        public bool Success
        {
            get { return _success; }
        }
    }
}
