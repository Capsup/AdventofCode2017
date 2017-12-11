using System;
using System.Linq;
using System.Text.RegularExpressions;
using Utils;

namespace Day9
{
    public class Part1Solver : ISolver
    {
        public string PuzzleName
        {
            get
            {
                return "Day 9 - Part 1";
            }
        }

        public string Solve( string input )
        {
            return Regex.Replace( Regex.Replace( input, "!.", "" ), "<.*?>", "" ).ToCharArray().Aggregate( new
            {
                Total = 0,
                LastScore = 0
            }, ( state, next ) => new
            {
                Total = ( next == '}' ? state.Total + state.LastScore : state.Total ),
                LastScore = ( next == '{' ? state.LastScore + 1 : next == '}' ? state.LastScore - 1 : state.LastScore )
            } ).Total.ToString();
        }
    }
}
