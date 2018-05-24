using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPuzzleGenerator.sudoLib
{
    public class cSquare
    {
        int _rowID;
        int _colID;
        int _value;
        bool[] _available;
        List<cSquare> _validationList;

        public cSquare(int row, int col)
        {
            /// rowID and colID are stored 0 based, but IDs are reported
            /// (ID + 1) * a multiplicand so they can be combined with the
            /// square's value and be easily reprented in the following fashion:
            /// Row * 100 + Col * 10 + Value
            /// (rowID* 100 + colID * 10 + value.
            /// Examples:
            /// 111 = Row=1, Col=1, Value=1
            /// 327 = Row=3, Col=2, Value=7
            /// 456 = Row=4, Col=5, Value=5
            /// 999 = Row=9, Col=9, Value=9.
            _rowID = row; // rowID has already been adjusted in the cRow Constructor.

            _colID = (col + 1) * 10; // Column IDs are 10 - 90.

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
                int availableCount = AvailableCount();

                if (availableCount >= 2)   // 2 or more.
                {
                    bool foundAvailableValue = false;
                    while (!foundAvailableValue)
                    {
                        tryValue = g.Next;
                        foundAvailableValue = _available[tryValue];
                    }
                }
                else // if 1 more value available
                {
                    if (availableCount > 0)
                    {
                        for (int i = 1; i < g.PSIZE; i++)
                            if (_available[i])
                            {
                                tryValue = i;
                                break;
                            }
                    }
                    else
                    {
                        tryValue = -1;
                        doneTrying = true;
                        success = false;
                    }

                }
                if (tryValue > 0) // value was found, and now needs to be validated using the rules of Sudoku.
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


                } // tryValue > 0, tryValue was set, and needed to be validated.

            } // while (!doneTrying)
            return success;

        } // public bool TrySetValue()

        public int RowID
        {
            get { return _rowID; }
        }

        public int ColID
        {
            get { return _colID; }
        }

        /// <summary>
        /// SquareID: row and colID combined into a single ID.
        /// ex: 230 = Row 2 (rowID/100), Col 3 (colID/10)
        /// </summary>
        public int SquareID
        {
            get { return _rowID + _colID; }
        }

        public override string ToString()
        {
            // return $"({_rowID/100}, {_colID/10}) {_value}"; // rowID + colID + value as string
            return $"{_value}"; // value as a string.
        }

    } // public class cSquare
}
