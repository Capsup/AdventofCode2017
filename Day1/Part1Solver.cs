using System;
using System.Linq;
using Utils;

namespace Day1
{
    public class Part1Solver : ISolver
    {
        public string PuzzleName
        {
            get
            {
                return "Day 1 - Part 1";
            }
        }

        public string Solve( string input )
        {
            return input.ToCharArray()
                .Select( x => Convert.ToInt32( Char.GetNumericValue( x ) ) )
                .Aggregate( new
                {
                    Sum = 0,
                    LastDigit = Convert.ToInt32( Char.GetNumericValue( input.Reverse().First() ) )
                }, ( state, next ) =>
                new
                {
                    Sum = state.LastDigit == next ? state.Sum + next : state.Sum,
                    LastDigit = next
                } ).Sum.ToString();
        }
    }
}
