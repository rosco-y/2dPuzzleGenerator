using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPuzzleGenerator.sudoLib
{
    public class cNextGenerator
    {
        int[] _available;
        int _availableCount;
        public cNextGenerator()
        {
            _availableCount = g.PSIZE + 1;
            _available = new int[g.PSIZE];
            for (int i = 0; i < g.PSIZE; i++)
                _available[i] = i + 1;

        }


        /// <summary>
        /// Randomly get the next available value for this cell.
        /// </summary>
        /// <returns>
        /// The available Value, if found.  Else -1
        /// </returns>
        public int Next()
        {
            int iNext = -1;
            if (_availableCount > 0)
            {
                while (iNext == -1 && _availableCount > 1)
                {
                    iNext = g.Next; // global (shared) Random Variable with a single seed.
                }
                if (iNext == -1) // must only have 1 available
                {
                    int i = 0;
                    while (_available[i] == -1)
                        i++;
                    iNext = _available[i]; // last available.
                }
                _available[iNext - 1] = -1; // No longer available.
            }

            return iNext;
        }
    }

}
}
