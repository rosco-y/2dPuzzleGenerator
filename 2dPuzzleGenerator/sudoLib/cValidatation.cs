using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dPuzzleGenerator.sudoLib
{
    public class cValidatation
    {
        cLayer _layer;

        #region CONSTRUCTION / DESTRUCTION
        public cValidatation(cLayer layer)
        {
            _layer = layer;
            buildLinks();
        }
        #endregion CONSTRUCTION / DESTRUCTION

        #region CONSTRUCT LINKS
        void buildLinks()
        {
            for (int row = 0; row < g.PSIZE; row++)
            {
                for (int col = 0; col < g.PSIZE; col++)
                {
                    _layer[row][col].ValidationList.AddRange(buildRegionLinks(row, col));
                    _layer[row][col].ValidationList.AddRange(buildRowLinks(row));
                    _layer[row][col].ValidationList.AddRange(buildColumnLinks(col));
                }
            }
        }


        #region REGION, ROW, COLUMN

        List<cSquare> BuildRegionList(int row, int col)
        {
            List<cSquare> retList = new List<cSquare>();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    retList.Add(_layer[row + i][col + j]);
                }
            }
            return retList;
        }

        List<cSquare> buildRegionLinks(int row, int col)
        {

            eRegion thisRegion = GetRegion(row, col);
            List<cSquare> retList = new List<cSquare>();
            int iRow = -1;
            int iCol = -1;
            switch (thisRegion)
            {
                case eRegion.TopLeft:
                    iRow = iCol = 0;
                    break;
                case eRegion.TopCenter:
                    iRow = 0; iCol = 3;
                    break;
                case eRegion.TopRight:
                    iRow = 0; iCol = 6;
                    break;
                case eRegion.CenterLeft:
                    iRow = 3; iCol = 0;
                    break;
                case eRegion.Center:
                    iRow = 3; iCol = 3;
                    break;
                case eRegion.CenterRight:
                    iRow = 3; iCol = 6;
                    break;
                case eRegion.LowerLeft:
                    iRow = 6; iCol = 0;
                    break;
                case eRegion.LowerCenter:
                    iRow = 6; iCol = 3;
                    break;
                case eRegion.LowerRight:
                    iRow = 6; iCol = 6;
                    break;
                default:
                    throw new Exception("Invalid eRegion in cValidation.buildRegionLinks()");
            }
            retList.AddRange(BuildRegionList(iRow, iCol));
            return retList;
        }

        /// <summary>
        /// Add each cSquare in this row to the ValidationLinks[eLinks.Row] collection
        /// </summary>
        /// <param name="row">
        /// Add cSquares from this (int)row
        /// </param>
        /// <returns>
        /// First cSqare added to this collection, so that it can be added to 
        /// another link using a List<cSquare>.Add(buildRowLinks(row) type of syntax,
        /// thereby building one continuing list that can be traversed simply by 
        /// traversing each element of the ValidationList of a cSquare.
        /// </returns>
        List<cSquare> buildRowLinks(int row)
        {
            List<cSquare> retList = new List<cSquare>();

            for (int col = 0; col < g.PSIZE; col++)
                retList.Add(_layer[row][col]);

            return retList;
        }
       
        List<cSquare> buildColumnLinks(int col)
        {
            List<cSquare> retList = new List<cSquare>();

            for (int row = 0; row < g.PSIZE; row++)
                retList.Add(_layer[row][col]);

            return retList;
        }

        #endregion REGION, ROW, COLUMN

        #endregion CONSTRUCT LINKS

        #region TEST VALIDITY OF LINKS
        public void CheckLinks()
        {
            for(int row = 0; row < g.PSIZE; row++)
            {
                for (int col =0; col < g.PSIZE; col++)
                {
                    ClearValues();
                    traverseLinks(row, col);
                    Console.WriteLine(_layer.LayerString());
                    Console.ReadKey();
                }
            }
        }

        void ClearValues()
        {
            for (int i = 0; i < g.PSIZE; i++)
                for (int j = 0; j < g.PSIZE; j++)
                    _layer[i][j].Value = 0;
        }

        void traverseLinks(int row, int col)
        {
            List<cSquare> list = _layer[row][col].ValidationList;
            int sqrNum = 0;
            foreach (cSquare sqr in list)
            {
                if (sqr.Value == 0)
                    sqr.Value = ++sqrNum;
            }
        }

        #endregion VALIDITY OF LINKS

        #region REGIONS
        eTopBottom _topBottom;
        eLeftRight _leftRight;

        enum eLeftRight
        {
            NotSet,
            Left,
            Center,
            Right
        }

        enum eTopBottom
        {
            NotSet,
            Top,
            Center,
            Bottom
        }
        public enum eRegion
        {
            TopLeft,
            TopCenter,
            TopRight,
            CenterLeft,
            Center,
            CenterRight,
            LowerLeft,
            LowerCenter,
            LowerRight,
            NumRegions,
            NotSet
        }


        void SetLeftRight(int col)
        {
            if (col < 3)
            {
                _leftRight = eLeftRight.Left;
            }
            else
            {
                if (col < 6)
                {
                    _leftRight = eLeftRight.Center;
                }
                else
                    _leftRight = eLeftRight.Right;
            }

        }

        void setTopBottom(int row)
        {
            if (row < 3)
            {
                _topBottom = eTopBottom.Top;
            }
            else
            {
                if (row < 6)
                {
                    _topBottom = eTopBottom.Center;
                }
                else
                    _topBottom = eTopBottom.Bottom;
            }
        }


        eRegion GetRegion(int row, int col)
        {
            eRegion eReturn = eRegion.NotSet;

            _leftRight = eLeftRight.NotSet;
            _topBottom = eTopBottom.NotSet;
            SetLeftRight(col);
            setTopBottom(row);
            switch (_leftRight)
            {


                case eLeftRight.Left:
                    ///////////////////////
                    // LEFT-RIGHT = LEFT //
                    ///////////////////////
                    switch (_topBottom)
                    {
                        case eTopBottom.Top:
                            eReturn = eRegion.TopLeft;
                            break;
                        case eTopBottom.Center:
                            eReturn = eRegion.CenterLeft;
                            break;
                        case eTopBottom.Bottom:
                            eReturn = eRegion.LowerLeft;
                            break;
                        default:
                            throw new Exception("Invalid eTopBottom value in cValidationLists.GetRegion()");
                    }
                    break;




                case eLeftRight.Center:
                    /////////////////////////
                    // LEFT-RIGHT = CENTER //
                    /////////////////////////
                    switch (_topBottom)
                    {
                        case eTopBottom.Top:
                            eReturn = eRegion.TopCenter;
                            break;
                        case eTopBottom.Center:
                            eReturn = eRegion.Center;
                            break;
                        case eTopBottom.Bottom:
                            eReturn = eRegion.LowerCenter;
                            break;
                        default:
                            throw new Exception("Invalid eTopBottom value in cValidationLists.GetRegion()");
                    }

                    break;
                case eLeftRight.Right:
                    switch (_topBottom)
                    {
                        ////////////////////////
                        // LEFT-RIGHT = RIGHT //
                        ////////////////////////
                        case eTopBottom.Top:
                            eReturn = eRegion.TopRight;
                            break;
                        case eTopBottom.Center:
                            eReturn = eRegion.CenterRight;
                            break;
                        case eTopBottom.Bottom:
                            eReturn = eRegion.LowerRight;
                            break;
                        default:
                            throw new Exception("Invalid eTopBottom value in cValidationLists.GetRegion()");
                    }
                    break;
                default:
                    throw new Exception("Invalid LeftRight enum value in cValiationLists.GetRegion()");
            } // END SWITCH
            return eReturn;

        }
        // END GetRegion
        #endregion REGIONS
    }
}
