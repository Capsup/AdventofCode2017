using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Utils;
using System.Text.RegularExpressions;

namespace Day9
{
    public class Part2Solver : ISolver
    {
        public string PuzzleName
        {
            get
            {
                return "Day 9 - Part 2";
            }
        }

        public string Solve( string input )
        {
            return Regex.Matches( Regex.Replace( input, "!.", "" ), "<.*?>" ).Sum( x => x.Length - 2 ).ToString();
        }
    }
}
