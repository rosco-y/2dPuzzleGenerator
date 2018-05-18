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
        cSquare[] _squares;
        const string _smallSpace = "  ";
        const string _largeSpace = "     ";

        public cRow()
        {
            _squares = new cSquare[g.PSIZE];

            for (int i = 0; i < g.PSIZE; i++)
            {
                _squares[i] = new cSquare();
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
