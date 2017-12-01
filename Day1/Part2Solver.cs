using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Utils;

namespace Day1
{
    public class Part2Solver : ISolver
    {
        public string PuzzleName
        {
            get
            {
                return "Day 1 - Part 2";
            }
        }

        public string Solve( string input )
        {
            return input.ToCharArray()
                .Select( ( x, index ) => new
                {
                    Value = Convert.ToInt32( Char.GetNumericValue( x ) ),
                    Value2 = Convert.ToInt32( Char.GetNumericValue( input.ToCharArray().ElementAt( ( index + input.ToCharArray().Length / 2 ) % input.ToCharArray().Length ) ) )
                } ).Where( x => x.Value == x.Value2 ).Sum( x => x.Value ).ToString();
        }
    }
}
