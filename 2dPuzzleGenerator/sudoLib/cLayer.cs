﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPuzzleGenerator.sudoLib
{
    public class cLayer
    {
        cRow[] _rows; // each layer consists of an array of cRow objects

        public cLayer()
        {
            _rows = new cRow[g.PSIZE];
            for (int i = 0; i < g.PSIZE; i++)
                _rows[i] = new cRow();
        }

        public cRow[] Rows
        {
            get { return _rows; }
        }

        public void SetValue(int iRow, int iCol, int iValue)
        {
            _rows[iCol].Squares[iCol].Value = iValue;
        }

        public string LayerString()
        {
            StringBuilder retStr = new StringBuilder();

            for (int i = 0; i < g.PSIZE; i++)
            {
                retStr.Append(_rows[i].RowString() + Environment.NewLine);
                if ((i + 1)%3 == 0)
                {
                    retStr.Append(Environment.NewLine);
                }
            }

            return retStr.ToString();
        }

        public cRow this[int index]
        {
            get { return _rows[index]; }
            set { _rows[index] = value; }
        }
    }
}
