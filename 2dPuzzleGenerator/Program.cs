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
            BuildPuzzle(1);
        }

        

        static void BuildPuzzle(int seed)
        {
            try
            {
                g.Seed = seed;

                _lyr = new cLayer();

                createValidationLists();
                populatePuzzleValues();
                Console.WriteLine(g.Banner("Puzzle with Values"));
                Console.WriteLine(_lyr.LayerString());
                Console.WriteLine(g.Banner("Done."));
                Console.ReadLine();

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }
        
        

        static void createValidationLists()
        {
            try
            {
                cValidatation validate = new cValidatation(_lyr);
                //validate.CheckLinks();
            }
            catch (Exception x)
            {

                Console.WriteLine(x.Message);
                Console.ReadKey();
            }
        }

        static void populatePuzzleValues()
        {
            cPopulateSquares populate = new cPopulateSquares(_lyr);
        }
    }

}
