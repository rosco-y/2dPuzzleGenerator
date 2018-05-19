using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPuzzleGenerator.sudoLib
{
    public class cPopulateSquares
    {
        cLayer _layer;

        public cPopulateSquares(cLayer layer)
        {
            _layer = layer;
            AddValues();
        }

        void AddValues()
        {
            for(int row = 0; row < g.PSIZE; row++)
            {
                for (int col = 0; col < g.PSIZE; col++)
                {
                    _layer[row][col].SetValue();
                }
            }
        }
        

    }
}
