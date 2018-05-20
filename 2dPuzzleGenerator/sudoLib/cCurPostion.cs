using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPuzzleGenerator.sudoLib
{
    public class cCurPosition
    {
        int _curRow;
        int _curCol;
        bool _success = false;
        public cCurPosition()
        {
            _curRow = _curCol = 0;
        }

        public cCurPosition(int row, int col)
        {
            _curRow = row;
            _curCol = col;
        }

        public static cCurPosition  operator++ (cCurPosition a)
        {
            if (a._curCol >= g.PSIZE -1)
            {
                if (a._curRow < (g.PSIZE - 1))
                {
                    a._curCol = 0;
                    a._curRow++;                    
                }
            }
            else
            {
                a._curCol++;
                if ((a._curRow == (g.PSIZE -1)) && (a._curCol == (g.PSIZE - 1)))
                {
                    a._success = true;
                }
            }
            return a;
        }
        
        public static cCurPosition operator--(cCurPosition a)
        {
            // somewhere within a row, move one to the left.
            if(a._curCol > 0)
            {
                a._curCol--;
            }
            else
            {
                /// at beginning of the row, test to see if there are preceeding rows
                if (a._curRow > 0)
                {
                    /// move to end of previous row.
                    a._curRow--;
                    a._curCol = g.PSIZE - 1;
                }

            }
            
            return a;
        }

        public int Row
        {
            get { return _curRow; }
        }

        public int Col
        {
            get { return _curCol; }
        }

        public bool Success
        {
            get { return _success; }
        }

        public bool StartPosition
        {
            get { return ((this._curCol == 0) && (this._curRow == 0)); }
        }

        public bool EndPosition
        {
            get { return ((this._curRow == g.PSIZE - 1) && (this._curCol == g.PSIZE - 1)); }
        }


    }
}
