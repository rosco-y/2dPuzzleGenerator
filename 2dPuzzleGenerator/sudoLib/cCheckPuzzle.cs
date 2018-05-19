using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPuzzleGenerator.sudoLib
{
    /// <summary>
    /// cCheckPuzzle is a class for testing assumptions, and generally generally
    /// trying things out to satisfy curiosity without actually stomping around
    /// in the actual project.
    /// </summary>
    public class cCheckPuzzle
    {
        cLayer _lyr;

        public cCheckPuzzle(cLayer layer)
        {
            _lyr = layer;
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
            Console.WriteLine(_lyr.LayerString());
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
    }
}
