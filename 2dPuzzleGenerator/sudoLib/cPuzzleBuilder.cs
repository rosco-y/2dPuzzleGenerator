using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPuzzleGenerator.sudoLib
{
    public class cPuzzleBuilder
    {
        cLayer _layer;
        cCurPosition _pos;
        /// <summary>
        /// Build a Sudoku Puzzle on the passed layer, using the passed seed for the
        /// globally scoped Random class in g.cs.
        /// </summary>
        /// <param name="layer">
        /// The cLayer object which contains the cRows and cSquares which need to be populated with a valid Sudoku Puzzle.
        /// </param>
        /// <param name="seed">
        /// The seed to be used to create the puzzle.  This is used to create the static Random variable in the static g class,
        /// with the reasoning that any sudoku puzzle can be identified by it's seed #, and new puzzles can be generated using
        /// uniquie seed values.
        /// TODO:
        /// Write valid sudoku puzzles to a database, with the seed as the unique puzzle id.
        /// </param>
        public cPuzzleBuilder(cLayer layer, int seed)
        {
            _layer = layer;
            g.Seed = seed;
            _pos = new cCurPosition();
            clearValues();
            SetValues();
        }

        void clearValues()
        {
            for (int i = 0; i < g.PSIZE; i++)
            {
                for (int j = 0; j < g.PSIZE; j++)
                {
                    _layer[i][j].Value = 0;
                }
            }
        }

        /// <summary>
        /// use cSquare's TrySetValue() to set the square's value.
        /// if it succeeds (returns true), then we proceed to next square,
        /// else we backtrace to previous square and try again.
        int GetNext()
        {
            int returnValue = -1;
            


            return returnValue;
        }


        void SetValues()
        {
            bool done = false;
            while (!done)
            {
                if (_layer[_pos.Row][_pos.Col].TrySetValue())
                {
                    _pos++;
                    done = _pos.EndPosition;
                }
                else
                {
                    // no available values found, backstep
                    if (_pos.StartPosition)
                    {
                        throw new Exception("No Solution Found.");
                    }
                    else
                    {
                        _pos--;
                    }
                }
            }

        }


    }
}
