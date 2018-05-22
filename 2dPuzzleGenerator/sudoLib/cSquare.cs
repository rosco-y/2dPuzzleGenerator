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
        bool[] _available;
        List<cSquare> _validationList;

        public cSquare()
        {
            _value = 0;
            _available = new bool[g.PSIZE + 1]; // so values 1 to 9 can be used as indexes.
            _available[0] = false;
            for (int i = 1; i <= g.PSIZE; i++) // 1 - 9
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
            set { _available = value; }
            get { return _available; }
        }

        int AvailableCount()
        {
            int retValue = 0;
            for (int i = 1; i <= g.PSIZE; i++) // 1 - 9
                if (_available[i])
                    retValue++;
            return retValue;
        }

        /// <summary>
        /// Get a value using g.Next.  If available value is found,
        /// set it and set the avialble member false, so it isn't re-used.
        /// If there are no available values in the available list, then
        /// reset the list, as we will be dropping back to the squares 
        /// preceeding location in the puzzle (square just to the "left" of
        /// this currrent square.) to try a new value there, in hopes that this
        /// change will enable a value to work after moving back to this square.
        /// </summary>
        /// <returns>
        /// True if a value was found, otherwise false.
        /// False can only be returned if their are no more values in the
        /// available list.
        /// </returns>
        public bool TrySetValue()
        {
            /// No need to check if values exist in the available list.  
            /// Whenever it get's emptied, it is refilled because we then
            /// backtrace to the preceeding square.
            bool success = false;
            int tryValue = -1;
            bool doneTrying = false;
            while (!doneTrying)
            {
                tryValue = g.Next;
                if (_available[tryValue]) // _avialable is initialized [1] - [9] = true, (not [0] - [8]).
                {
                    //////////////////////////////////////////////////////////////////////////////////////
                    /// Fine, the value is available, but now we need to check it's region, up/down and //
                    /// across neighbors to ensure that it doesn't violate the rules of sudoku.         //
                    //////////////////////////////////////////////////////////////////////////////////////
                    bool inviolates = false;
                    foreach (cSquare tstSqr in _validationList)
                    {
                        if (tstSqr.Value == tryValue)
                        {
                            _available[tryValue] = false; // it violates sudoku rules, after all...
                            inviolates = true;
                            break;
                        }
                    }
                    if (inviolates)
                    {
                        doneTrying = success = false;
                    }
                    else
                    {
                        /// Actaully, since we are no longer looking for a value for this square, it seems as
                        /// though it might not be important to set the _available[usedValue] = false, but it
                        /// feels somehow "safer".
                        _available[tryValue] = false;


                        /////////////////////////////////////////////////////////////
                        /// DON'T FORGET TO SET THE VALUE--THAT'S WHY WE'RE HERE!!///
                        /////////////////////////////////////////////////////////////
                        _value = tryValue;
                        doneTrying = success = true;
                    }

                } // else tried value wasn't available
                else
                {
                    // value tried wasn't available.
                    switch (AvailableCount())
                    {
                        case 0:
                            /// No more values available to try on this square, reset available and return false.
                            _available[0] = false;
                            for (int i = 1; i < g.PSIZE + 1; i++)
                                _available[i] = true;
                            success = false;
                            doneTrying = true;
                            break;
                        case 1:
                            // find last remaining value and use it.
                            for (int i = 1; i <= g.PSIZE; i++)
                                if (_available[i])
                                {
                                    tryValue = i;
                                    break;
                                }
                            break;
                        default:
                            tryValue = g.Next;
                            break;
                    }
                }

            } // while (!doneTrying)
            return success;

        } // public bool TrySetValue()

    } // public class cSquare
}
