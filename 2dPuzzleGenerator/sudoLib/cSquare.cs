using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPuzzleGenerator.sudoLib
{
    public class cSquare
    {
        int _value;
        cNextGenerator _nextGenerator;
        List<cSquare> _validationList;

        public cSquare()
        {
            _value = 0;
            _available = new bool[g.PSIZE + 1]; // so values 1 to 9 can be used as indexes.
            for (int i = 1; i < g.PSIZE + 1; i++)
                _available[i] = true;

            _validationList = new List<cSquare>();
        }

        public int Value
        {
            set { _value = value; }
            get { return _value; }
        }
        
        public List<cSquare> ValidationList
        {
            get { return _validationList; }
            set { _validationList = value; }
        }

        public bool[] Available
        {
            get { return _available; }
            set { _available = value; }
        }

    }
}
