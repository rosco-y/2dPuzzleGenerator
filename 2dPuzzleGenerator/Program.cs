using System;
using System.IO;
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
        static int _seed;
        
        static void Main(string[] args)
        {
            try
            {
                _seed = 1;
                if (args.Length > 0)
                    _seed = int.Parse(args[0]);

                BuildPuzzle(_seed);
            }
            catch (Exception x)
            {
                g.Banner($"{x.Message}");
                PrintFile();
                Console.WriteLine(_lyr);
            }
        }



        static void BuildPuzzle(int seed)
        {
            try
            {
                Console.Clear();
                g.Banner($"Creating Puzzle with a Seed Value of {seed}.");
                _lyr = new cLayer();
                CreateValidationLists();
                cPuzzleBuilder bldr = new cPuzzleBuilder(_lyr, 1);
                string filename = $"Puzzle{seed}.txt";

                //File.WriteAllText(filename, _lyr);
                Console.WriteLine(_lyr);
                g.Pause();

            }
            catch (Exception x)
            {
                throw x;
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

                throw x;
                g.Pause();
            }
        }

        static void PrintFile()
        {
            string filename = $"Puzzle{_seed}.txt";
            File.WriteAllText(filename, _lyr.ToString());
        }

       

    } // public class Program

}