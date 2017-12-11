using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Utils;

namespace Day2
{
    public class Part2Solver : ISolver
    {
        public string PuzzleName
        {
            get
            {
                return "Day 2 - Part 2";
            }
        }

        public string Solve( string input )
        {
            return input.Split( new[] { Environment.NewLine }, StringSplitOptions.None ).Select( x => x.Split( new[] { '\t' } ).Select( y => int.Parse( y ) ).ToArray() ).ToArray()
                .Select( x => x.Aggregate( new
                {
                    FirstNumber = -1,
                    SecondNumber = -1,
                    Number = -1
                }, ( state, next ) => x.Where( y => y != next ).Aggregate( new
                {
                    state.FirstNumber,
                    state.SecondNumber,
                    Number = next
                }, ( state2, next2 ) => new
                {
                    FirstNumber = ( state2.Number % next2 == 0 ) ? state2.Number : state2.FirstNumber,
                    SecondNumber = ( state2.Number % next2 == 0 ) ? next2 : state2.SecondNumber,
                    state2.Number
                } ) ) ).Sum( x => x.FirstNumber > x.SecondNumber ? x.FirstNumber / x.SecondNumber : x.SecondNumber / x.FirstNumber ).ToString();
        }
    }
}
