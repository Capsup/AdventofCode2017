using System;
using System.Linq;
using Utils;

namespace Day2
{
    public class Part1Solver : ISolver
    {
        public string PuzzleName
        {
            get
            {
                return "Day 2 - Part 1";
            }
        }

        public string Solve( string input )
        {
            return input.Split( new[] { Environment.NewLine }, StringSplitOptions.None ).Select( x => x.Split( new[] { '\t' } ).Select( y => int.Parse( y ) ).ToArray() ).ToArray()
                .Sum( x => x.OrderByDescending( y => y ).First() - x.OrderBy( y => y ).First() ).ToString();
        }
    }
}
