using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2dPuzzleGenerator.sudoLib;

namespace _2dPuzzleGenerator
{
    class Program
    {
        static cLayer _lyr;
        
        static void Main(string[] args)
        {
            
            BuildPuzzle();
        }



        static void BuildPuzzle()
        {
            try
            {
                g.Seed = 1;
                _lyr = new cLayer();

                CreateValidationLists();

                cCheckPuzzle chk = new cCheckPuzzle(_lyr);
                chk.CheckIncrementCurPostionObject();
                g.Pause();
                chk.CheckDecrementCurPostionObject();
                g.Pause();
                //chk.CheckAccessOrder();
                //chk.CenterRegionCheck();
                

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }

        static void CreateValidationLists()
        {
            try
            {
                cValidatation validate = new cValidatation(_lyr);
                //validate.CheckLinks();
            }
            catch (Exception x)
            {

                Console.WriteLine(x.Message);
                g.Pause();
            }
        }

       

    }

}