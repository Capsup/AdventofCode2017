using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Utils;
using System.IO;

namespace AdventofCode2017
{
    class Program
    {
        private static Dictionary<int, ISolver> solverDict = new Dictionary<int, ISolver>();

        public static void Main( string[] args )
        {
            var availableSolvers = ReflectionUtils.GetReferencingAssemblies( "Day" ).SelectMany( x => x.ExportedTypes ).Where( x => x.GetTypeInfo().GetInterface( "ISolver" ) != null ).ToArray();
            for( int i = 0; i < availableSolvers.Length; i++ )
            {
                solverDict.Add( i + 1, (ISolver) Activator.CreateInstance( availableSolvers[ i ] ) );
            }

            Console.WriteLine( "Select puzzle to solve:" );
            Console.WriteLine();
            foreach( var kvp in solverDict )
            {
                Console.WriteLine( $"{kvp.Key}: {kvp.Value.PuzzleName}" );
            }

            var rawInput = Console.ReadLine();
            int selectedSolver = 1;
            if( string.IsNullOrEmpty( rawInput ) || !int.TryParse( rawInput, out selectedSolver ) )
                Console.WriteLine( "Unknown identifier for solver, try again" );

            ISolver solver = solverDict[ selectedSolver ];
            Console.WriteLine( solver.Solve( File.ReadAllText( Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/" + solver.GetType().Name + ".input" ) ) );
            Console.ReadKey();
        }
    }
}
