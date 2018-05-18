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
                validate.CheckLinks();
            }
            catch (Exception x)
            {

                Console.WriteLine(x.Message);
                Console.ReadKey();
            }
        }

    }

}
