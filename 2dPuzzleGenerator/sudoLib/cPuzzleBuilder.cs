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
        int _curRow, _curCol;
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
        }


    }
}
