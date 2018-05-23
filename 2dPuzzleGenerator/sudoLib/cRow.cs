using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPuzzleGenerator.sudoLib
{
    public class cRow
    {
        // each row consists of an array of cSquare objects.
        int _rowID;
        cSquare[] _squares;
        const string _smallSpace = "  ";
        const string _largeSpace = "     ";

        public cRow(int row)
        {
            _rowID = (row + 1) * 100; // RowIDs are 100 - 900
            _squares = new cSquare[g.PSIZE];

            for (int i = 0; i < g.PSIZE; i++)
            {
                /// square IDs are one-based.
                /// Column IDs are passed on zero-based, and adjusted in the
                /// cSquare constructor.
                _squares[i] = new cSquare(_rowID, i);
            }            
        }

        public cSquare this[int index]
        {
            get
            {
                return _squares[index];
            }
            set
            {
                _squares[index] = value;
            }
        }

        public cSquare[] Squares
        {
            get { return _squares; }
            set { _squares = value; }
        }

        public override string ToString()
        {
            string retString = string.Empty;

            for (int i = 0; i < g.PSIZE; i++)
            {
                retString += _squares[i];
                if ((i + 1) % 3 == 0)
                    retString += _largeSpace;
                else
                    retString += _smallSpace;
            }

            return retString;
        }

        public String RowString()
        {
            StringBuilder retStr = new StringBuilder();
            for (int i = 0; i < g.PSIZE; i++)
            {
                retStr.Append(_squares[i].Value.ToString());
                if ((i + 1) % 3 == 0)
                    retStr.Append(_largeSpace);
                else
                    retStr.Append(_smallSpace);
            }
            return retStr.ToString();
        }

    }
}
