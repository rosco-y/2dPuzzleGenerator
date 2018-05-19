using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPuzzleGenerator.sudoLib
{
    public static class g
    {
        public const int PSIZE = 9;
        static Random _rnd;
        static int _seed = -1;

        public static int Seed
        {
            set
            {
                _seed = value;
                /// always create a new Random object to ensure that the
                /// new seed value is used. (I don't know if there is a way
                /// to change a Random seed of an existing Random Object.
                _rnd = null;
                _rnd = new Random(_seed);
            }

            get { return _seed; }
        }

        /// <summary>
        /// Single Random Class to generate values for a puzzle, to ensure puzzle shape is set
        /// by the seed value (to be verified, but I'm hoping this is the case.)
        /// TODO: Check that a single seed guarantees a single solution.
        /// </summary>
        public static int Next
        {
            get
            {
                int iVal = -1;
                try
                {
                    
                    if (_seed < 0)
                        throw new Exception("g.Seed not set.");

                    if (_rnd == null)
                    {
                        iVal = -1;
                        throw new Exception("g._rnd (Random variable) is null");
                    }
                    else
                        iVal =  _rnd.Next(1, PSIZE + 1);
                }
                catch (Exception x)
                {
                    throw x;
                }

                return iVal;
            }
        }

        public static string Banner(string msg)
        {
            string retString = string.Empty;
            retString = new string('=', 5);
            retString += " " + msg + " ";
            retString += new string('=', 5) + Environment.NewLine;
            return retString;
        }

    }
}
